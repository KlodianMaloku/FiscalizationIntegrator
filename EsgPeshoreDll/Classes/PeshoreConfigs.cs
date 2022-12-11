
using System.Data;
using System.Data.SqlClient;

namespace EsgPeshoreDll.Classes
{
    internal class PeshoreConfigs
    {
        public PeshoreConfigs(SqlConnection conn)
        {
            using(SqlCommand cmd = new SqlCommand())
            {
                using(SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    cmd.CommandText = "PESHORE_GET_CONFIGS";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    if (ds.Tables.Count != 0)
                    {
                        if (ds.Tables[0].Rows.Count != 0)
                        {
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {

                                artdata_path = (string)dr["ExportPath_artdata"];
                                txtdata_path = (string)dr["ExportPath_txtdata"];
                                prcdata_path = (string)dr["ExportPath_prcdata"];

                                EtiketePeshePrefix = (string)dr["EtiketePeshePrefix"];
                                EtiketeCopePrefix = (string)dr["EtiketeCopePrefix"];

                            }
                        }
                    }
                }
            }
        }
        public string artdata_path { get; set; }
        public string txtdata_path { get; set; }
        public string prcdata_path { get; set; }
        public string EtiketePeshePrefix { get; set; }
        public string EtiketeCopePrefix { get; set; }

    }
}
