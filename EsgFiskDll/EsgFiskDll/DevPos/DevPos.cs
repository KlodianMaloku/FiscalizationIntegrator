using EsgFiskDll.Classes;
using EsgFiskDll.DevPos.ApiCalls;
using EsgFiskDll.Iterfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsgFiskDll.DevPos
{
    internal class DevPos:IFiscOps
    {
        public DevPos()
        {
            DevPosApiCall = new DevPosApiCalls();
        }
        public DevPosApiCalls DevPosApiCall { get; set; }
        public string registerCashDesk(SqlConnection conn, FiskConfigs Configs, int CashDeskId, int UserId)
        {
            try
            {
                return DevPosApiCall.doRegisterCashDesk(conn, Configs, CashDeskId, UserId).ToString();
            }
            catch (SqlException ex)
            {
                return ex.Message.ToString();
            }
        }

        public string registerCashDeposit(SqlConnection conn, FiskConfigs Configs, int CashDepositId, int UserId)
        {
            try
            {
                return DevPosApiCall.doRegisterCashDeposit(conn, Configs, CashDepositId, UserId).ToString();
            }
            catch (SqlException ex)
            {
                return ex.Message.ToString();
            }
        }

        public string registerInvoice(SqlConnection conn, FiskConfigs Configs, int InvoiceId, int UserId)
        {
            return DevPosApiCall.doRegisterInvoice(conn, Configs, InvoiceId, UserId);
        }

        public string registerEInvoice(SqlConnection conn, FiskConfigs Configs, int InvoiceId, int UserId)
        {
            throw new NotImplementedException();
        }

        public string getTaxPayer(SqlConnection conn, FiskConfigs Configs, string TaxPayerNipt, int UserId)
        {
            return DevPosApiCall.doGetTaxpayers(conn, Configs, TaxPayerNipt, UserId);
        }

        public string RegisterWTN(SqlConnection conn, FiskConfigs Configs, int WTNId, int UserId)
        {
            throw new NotImplementedException();
        }

        public string GenerateIICType(SqlConnection conn, FiskConfigs Configs, int InvoiceId, int UserId)
        {
            return DevPosApiCall.doGenereateIICType(conn, Configs, InvoiceId, UserId);
        }

        public string GenerateWTNICType(SqlConnection conn, FiskConfigs Configs, int WTNId, int UserId)
        {
            throw new NotImplementedException();
        }

        public string CalculateWTNQRCode(SqlConnection conn, FiskConfigs Configs, int WTNId, int UserId)
        {
            throw new NotImplementedException();
        }

        public string CalculateQRCode(SqlConnection conn, FiskConfigs Configs, int InvoiceId, int UserId)
        {
            return DevPosApiCall.doGenereateIICQR(conn, Configs, InvoiceId, UserId);
        }


    }
}
