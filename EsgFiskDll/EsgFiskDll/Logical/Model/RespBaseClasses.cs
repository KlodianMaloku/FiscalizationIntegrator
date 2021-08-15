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

    public class RegisterCashDeskResponse:RespHeader
    {
        public string tcrCode { get; set; }
    }

    public class RegisterCashDepositReponse : RespHeader
    {
        public string fcdc { get; set; }
    }

    public class GenerateIICTypeResponse
    {
        public string iicSignature { get; set; }
        public string iic { get; set; }
    }

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

    internal class RegisterInvoiceReponse : RespHeader 
    {
        public string fic { get; set; }
    }
}
