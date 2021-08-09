using EsgFiskDll.Classes;
using EsgFiskDll.Iterfaces;
using EsgFiskDll.Logical.ApiCalls;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsgFiskDll.Logical
{
    internal class LogiFis:IFiscOps
    {

        public string registerCashDesk(SqlConnection conn, FiskConfigs Configs, int CashDeskId, int UserId)
        {
            try
            {
                CashDeskCalls doRegisterCashDesk = new CashDeskCalls();
                return doRegisterCashDesk.doRegisterCashDesk(conn, Configs, CashDeskId, UserId).ToString();
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
                CashDeskCalls doRegisterCashDeposit = new CashDeskCalls();
                return doRegisterCashDeposit.doRegisterCashDeposit(conn, Configs, CashDepositId, UserId).ToString();
            }
            catch (SqlException ex)
            {
                return ex.Message.ToString();
            }
        }

        public string registerInvoice(SqlConnection conn, FiskConfigs Configs, int InvoiceId, int UserId)
        {
            throw new NotImplementedException();
        }

        public string registerEInvoice(SqlConnection conn, FiskConfigs Configs, int InvoiceId, int UserId)
        {
            throw new NotImplementedException();
        }

        public string getTaxPayer(SqlConnection conn, FiskConfigs Configs, int TaxPayerId, int UserId)
        {
            throw new NotImplementedException();
        }

        public string RegisterWTN(SqlConnection conn, FiskConfigs Configs, int WTNId, int UserId)
        {
            throw new NotImplementedException();
        }

        public string GenerateIICType(SqlConnection conn, FiskConfigs Configs, int InvoiceId, int UserId)
        {
            throw new NotImplementedException();
        }

        public string GenerateWTNICType(SqlConnection conn, FiskConfigs Configs, int WTNId, int UserId)
        {
            throw new NotImplementedException();
        }

        public string CalculateWTNQRCode(SqlConnection conn, FiskConfigs Configs, int WTNId, int UserId)
        {
            throw new NotImplementedException();
        }

        public string CalculateQRCode(SqlConnection conn, FiskConfigs Configs, int InvoidId, int UserId)
        {
            throw new NotImplementedException();
        }
    }
}
