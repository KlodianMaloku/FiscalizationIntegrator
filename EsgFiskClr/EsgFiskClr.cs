using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using EsgFiskDll;

public partial class EsgFisk
{
    [Microsoft.SqlServer.Server.SqlFunction(SystemDataAccess = SystemDataAccessKind.Read, DataAccess = DataAccessKind.Read)]
    public static SqlString RegisterCashDesk(SqlString CashDeskId, SqlString UserId)
    {
        using (SqlConnection conn = new SqlConnection("context connection=true"))
        {
            string response = "";
            try
            {

                conn.Open();
                EsgFisc FiscObj = new EsgFisc(conn,int.Parse(UserId.ToString()));
                response = FiscObj.registerCashDesk(int.Parse((string)CashDeskId));

                return response;

            }
            catch(Exception ex)
            {
                return "600 -" + ex.Message;
            }
        }
    }

    public static SqlString RegisterCashDeposit(SqlString CashDepositId, SqlString UserId)
    {
        using (SqlConnection conn = new SqlConnection("context connection=true"))
        {
            string response = "";
            try
            {

                conn.Open();
                EsgFisc FiscObj = new EsgFisc(conn, int.Parse(UserId.ToString()));
                response = FiscObj.registerCashDeposit(int.Parse((string)CashDepositId));

                return response;

            }
            catch (Exception ex)
            {
                return "600 -" + ex.Message;
            }
        }
    }
}
