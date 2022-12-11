using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using EsgPeshoreDll.Classes;

namespace EsgPeshoreDll
{
    class sentItem
    {
        public long PKID { get; set; }
        public int NEWART_UPDART_CMIM_PROMO_ENDPROMO { get; set; }
    }
    public class PeshoreOps
    {
        private PeshoreConfigs cnf { get; set; }
        private SqlConnection conn_;
        public PeshoreOps(SqlConnection conn)
        {
            conn_ = conn;
            cnf = new PeshoreConfigs(conn);
        }

        public String SendItemsPeshore()
        {
            
            try
            {
                string body = "";
               
                List<sentItem> sentItemsList = new List<sentItem>();
               
                using (SqlCommand cmd = new SqlCommand())
                {
                   
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                       
                        cmd.CommandText = "UP_POS_KRIJO_PERMBAJTJE_SKEDARI_PER_PESHORE";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
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

                                    sentItemsList.Add(new sentItem { PKID = long.Parse(dr["pkid"].ToString()), NEWART_UPDART_CMIM_PROMO_ENDPROMO = (int)dr["NEWART_UPDART_CMIM_PROMO_ENDPROMO"] });

                                }
                            }
                        }
                    }
                }
               
                string WriteResult = WriteTextFile(body, cnf.artdata_path, false);

                if (WriteResult == "OK")
                {
                    if (conn_.State == ConnectionState.Closed)
                        conn_.Open();

                    foreach (sentItem item in sentItemsList)
                    {

                        using (SqlCommand cmdSetProcessed = new SqlCommand())
                        {
                            cmdSetProcessed.Connection = conn_;
                            cmdSetProcessed.CommandText = "UP_POS_UPDATE_PESHORE_STATUS";
                            cmdSetProcessed.CommandType = CommandType.StoredProcedure;
                            cmdSetProcessed.Parameters.Add(new SqlParameter("PKID", item.PKID));
                            cmdSetProcessed.Parameters.Add(new SqlParameter("NEWART_UPDART_CMIM_PROMO_ENDPROMO", item.NEWART_UPDART_CMIM_PROMO_ENDPROMO));
                            cmdSetProcessed.ExecuteNonQuery();
                        }

                    }
                }


                return "OK" + body;

            }
            catch(Exception ex)
            {
                return "500 - Line:" + "               " + ex.Message + "     " + ex.StackTrace + "       " + ex.Source + "     " + ex.InnerException;
            }
            

        }

        private string WriteTextFile(string text,string path,bool append)
        {

            try
            {

                List<Int64> processedItems = new List<Int64>();

                if (text != string.Empty && path != string.Empty)
                {
                    var dir = Path.GetDirectoryName(path);
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);

                    System.IO.File.AppendAllText(path, text);

                    return "OK";
                }
                
                return "Gabim";

            }
            catch (Exception ex)
            {
                return "500 -" + ex.Message + "     " + ex.StackTrace + "       " + ex.Source + "     " + ex.InnerException;
            }
        }
    }
}
