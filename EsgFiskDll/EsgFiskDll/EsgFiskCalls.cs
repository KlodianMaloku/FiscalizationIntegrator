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
    }
}
