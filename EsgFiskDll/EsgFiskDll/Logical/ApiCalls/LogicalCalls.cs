﻿using EsgFiskDll.Classes;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EsgFiskDll.Logical.ApiCalls;
using RestSharp.Serialization.Json;

namespace EsgFiskDll.Logical.ApiCalls
{
    internal class LogicalCalls
    {

        public string doRegisterCashDesk(SqlConnection Conn, FiskConfigs Configs, Int32 CashDeskId, Int32 UserId)
        {
            
            try
            {
                RegisterCashDeskReq body = new RegisterCashDeskReq(Configs)
                {
                    TCR = new TCR { 
                        BusinUnitCode = Configs.BusinUnitCode, 
                        IssuerNUIS = Configs.IssuerNUIS, 
                        ValidFrom = Configs.ServerDatetime,
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
                            body.TCR.Type = "REGULAR";
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

                IRestResponse<RegisterCashDeskResponseV2> resp = RestRequestHandler<RegisterCashDeskReq, RegisterCashDeskResponseV2>.MakeResquest(client, request, body, Configs);

                if (resp.IsSuccessful)
                {
                    return "100 - " + resp.Data.registerTCRResponse.tcrCode;
                }
                else
                {
                    return ErrorParser<RegisterCashDeskResponseV2>.ParseError(resp);
                }

            }
            catch (SqlException ex)
            {
                throw new Exception("Esg Error :" + ex.Message.ToString());
            }
        }

        public string doRegisterCashDeposit(SqlConnection Conn, FiskConfigs Configs, Int32 CashDepositId, Int32 UserId)
        {
            try
            {
                RegisterCashDepositReq body = new RegisterCashDepositReq(Configs);

                using (SqlCommand command = new SqlCommand())
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(command))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "UP_FISC_NEW_CREATE_REGISTER_CASH_DEPOSIT_REQUEST";
                        command.Parameters.Add(new SqlParameter { ParameterName = "CashDepositId", Direction = System.Data.ParameterDirection.Input, Precision = 8, Value = CashDepositId });
                        command.Connection = Conn;
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        if (ds.Tables.Count != 0)
                        {
                            if (ds.Tables[0].Rows.Count != 0)
                            {

                                body.CashDeposit = new CashDeposit()
                                {
                                    CashAmt = (double)ds.Tables[0].Rows[0]["Amt"],
                                    ChangeDateTime = body.Header.SendDateTime,
                                    IssuerNUIS = Configs.IssuerNUIS,
                                    TCRCode = ds.Tables[0].Rows[0]["TCRCode"].ToString(),
                                    Operation = ds.Tables[0].Rows[0]["Operation"].ToString()
                                };
                            }
                        }
                    }
                }

                string url = Configs.url + "/BalanceCashDesk/RegisterCashDeposit";

                IRestClient client = new RestClient(url);
                IRestRequest request = new RestRequest(Method.POST);

                IRestResponse<RegisterCashDepositResponseV2> resp = RestRequestHandler<RegisterCashDepositReq, RegisterCashDepositResponseV2>.MakeResquest(client, request, body, Configs);

                if (resp.IsSuccessful)
                {
                    return "100 - " + resp.Data.registerCashDepositResponse.fcdc;
                }
                else
                {
                    return ErrorParser<RegisterCashDepositResponseV2>.ParseError(resp);
                }

            }
            catch (SqlException ex)
            {
                throw new Exception("Esg Error :" + ex.Message.ToString());
            }
        }

