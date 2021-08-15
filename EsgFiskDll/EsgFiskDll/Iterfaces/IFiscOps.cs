
using EsgFiskDll.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsgFiskDll.Iterfaces
{
    internal interface IFiscOps
    {
        string registerCashDesk(SqlConnection conn, FiskConfigs Configs, int CashDeskId, int UserId);
        string registerCashDeposit(SqlConnection conn, FiskConfigs Configs, int CashDepositId, int UserId);
        string registerInvoice(SqlConnection conn, FiskConfigs Configs, int InvoiceId, int UserId);
        string registerEInvoice(SqlConnection conn, FiskConfigs Configs, int InvoiceId, int UserId);
        string getTaxPayer(SqlConnection conn, FiskConfigs Configs, string TaxPayerNipt, int UserId);
        string RegisterWTN(SqlConnection conn, FiskConfigs Configs, int WTNId, int UserId);
        string GenerateIICType(SqlConnection conn, FiskConfigs Configs, int InvoiceId, int UserId);
        string GenerateWTNICType(SqlConnection conn, FiskConfigs Configs, int WTNId, int UserId);
        string CalculateWTNQRCode(SqlConnection conn, FiskConfigs Configs, int WTNId, int UserId);
        string CalculateQRCode(SqlConnection conn, FiskConfigs Configs, int InvoidId, int UserId);

    }
}
