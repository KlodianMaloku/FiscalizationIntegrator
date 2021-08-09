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

}
