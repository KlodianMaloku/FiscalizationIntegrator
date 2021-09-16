using EsgFiskDll.Classes;
using EsgFiskDll.Iterfaces;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsgFiskDll
{
    public class EsgFisc
    {
        private FiskConfigs configs { get; set; }
        private EsgFiskCalls FiscCalls { get; set; }
        public EsgFisc(SqlConnection _conn, int UserId )
        {
            configs = new FiskConfigs(_conn);

            switch (configs.fiscCompany)
            {
                case "LOGICAL":
                    FiscCalls = new EsgFiskCalls(_conn, configs, UserId, new Logical.LogiFis());
                    break;
                default:
                    break;
            }


        }
        public string registerCashDesk( int CashDeskId)
        {
            return FiscCalls.registerCashDesk(CashDeskId);
        }
        public string registerCashDeposit(int CashDepositId)
        {
            return FiscCalls.registerCashDeposit(CashDepositId);
        }
        public string registerInvoice(int InvoiceId)
        {
            return FiscCalls.registerInvoice(InvoiceId);
        }
        public string registerEInvoice(int InvoiceId)
        {
            return FiscCalls.registerEInvoice(InvoiceId);
        }
        public string getTaxPayer(string TaxPayerNipt)
        {
            return FiscCalls.getTaxPayer(TaxPayerNipt);
        }
        public string RegisterWTN(int InvoiceId)
        {
            return FiscCalls.RegisterWTN(InvoiceId);
        }
        public string GenerateIICType(int InvoiceId)
        {
            return FiscCalls.GenerateIICType(InvoiceId);
        }
        public string GenerateWTNICType(int InvoiceId)
        {
            return FiscCalls.GenerateWTNICType(InvoiceId);
        }
        public string CalculateWTNQRCode(int InvoiceId)
        {
            return FiscCalls.CalculateWTNQRCode(InvoiceId);
        }
        public string CalculateQRCode(int InvoiceId)
        {
            return FiscCalls.CalculateQRCode(InvoiceId);
        }


    }
}
