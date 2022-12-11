using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Data;
using System.Runtime.InteropServices;
using EsgEslDll.Classes;

namespace EsgEslDll
{
    public class EslOps
    {
        private EslConfigs cnf { get; set;}
        private SqlConnection conn_;
        public EslOps(SqlConnection conn)
        {
            conn_ = conn;
            cnf = new EslConfigs(conn);
        }
        class sentItem
        {
            public long PKID { get; set; }
            public int NEWART_UPDART_CMIM_PROMO_ENDPROMO { get; set; }
        }
        public String SendItems()
        {
            int line = 0;
            try
            {
                var client = new HttpClient();

                // Request headers
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", cnf.SubscriptionKey);

                var fileName = Guid.NewGuid().ToString() + ".txt";

                var uri = cnf.EslBaseUrl + "/" + cnf.StoreId + "/items/files/"+fileName;

                var body = "";

                List<sentItem> sentItemsList = new List<sentItem>();

                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandText = "UP_POS_KRIJO_PERMBATJE_ESL_SES";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = conn_;
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        if (ds.Tables.Count != 0)
                        {
                            if (ds.Tables[0].Rows.Count != 0)
                            {
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    
                                    body += (string)dr["ROW_"] + Environment.NewLine;
                                    
                                    sentItemsList.Add(new sentItem { PKID = long.Parse( dr["PKID"].ToString()), NEWART_UPDART_CMIM_PROMO_ENDPROMO = (int)dr["NEWART_UPDART_CMIM_PROMO_ENDPROMO"] });
                                    
                                }
                            }
                        }
                    }
                }

                HttpResponseMessage response;

                // Request body
                byte[] byteData = Encoding.UTF8.GetBytes(body);


                using (var content = new ByteArrayContent(byteData))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
                    Task<HttpResponseMessage> task = Task.Run<HttpResponseMessage>(async () => await client.PostAsync(uri, content));
                    response = task.Result;
                }

                var statusCode = response.StatusCode.ToString();
                

                Task<String> retTask = Task.Run<String>(async () => await response.Content.ReadAsStringAsync());


                if (statusCode == "OK")
                {

                    foreach (sentItem item in sentItemsList)
                    {
                        using (SqlCommand cmdSetProcessed = new SqlCommand())
                        {
                            
                            cmdSetProcessed.Connection = conn_;
                            
                            cmdSetProcessed.CommandText = "UP_POS_UPDATE_ESL_SES";
                            
                            cmdSetProcessed.CommandType = CommandType.StoredProcedure;
                            
                            cmdSetProcessed.Parameters.Add(new SqlParameter("PKID", item.PKID));
                            
                            cmdSetProcessed.Parameters.Add(new SqlParameter("NEWART_UPDART_CMIM_PROMO_ENDPROMO", item.NEWART_UPDART_CMIM_PROMO_ENDPROMO));
                            
                            cmdSetProcessed.ExecuteNonQuery();
                        }
                    }

                    return statusCode;

                }
                else
                {
                    return statusCode + ":" + retTask.Result ;
                }
                
            }
            catch(Exception ex)
            {
                return "500 -" + line.ToString() + "             " + ex.Message + "     " + ex.StackTrace + "       " + ex.Source + "     " + ex.InnerException;
            }

        }
    }
}
