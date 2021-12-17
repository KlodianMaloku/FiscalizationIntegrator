using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using EsgFiskDll;
using EsgEslDll;
using EsgPeshoreDll;
using System.Threading.Tasks;
using System.Net;

public class EsgFisk
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
                EsgFisc FiscObj = new EsgFisc(conn, int.Parse(UserId.ToString()));
                response = FiscObj.registerCashDesk(int.Parse(CashDeskId.ToString()));
                return response;

            }
            catch (Exception ex)
            {
                return "600 -" + ex.Message;
            }

        }
    }
    [Microsoft.SqlServer.Server.SqlFunction(SystemDataAccess = SystemDataAccessKind.Read, DataAccess = DataAccessKind.Read)]
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
    [Microsoft.SqlServer.Server.SqlFunction(SystemDataAccess = SystemDataAccessKind.Read, DataAccess = DataAccessKind.Read)]
    public static SqlString GenerateIICType(SqlString InvoiceId, SqlString UserId)
    {
        using (SqlConnection conn = new SqlConnection("context connection=true"))
        {
            string response = "";
            try
            {
                conn.Open();
                EsgFisc FiscObj = new EsgFisc(conn, int.Parse(UserId.ToString()));
                response = FiscObj.GenerateIICType(int.Parse(InvoiceId.ToString()));

                return response;

            }
            catch (Exception ex)
            {
                return "600 -" + ex.Message;
            }
        }
    }
    [Microsoft.SqlServer.Server.SqlFunction(SystemDataAccess = SystemDataAccessKind.Read, DataAccess = DataAccessKind.Read)]
    public static SqlString GenerateIICQR(SqlString InvoiceId, SqlString UserId)
    {
        using (SqlConnection conn = new SqlConnection("context connection=true"))
        {
            string response = "";
            try
            {
                conn.Open();
                EsgFisc FiscObj = new EsgFisc(conn, int.Parse(UserId.ToString()));
                response = FiscObj.CalculateQRCode(int.Parse((string)InvoiceId));

                return response;

            }
            catch (Exception ex)
            {
                return "600 -" + ex.Message;
            }
        }
    }
    [Microsoft.SqlServer.Server.SqlFunction(SystemDataAccess = SystemDataAccessKind.Read, DataAccess = DataAccessKind.Read)]
    public static SqlString GetTaxpayers(SqlString TaxPayerNUIS, SqlString UserId)
    {
        using (SqlConnection conn = new SqlConnection("context connection=true"))
        {
            string response = "";
            try
            {
                conn.Open();
                EsgFisc FiscObj = new EsgFisc(conn, int.Parse(UserId.ToString()));
                response = FiscObj.getTaxPayer(TaxPayerNUIS.ToString());

                return response;

            }
            catch (Exception ex)
            {
                return "600 -" + ex.Message;
            }
        }
    }
    [Microsoft.SqlServer.Server.SqlFunction(SystemDataAccess = SystemDataAccessKind.Read, DataAccess = DataAccessKind.Read)]
    public static SqlString RegisterInvoice(SqlString InvoiceId, SqlString UserId)
    {
        using (SqlConnection conn = new SqlConnection("context connection=true"))
        {
            string response = "";
            try
            {
                conn.Open();
                EsgFisc FiscObj = new EsgFisc(conn, int.Parse(UserId.ToString()));
                response = FiscObj.registerInvoice(int.Parse((string)InvoiceId));

                return response;

            }
            catch (Exception ex)
            {
                return "600 -" + ex.Message;
            }
        }
    }
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlBytes GenerateQrCode(SqlString QrContent)
    {

        EsgTools Tools = new EsgTools();

        return new SqlBytes(Tools.GenerateQrCode(QrContent.ToString()));

    }

}


public class EsgEsl
{
    [Microsoft.SqlServer.Server.SqlFunction(SystemDataAccess = SystemDataAccessKind.Read, DataAccess = DataAccessKind.Read)]
    public  static SqlString SendItems()
    {
        using (SqlConnection conn = new SqlConnection("context connection=true"))
        {
            string response = "";
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            try
            {

                conn.Open();
                EslOps eslOps = new EslOps(conn);
                return eslOps.SendItems();

            }
            catch (Exception ex)
            {
                return "600 -" + ex.Message + "     " +  ex.StackTrace + "       " + ex.Source + "     " + ex.InnerException ;
            }

        }
    }
}

public class EsgPeshore
{
    [Microsoft.SqlServer.Server.SqlFunction(SystemDataAccess = SystemDataAccessKind.Read, DataAccess = DataAccessKind.Read)]
    public static SqlString SendItemsPeshore()
    {
        using (SqlConnection conn = new SqlConnection("context connection = true"))
        {
            PeshoreOps ops = new PeshoreOps(conn);
            return ops.SendItemsPeshore();
        }
    }
}