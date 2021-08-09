using EsgFiskDll.Classes;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EsgFiskDll.Logical.ApiCalls
{
    public class CashDeskCalls
    {

        internal string doRegisterCashDesk(SqlConnection Conn, FiskConfigs Configs, Int32 CashDeskId, Int32 UserId)
        {
            
            try
            {
                RegisterCashDeskReq body = new RegisterCashDeskReq(Configs)
                {
                    TCR = new TCR { 
                        BusinUnitCode = Configs.BusinUnitCode, 
                        IssuerNUIS = Configs.IssuerNUIS, 
                        ValidFrom = System.DateTime.UtcNow.ToString("o"),
                        ValidFromSpecified = true 
                    }

                };

                using (SqlCommand command = new SqlCommand("select top 1 KODI from TBL_NJESI_ADM WHERE pkid=" + CashDeskId.ToString(), Conn))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            body.TCR.TCRIntID = (string)reader["KODI"];
                        }
                    }
                    else
                    {
                        throw new  KeyNotFoundException("Arka me id e dhene nuk u gjend");
                    }

                }
                    
                string url = Configs.url + "/CashDesk/RegisterCashDesk";

                IRestClient client = new RestClient(url);
                IRestRequest request = new RestRequest(Method.POST);


                IRestResponse<RegisterCashDeskResponse> resp = RestRequestHandler<RegisterCashDeskReq, RegisterCashDeskResponse>.MakeResquest(client, request, body, Configs);

                if (resp.IsSuccessful)
                {
                    return "100 - " + resp.Data.tcrCode;
                }
                else
                {
                    return ErrorParser<RegisterCashDeskResponse>.ParseError(resp);
                }
                
            }
            catch (SqlException ex)
            {
                throw new Exception("Esg Error :" + ex.Message.ToString());
            }
        }

        internal string doRegisterCashDeposit(SqlConnection Conn, FiskConfigs Configs, Int32 CashDepositId, Int32 UserId)
        {
            try
            {
                RegisterCashDepositReq body = new RegisterCashDepositReq(Configs);
                using (SqlCommand command = new SqlCommand("select top 1 cr.FiscCode, cd.Amt, cd.Operation from TBL_FISK_CashDeposits as cd inner join TBL_NJESI_ADM AS cr on cd.CashDeskId=cr.pkid WHERE cd.pkid=" + CashDepositId.ToString(), Conn))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            body.CashDeposit.TCRCode = (string)reader["KODI"];
                            body.CashDeposit.CashAmt = (double)reader["AMT"];
                            body.CashDeposit.Operation = (string)reader["Operation"];
                        }
                    }
                    else
                    {
                        throw new KeyNotFoundException("CashDeposit me id e dhene nuk u gjend");
                    }
                }

                string url = Configs.url + "/CashDesk/RegisterCashDeposit";

                IRestClient client = new RestClient(url);
                IRestRequest request = new RestRequest(Method.POST);

                IRestResponse<RegisterCashDepositReponse> resp = RestRequestHandler<RegisterCashDepositReq, RegisterCashDepositReponse>.MakeResquest(client, request, body, Configs);

                if (resp.IsSuccessful)
                {
                    return "100 - " + resp.Data.fcdc;
                }
                else
                {
                    return ErrorParser<RegisterCashDepositReponse>.ParseError(resp);
                }

            }
            catch (SqlException ex)
            {
                throw new Exception("Esg Error :" + ex.Message.ToString());
            }
        }
    }
}
