using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsgFiskDll.Logical
{
    public class RespHeader
    {

        public string header { get; set; }
        public string signature { get; set; }
    }
    /// <summary>
    /// register cash desk
    /// </summary>
   public class RegisterCashDeskResponseV2
    {
        public RegisterCashDeskResponse registerTCRResponse { get; set; }
        public string xmlRequest { get; set; }
    }

    public class RegisterCashDeskResponse:RespHeader
    {
        public string tcrCode { get; set; }
    }
    /// <summary>
    /// register CashDeposit
    /// </summary>

    class RegisterCashDepositResponseV2
    {
        public RegisterCashDepositResponse registerCashDepositResponse { get; set; }
        public string xlRequest { get; set; }
    }

    public class RegisterCashDepositResponse : RespHeader
    {
        public string fcdc { get; set; }
    }
    /// <summary>
    /// GenerateIICTypeResponse
    /// </summary>
    public class GenerateIICTypeResponse
    {
        public string iicSignature { get; set; }
        public string iic { get; set; }
    }
    /// <summary>
    /// GetTaxPayersResponse
    /// </summary>
    internal class TaxPayer
    {
        public string address { get; set; }
        public int country { get; set; }
        public string name { get; set; }
        public string tin { get; set; }
        public string town { get; set; }
    }
   

    internal class GetTaxPayersResponse:RespHeader
    {
        public List<TaxPayer> taxpayers { get; set; }
    }
    /// <summary>
    /// registerInvoiceResponse
    /// </summary>
    internal class registerInvoiceReponseV2
    {
        public RegisterInvoiceResponse registerInvoiceResponse { get; set; }
        public string xmlRequest { get; set; }
    }

    internal class RegisterInvoiceResponse : RespHeader 
    {
        public string fic { get; set; }
    }
}