        public string doGenereateIICType(SqlConnection Conn, FiskConfigs Configs, Int32 InvoiceId, Int32 UserId)
        {
            try
            {

                GenerateIICTYPEReq body = new GenerateIICTYPEReq(Configs);
                using (SqlCommand command = new SqlCommand())
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(command))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "UP_FISC_NEW_CREATE_IICTYPE_REQUEST";
                        command.Parameters.Add(new SqlParameter { ParameterName = "InvoiceId", Direction = System.Data.ParameterDirection.Input, Precision = 8, Value = InvoiceId });
                        command.Connection = Conn;
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        if (ds.Tables.Count != 0)
                        {
                            if (ds.Tables[0].Rows.Count != 0)
                            {
                                body.TcrCode = ds.Tables[0].Rows[0]["TcrCode"].ToString();
                                body.InvNum = ds.Tables[0].Rows[0]["InvNum"].ToString();
                                body.TotPrice = double.Parse(ds.Tables[0].Rows[0]["TotPrice"].ToString());

                                string url = Configs.url + "/Helper/GenerateIICType";

                                IRestClient client = new RestClient(url);
                                IRestRequest request = new RestRequest(Method.POST);
                                string filePath = $@"{Configs.filePath}\\doGenereateIICType-{body.InvNum}";
                                IRestResponse<GenerateIICTypeResponse> resp =
                                    RestRequestHandler<GenerateIICTYPEReq, GenerateIICTypeResponse>.MakeResquest(client,
                                        request, body, Configs, filePath);

                                if (resp.IsSuccessful)
                                {
                                    return "100 - " + resp.Data.iic + "@------@" + resp.Data.iicSignature;
                                }
                                else
                                {
                                    return ErrorParser<GenerateIICTypeResponse>.ParseError(resp);
                                }
                            }
                        }
                        return "100 - " + "Not for Fiscalization@------@Not for fiscalization";
                    }
                }


            }
            catch (SqlException ex)
            {
                throw new Exception("Esg Error :" + ex.Message.ToString());
            }
        }

        public string doGenereateIICQR(SqlConnection Conn, FiskConfigs Configs, Int32 InvoiceId, Int32 UserId)
        {
            try
            {

                CalculateQRCodeReq body = new CalculateQRCodeReq(Configs);
                using (SqlCommand command = new SqlCommand())
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(command))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "UP_FISC_NEW_CREATE_IIQR_REQUEST";
                        command.Parameters.Add(new SqlParameter { ParameterName = "InvoiceId", Direction = System.Data.ParameterDirection.Input, Precision = 8, Value = InvoiceId });
                        command.Connection = Conn;
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        if (ds.Tables.Count != 0)
                        {
                            if (ds.Tables[0].Rows.Count != 0)
                            {
                                body.IIC = ds.Tables[0].Rows[0]["IIC"].ToString();
                                body.TcrCode = ds.Tables[0].Rows[0]["TcrCode"].ToString();
                                body.InvOrdNum = int.Parse(ds.Tables[0].Rows[0]["InvNum"].ToString());
                                body.TotPrice = double.Parse(ds.Tables[0].Rows[0]["TotPrice"].ToString());

                                string url = Configs.url + "/Helper/CalculateQRCode";

                                IRestClient client = new RestClient(url);
                                IRestRequest request = new RestRequest(Method.POST);

                                request.AddHeader("Content-Type", "application/json");
                                request.AddHeader("Accept", "*/*");
                                request.AddHeader("Connection", "keep-alive");
                                request.AddJsonBody(body);

                                JsonSerializer jsonSerializer = new JsonSerializer();
                                string jsonBody = jsonSerializer.Serialize(body);
                                string filePath = $@"{Configs.filePath}\\doGenereateIICQR-{body.InvOrdNum}_req.json";
                                Utils.SaveJsonBodyToFile(jsonBody, filePath);

                                HttpBasicAuthenticator authenticator = new HttpBasicAuthenticator(Configs.ApiUsername, Configs.ApiPassword);
                                authenticator.Authenticate(client, request);

                                IRestResponse resp = client.Post(request);

                                filePath = $@"{Configs.filePath}\\doGenereateIICQR-{body.InvOrdNum}_resp.json";
                                Utils.SaveJsonBodyToFile(resp.Content.ToString(), filePath);

                                if (resp.IsSuccessful)
                                {
                                    return "100 - " + resp.Content.ToString();
                                }
                                else
                                {
                                    return "400 - Gabim : " + resp.ErrorMessage + "     StatusCode:" + resp.StatusCode + "   Content : " + resp.Content;
                                }

                            }
                        }

                        return "100 - " + "Not for fiscalization";
                    }
                }


            }
            catch (SqlException ex)
            {
                throw new Exception("Esg Error :" + ex.Message.ToString());
            }
        }

        public string doGetTaxpayers(SqlConnection Conn, FiskConfigs Configs, string TaxPayerNIPT, Int32 UserId)
        {
            TaxPayer tp = GetTaxpayers(Conn, Configs, TaxPayerNIPT, UserId);

            return tp.address;

        }

        private TaxPayer GetTaxpayers(SqlConnection Conn, FiskConfigs Configs, string TaxPayerNIPT, Int32 UserId)
        {
            try
            {

                GetTaxPayersReq body = new GetTaxPayersReq(Configs);

                body.Filter = new GetTaxPayerFilter { Tin = TaxPayerNIPT };

                string url = Configs.url + "/GetTaxpayers/GetTaxpayers";

                IRestClient client = new RestClient(url);
                IRestRequest request = new RestRequest(Method.POST);

                IRestResponse<GetTaxPayersResponse> resp = RestRequestHandler<GetTaxPayersReq, GetTaxPayersResponse>.MakeResquest(client, request, body, Configs);

                if (resp.IsSuccessful)
                {
                    return resp.Data.taxpayers[0];
                }
                else
                {
                    throw new Exception("Gabim ne marjen e te dhenave te biznesit.");
                }

            }
            catch (SqlException ex)
            {
                throw new Exception("Esg Error :" + ex.Message.ToString());
            }
        }

        public string doRegisterInvoice(SqlConnection Conn, FiskConfigs Configs, Int32 InvoiceId, Int32 UserId)
        {
            try
            {
                RegisterInvoiceReq body = new RegisterInvoiceReq(Configs);

                using (SqlCommand command = new SqlCommand())
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(command))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "UP_FISC_NEW_CREATE_INV_REQUEST";
                        command.Parameters.Add(new SqlParameter { ParameterName = "InvoiceId", Direction = System.Data.ParameterDirection.Input, Precision = 8, Value = InvoiceId });
                        command.Connection = Conn;
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        if (ds.Tables.Count != 0)
                        {

                            if (ds.Tables[0].Rows.Count == 0)
                            {

                                return "100- Not for Fiscalization";

                            }

                            if (ds.Tables[5].Rows.Count != 0)
                            {
                                foreach (DataRow dr in ds.Tables[5].Rows)
                                {
                                    if (dr["IsValidNIPT"].ToString() == "0")
                                    {
                                        if (dr["IsBussines"].ToString() == "1")
                                        {
                                            throw new Exception("Esg Error : Fatura nuk u fiskalizuar per shkakt te niptit te klientit jo te sakte.");
                                        }
                                    }
                                }
                            }

                            if (ds.Tables[0].Rows.Count != 0)
                            {
                                body.Invoice = new Invoice();

                                body.Invoice.BusinUnitCode = (string)ds.Tables[0].Rows[0]["BusinUnitCode"];
                                body.Invoice.IIC = (string)ds.Tables[0].Rows[0]["IIC"];
                                body.Invoice.IICSignature = (string)ds.Tables[0].Rows[0]["IICSignature"];
                                body.Invoice.InvOrdNum = (Int64)ds.Tables[0].Rows[0]["InvOrdNum"];
                                body.Invoice.InvNum = ds.Tables[0].Rows[0]["InvNum"].ToString();
                                body.Invoice.IsEinvoice = (int)ds.Tables[0].Rows[0]["IsEinvoice"] == 1;
                                body.Invoice.IsIssuerInVAT = (int)ds.Tables[0].Rows[0]["IsIssuerInVAT"] == 1;
                                body.Invoice.IsReverseCharge = (int)ds.Tables[0].Rows[0]["IsReverseCharge"] == 1;
                                body.Invoice.IsSimplifiedInv = (int)ds.Tables[0].Rows[0]["IsSimplifiedInv"] == 1;
                                body.Invoice.IssueDateTime = body.Header.SendDateTime;//   ds.Tables[0].Rows[0]["IssueDateTime"].ToString();
                                body.Invoice.OperatorCode = (string)ds.Tables[0].Rows[0]["Operatorcode"];
                                body.Invoice.PayDeadline = body.Header.SendDateTime;
                                body.Invoice.PayDeadlineSpecified = (int)ds.Tables[0].Rows[0]["PayDeadLineSpecified"] == 1;
                                body.Invoice.TCRCode = (string)ds.Tables[0].Rows[0]["TCRCode"];
                                body.Invoice.TotPrice = (double)ds.Tables[0].Rows[0]["TotPrice"];
                                body.Invoice.TotPriceWoVAT = (double)ds.Tables[0].Rows[0]["TotPriceWoVAT"];
                                body.Invoice.TotVATAmt = (double)ds.Tables[0].Rows[0]["TotVATAmt"];
                                body.Invoice.TotVATAmtSpecified = (int)ds.Tables[0].Rows[0]["TotVATAmtSpecified"] == 1;
                                body.Invoice.TypeOfInv = (string)ds.Tables[0].Rows[0]["TypeOfInv"];

                            }

                            if (ds.Tables[1].Rows.Count != 0)
                            {
                                body.Invoice.Items = new List<IItem>();
                                foreach (DataRow dr in ds.Tables[1].Rows)
                                {
                                    if ((double)dr["VR"] == 0)
                                    {
                                        ItemExVat itemEx = new ItemExVat();
                                        itemEx.C = (string)dr["C"];
                                        itemEx.N = (string)dr["N"];
                                        itemEx.PA = (double)dr["PA"];
                                        itemEx.PB = (double)dr["PB"];
                                        itemEx.Q = (double)dr["Q"];
                                        itemEx.U = (string)dr["U"];
                                        itemEx.UPA = (double)dr["UPA"];
                                        itemEx.UPB = (double)dr["UPB"];
                                        itemEx.VA = (double)dr["VA"];
                                        itemEx.VASpecified = (int)dr["VASpecified"] == 1;
                                        itemEx.VR = (double)dr["VR"];
                                        itemEx.VRSpecified = (int)dr["VRSpecified"] == 1;
                                        itemEx.EX = (string)dr["EX"];
                                        itemEx.EXSpecified = true;
                                        body.Invoice.Items.Add(itemEx);
                                    }
                                    else
                                    {
                                        Item item = new Item();
                                        item.C = (string)dr["C"];
                                        item.N = (string)dr["N"];
                                        item.PA = (double)dr["PA"];
                                        item.PB = (double)dr["PB"];
                                        item.Q = (double)dr["Q"];
                                        item.U = (string)dr["U"];
                                        item.UPA = (double)dr["UPA"];
                                        item.UPB = (double)dr["UPB"];
                                        item.VA = (double)dr["VA"];
                                        item.VASpecified = (int)dr["VASpecified"] == 1;
                                        item.VR = (double)dr["VR"];
                                        item.VRSpecified = (int)dr["VRSpecified"] == 1;
                                        body.Invoice.Items.Add(item);
                                    }
                                }
                            }

                            if (ds.Tables[2].Rows.Count != 0)
                            {
                                body.Invoice.PayMethods = new List<PayMethod>();
                                foreach (DataRow dr in ds.Tables[2].Rows)
                                {
                                    PayMethod pm = new PayMethod
                                    {
                                        Amt = (double)dr["Amt"],
                                        Type = (string)dr["Type"]
                                    };
                                    body.Invoice.PayMethods.Add(pm);
                                }
                            }

                            if (ds.Tables[3].Rows.Count != 0)
                            {
                                body.Invoice.SameTaxes = new List<ISameTax>();
                                foreach (DataRow dr in ds.Tables[3].Rows)
                                {
                                    if ((double)dr["VATAmt"] == 0)
                                    {
                                        SameTaxExVat sm = new SameTaxExVat
                                        {
                                            NumOfItems = (int)dr["NumOfItems"],
                                            PriceBefVAT = (double)dr["PriceBEfVAT"],
                                            VATAmt = (double)dr["VATAmt"],
                                            VATAmtSpecified = (int)dr["VATAmtSpecified"] == 1,
                                            VATRate = (double)dr["VATRate"],
                                            VATRateSpecified = (int)dr["VATRatespecified"] == 1,
                                            ExemptFromVAT = (string)dr["ExemptFromVAT"],
                                            ExemptFromVATSpecified = true
                                        };
                                        body.Invoice.SameTaxes.Add(sm);
                                    }
                                    else
                                    {
                                        SameTax sm = new SameTax
                                        {
                                            NumOfItems = (int)dr["NumOfItems"],
                                            PriceBefVAT = (double)dr["PriceBEfVAT"],
                                            VATAmt = (double)dr["VATAmt"],
                                            VATAmtSpecified = (int)dr["VATAmtSpecified"] == 1,
                                            VATRate = (double)dr["VATRate"],
                                            VATRateSpecified = (int)dr["VATRatespecified"] == 1
                                        };
                                        body.Invoice.SameTaxes.Add(sm);
                                    }                                    
                                }
                            }

                            //TaxPayer tp = GetTaxpayers(Conn, Configs, Configs.IssuerNUIS, UserId);
                            if (ds.Tables[4].Rows.Count != 0)
                            {
                                foreach (DataRow dr in ds.Tables[4].Rows)
                                {
                                    body.Invoice.Seller = new Seller
                                    {
                                        Address = (string)dr["Address"],
                                        Country = (string)dr["Country"],
                                        CountrySpecified = true,
                                        IDNum = (string)dr["IDNum"],
                                        IDType = (string)dr["IDType"],
                                        Name = (string)dr["Name"],
                                        Town = (string)dr["Town"]
                                    };
                                }
                            }
                                
                            if(ds.Tables[5].Rows.Count != 0)
                            {
                                foreach (DataRow dr in ds.Tables[5].Rows)
                                {
                                    if(dr["IsValidNIPT"].ToString() == "1")
                                    {
                                        if(dr["GetBuyerOnline"].ToString() == "1")
                                        {
                                            TaxPayer tp = GetTaxpayers(Conn, Configs, Configs.IssuerNUIS, UserId);
                                            body.Invoice.Buyer = new Buyer
                                            {
                                                Address = tp.address,
                                                Country = "",
                                                CountrySpecified = false,
                                                IDNum = tp.tin,
                                                IDType ="NUIS" ,
                                                Name =tp.name,
                                                Town = tp.town
                                            };
                                        }
                                        else
                                        {
                                            body.Invoice.Buyer = new Buyer
                                            {
                                                Address = (string)dr["Address"],
                                                Country = (string)dr["Country"],
                                                CountrySpecified = true,
                                                IDNum = (string)dr["IDNum"],
                                                IDType = (string)dr["IDType"],
                                                Name = (string)dr["Name"],
                                                Town = (string)dr["Town"]
                                            };
                                        }
                                    }
                                }
                            }

                            string url = Configs.url + "/Invoice/RegisterInvoice";

                            IRestClient client = new RestClient(url);
                            IRestRequest request = new RestRequest(Method.POST);
                            string filePath = $@"{Configs.filePath}\\doRegisterInvoice-{body.Invoice.InvOrdNum}";
                            IRestResponse<registerInvoiceReponseV2> resp = RestRequestHandler<RegisterInvoiceReq, registerInvoiceReponseV2>.MakeResquest(client, request, body, Configs, filePath);

                            if (resp.IsSuccessful)
                            {
                                return "100 - " + resp.Data.registerInvoiceResponse.fic.ToString();
                            }
                            else
                            {
                                return ErrorParser<registerInvoiceReponseV2>.ParseError(resp);
                            }

                        }

                        return "100 - Not for fiscalization..";

                    }                
                    
                }



            }
            catch (SqlException ex)
            {
                throw new Exception("Esg Error :" + ex.Message.ToString());
            }
        }

    }
}
