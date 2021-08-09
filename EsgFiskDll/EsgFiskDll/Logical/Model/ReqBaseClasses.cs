using EsgFiskDll.Classes;
using EsgFiskDll.Logical.ApiCalls;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsgFiskDll.Logical
{

    public class TCR
    {
        public string BusinUnitCode { get; set; }
        public string IssuerNUIS { get; set; }

        public string TCRIntID { get; set; }
        public string ValidFrom { get; set; }
        public bool ValidFromSpecified { get; set; }
    }

    public class CashDeposit
    {
        public double CashAmt { get; set; }
        public string ChangeDateTime { get; set; }
        public string IssuerNUIS { get; set; }
        public string Operation { get; set; }
        public string TCRCode { get; set; }

    }

    public class Invoice
    {
        public string BusinUnitCode { get; set; }
        public string IIC { get; set; }
        public string IICSignature { get; set; }
        public string InvOrdNum { get; set; }
        public int InvNum { get; set; }
        public bool IsEinvoice { get; set; }
        public bool IsIssuerInVAT { get; set; }
        public bool IsReverseCharge { get; set; }
        public bool IsSimplifiedInv { get; set; }
        public string IssueDateTime { get; set; }
        public string OperatorCode { get; set; }
        public string PayDeadline { get; set; }
        public string PayDeadlineSpecified { get; set; }
        public string TCRCode { get; set; }
        public double TotPrice { get; set; }
        public double TotPriceWoVAT { get; set; }
        public double TotVATAmt { get; set; }
        public double TotVATAmtSpecified { get; set; }
        public string TypeOfInv { get; set; }
        public List<Item> Items { get; set; }
        public List<PayMethod> PayMethods { get; set; }
        public List<SameTax> SameTaxes { get; set; }
        public Seller Seller { get; set; }
    }

    public class Item
    {
        public string C { get; set; }
        public string N { get; set; }
        public double PA { get; set; }
        public double PB { get; set; }
        public double Q { get; set; }
        public string U { get; set; }
        public double UPA { get; set; }
        public double UPB { get; set; }
        public double VA { get; set; }
        public bool VASpecified { get; set; }
        public double VR { get; set; }
        public bool VRSpecified { get; set; }

    }

    public class PayMethod
    {
        public double Amt { get; set; }
        public string Type { get; set; }
    }

    public class SameTax
    {
        public int NumOfItems { get; set; }
        public double PriceBefVAT { get; set; }
        public double VATAmt { get; set; }
        public bool VATAmtSpecified { get; set; }
        public double VATRate { get; set; }
        public bool VATRateSpecified { get; set; }

    }

    public class Seller
    {
        public string Address { get; set; }
        public string Country { get; set; }
        public bool CountrySpecified { get; set; }
        public string IDNum { get; set; }
        public string IDType { get; set; }
        public string Name { get; set; }
        public string Town { get; set; }
    }




    class RegisterCashDeskReq : RequestBase
    {
        public RegisterCashDeskReq(FiskConfigs Configs) : base(Configs)
        {

        }
        public TCR TCR { get; set; }

    }

    class RegisterCashDepositReq : RequestBase
    {
        public RegisterCashDepositReq(FiskConfigs Configs) : base(Configs)
        {

        }
        public CashDeposit CashDeposit { get; set; }
    }


    internal class GenerateIICTYPE
    {
        public GenerateIICTYPE(FiskConfigs configs)
        {
            IssuerNuis = configs.IssuerNUIS;
            IssuerDateTime = System.DateTime.UtcNow.ToString("O");
            BusinUnitCode = configs.BusinUnitCode;
            Certificate.CertificatePassword = configs.CertificatePassword;
            Certificate.CertificatePath = configs.CertificatePath;
        }
        string IssuerNuis { get; set; }
        string IssuerDateTime { get; set; }
        string InvNum { get; set; }
        string BusinUnitCode { get; set; }
        string TcrCode { get; set; }
        double TotPrice { get; set; }
        certificate Certificate { get; set; }
    }

}
