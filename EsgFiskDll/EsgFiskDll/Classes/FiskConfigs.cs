using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsgFiskDll.Classes
{
    public class FiskConfigs
    {

        public FiskConfigs(SqlConnection Conn)
        {
            try
            {
                using (SqlCommand command = new SqlCommand())
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(command))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "UP_FISC_NEW_GET_FISK_MAIN_DATA";
                        command.Connection = Conn;
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        if (ds.Tables.Count != 0)
                        {
                            if (ds.Tables[0].Rows.Count!=0)
                            {
                                foreach(DataRow dr in ds.Tables[0].Rows)
                                {
                                    if ((int)dr["IsServiceTest"] == 1)
                                    {
                                        BusinUnitCode = (string)dr["testBusinUnitCode"];
                                        OperatorCode = (string)dr["testOperatorCode"];
                                        IssuerNUIS = (string)dr["testissuerNUIS"];
                                        CertificatePassword = (string)dr["testCertificatePassword"];
                                        //CertificatePath = dr.IsNull("testCertificatePath") ? null : (string)dr["testCertificatePath"];
                                        CertificateData = dr.IsNull("testCertificateData") ? null : (string)dr["testCertificateData"];
                                        ApiUsername = (string)dr["testFiskApiUsername"];
                                        ApiPassword = (string)dr["testFiskApiPassword"];
                                        url = (string)dr["testFiskCompanyUrl"];
                                    }
                                    else
                                    {
                                        BusinUnitCode = (string)dr["BusinUnitCode"];
                                        OperatorCode = (string)dr["OperatorCode"];
                                        IssuerNUIS = (string)dr["issuerNUIS"];
                                        //CertificatePath = dr.IsNull("CertificatePath") ? null : (string)dr["CertificatePath"];
                                        CertificateData = dr.IsNull("CertificateData") ? null : (string)dr["CertificateData"];
                                        CertificatePassword = (string)dr["CertificatePassword"];
                                        ApiUsername = (string)dr["FiskApiUsername"];
                                        ApiPassword = (string)dr["FiskApiPassword"];
                                        url = (string)dr["FiskCompanyUrl"];

                                    }
                                    ServerDatetime = (string)dr["ServerDatetime"];
                                    IsServiceTest = (int)dr["IsServiceTest"] == 1 ? true : false;
                                    fiscCompany = (string)dr["fiscCompany"];

                                }
                            }
                        }
                    }

                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string url { get; set; }
        public string BusinUnitCode { get; set; }
        public string OperatorCode { get; set; }
        public string IssuerNUIS { get; set; }
        public string CertificatePassword { get; set; }
        public string CertificatePath { get; set; }
        public string CertificateData { get; set; }
        public string ApiUsername { get; set; }
        public string ApiPassword { get; set; }
        public bool IsServiceTest { get; set; }
        public string fiscCompany { get; set; }

        public string ServerDatetime { get; set; }

    }

}
