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

        public string SendItems()
        {
            var client = new HttpClient();

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", cnf.SubscriptionKey);

            var fileName = Guid.NewGuid().ToString() + ".txt";

            var uri = cnf.EslBaseUrl + "/" + cnf.StoreId + "/items/files/"+fileName;

            var body = "";

            using (SqlCommand cmd = new SqlCommand())
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    cmd.CommandText = "UP_POS_KRIJO_PERMBAJTJE_SKEDARI_PER_ESL_3";
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

            Task<String> retTask = Task.Run<String>(async () => await response.Content.ReadAsStringAsync());

            return retTask.Result;

        }
    }
}
