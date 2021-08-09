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
    public class EsgFisc
    {
        private SqlConnection conn { get; set; }
        private FiskConfigs configs { get; set; }
        private EsgFiskCalls FiscCalls { get; set; }
        public EsgFisc(SqlConnection _conn, int UserId )
        {
            configs = new FiskConfigs(_conn);

            switch (configs.fiscCompany)
            {
                case "LOGICAL":
                    FiscCalls = new EsgFiskCalls(conn, configs, UserId, new Logical.LogiFis());
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
    }
}
