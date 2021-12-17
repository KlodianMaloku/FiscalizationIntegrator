using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsgEslDll.Classes
{
    internal class EslConfigs
    {
        public EslConfigs(SqlConnection conn)
        {
            using(SqlCommand cmd = new SqlCommand())
            {
                using(SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    cmd.CommandText = "ESL_GET_CONFIGS";
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

                                EslBaseUrl = (string)dr["EslBaseUrl"];
                                StoreId = (string)dr["StoreId"];
                                SubscriptionKey = (string)dr["SubscriptionKey"];

                            }
                        }
                    }
                }
            }
        }

        public string EslBaseUrl { get; set; }
        public string StoreId { get; set; }
        public string SubscriptionKey { get; set; }

    }
}
