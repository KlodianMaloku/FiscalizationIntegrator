using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsgFiskDll.DevPos
{
    public class constants
    {
        public static IDictionary<string, int> cashDepositTypes = new Dictionary<string, int>()
        {
            {"INITIAL" , 0},
            {"WITHDRAW", 1 },
            {"DEPOSIT", 2 }
        };
    }
}
