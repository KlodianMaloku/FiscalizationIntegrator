using System;
using System.Collections.Generic;
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
                using (SqlCommand command = new SqlCommand("select top 1 * from TBL_FISK_MAIN_DATA", Conn))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if ((int)reader["IsServiceTest"] == 1)
                            {
                                BusinUnitCode = (string)reader["testBusinUnitCode"];
                                OperatorCode = (string)reader["testOperatorCode"];
                                IssuerNUIS = (string)reader["testissuerNUIS"];
                                CertificatePath = (string)reader["testCertificatePath"];
                                CertificatePassword = (string)reader["testCertificatePassword"];
                                CertificateData = (string)reader["testCertificateData"];
                                ApiUsername = (string)reader["testFiskApiUsername"];
                                ApiPassword = (string)reader["testFiskApiPassword"];
                                url = (string)reader["testFiskCompanyUrl"];
                            }
                            else
                            {
                                BusinUnitCode = (string)reader["BusinUnitCode"];
                                OperatorCode = (string)reader["OperatorCode"];
                                IssuerNUIS = (string)reader["issuerNUIS"];
                                CertificatePath = (string)reader["CertificatePath"];
                                CertificatePassword = (string)reader["CertificatePassword"];
                                CertificateData = (string)reader["CertificateData"];
                                ApiUsername = (string)reader["FiskApiUsername"];
                                ApiPassword = (string)reader["FiskApiPassword"];
                                url = (string)reader["FiskCompanyUrl"];
                            }

                            IsServiceTest = (int)reader["IsServiceTest"] == 1 ? true : false;
                            fiscCompany = (string)reader["fiscCompany"];

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

    }

}
