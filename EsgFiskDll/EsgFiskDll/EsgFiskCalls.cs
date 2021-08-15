using EsgFiskDll.Classes;
using EsgFiskDll.Iterfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsgFiskDll
{
    internal class EsgFiskCalls
    {
        public EsgFiskCalls(SqlConnection _conn, FiskConfigs _configs, int _UserId, IFiscOps fiscOps)
        {
            FiscOps = fiscOps;
            conn = _conn;
            UserId = _UserId;
            configs = _configs;
        }
        private FiskConfigs configs { get; set; }
        private SqlConnection conn { get; set; }
        private int UserId { get; set; }
        private IFiscOps FiscOps { get; set; }
        public string registerCashDesk(int cashDeskId)
        {
            return FiscOps.registerCashDesk(conn, configs, cashDeskId, UserId);
        }
        public string registerCashDeposit(int cashDepositId)
        {
            return FiscOps.registerCashDeposit(conn, configs, cashDepositId, UserId);
        }
        public string registerInvoice(int InvoiceId)
        {
            return FiscOps.registerInvoice(conn, configs, InvoiceId, UserId);
        }
        public string registerEInvoice(int InvoiceId)
        {
            return FiscOps.registerInvoice(conn, configs, InvoiceId, UserId);
        }
        public string getTaxPayer(string TaxpayerNipt)
        {
            return FiscOps.getTaxPayer(conn, configs, TaxpayerNipt, UserId);
        }
        public string RegisterWTN(int InvoiceId)
        {
            return FiscOps.registerInvoice(conn, configs, InvoiceId, UserId);
        }
        public string GenerateIICType(int InvoiceId)
        {
            return FiscOps.GenerateIICType(conn, configs, InvoiceId, UserId);
        }
        public string GenerateWTNICType(int InvoiceId)
        {
            return FiscOps.GenerateWTNICType(conn, configs, InvoiceId, UserId);
        }
        public string CalculateWTNQRCode(int InvoiceId)
        {
            return FiscOps.GenerateWTNICType(conn, configs, InvoiceId, UserId);
        }
        public string CalculateQRCode(int InvoiceId)
        {
            return FiscOps.CalculateQRCode(conn, configs, InvoiceId, UserId);
        }
    }
}
