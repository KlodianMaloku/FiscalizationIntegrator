using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Data;
using System.Data.SqlTypes;
using System.IO;
using EsgPeshoreDll.Classes;

namespace EsgPeshoreDll
{
    public class PeshoreOps
    {
        private PeshoreConfigs cnf { get; set; }
        private SqlConnection conn_;
        public PeshoreOps(SqlConnection conn)
        {
            conn_ = conn;
            cnf = new PeshoreConfigs(conn);
        }

        public string SendItemsPeshore()
        {
            string body = "";

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

                            }
                        }
                    }
                }
            }

            bool WriteResult = WriteTextFile(body, cnf.artdata_path, false);


            return WriteResult ? "100- ok" : "500- error creating file";


        }

        private bool WriteTextFile(string text,string path,bool append)
        {

            try
            {
                if (text != string.Empty && path != string.Empty)
                {
                    var dir = Path.GetDirectoryName(path);
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);
                    using (var sw = new StreamWriter(path, append))
                    {
                        sw.WriteLine(text);
                    }
                    return true;
                }
                
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
