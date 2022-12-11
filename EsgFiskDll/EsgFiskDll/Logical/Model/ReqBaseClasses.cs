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

    internal class TCR
    {
        public string BusinUnitCode { get; set; }
        public string IssuerNUIS { get; set; }
        public string TCRIntID { get; set; }
        public string Type { get; set; }
        public string ValidFrom { get; set; }
        public bool ValidFromSpecified { get; set; }
    }

    internal class CashDeposit
    {
        public double CashAmt { get; set; }
        public string ChangeDateTime { get; set; }
        public string IssuerNUIS { get; set; }
        public string Operation { get; set; }
        public string TCRCode { get; set; }

    }

    internal class note
    {
        public string IIC { get; set; }
        public string IICSignature { get; set; }
        public string FIC { get; set; }
        public string IssueDateTime { get; set;}
        public string UUID { get; set; }
        public string Currency { get; set; }
        public string OperatorCode { get; set; }
        public string BusinessUnitCode { get; set; }
        public string SoftwareCode { get; set; }
    }

    internal class EndpointID
    {
        public string Text { get; set; }
    }
    internal class PartyName
    {
        public string Name { get; set; }
    }
    internal class Country
    {
        public string IdentificationCode { get; set; }
    }
    internal class PostalAddress
    {
        public string Streetname { get; set; }
        public string CityName { get; set; }
        public Country Country { get; set; }
    }
    internal class TaxScheme
    {
        public string ID { get; set; }
    }
    internal class PartyTaxScheme
    {
        public string CompanyID { get; set; }
        public TaxScheme TaxScheme { get; set; }

    }
    internal class PartyLegalEntity
    {
        public string RegistrationName { get; set; }
        public string CompanyID { get; set; }
    }
    internal class Party
    {
        public EndpointID EndpointID { get; set; }
        public PartyName PartyName { get; set; }
        public PostalAddress PostalAddress { get; set; }
        public PartyTaxScheme PartyTaxScheme { get; set; }
        public PartyLegalEntity PartyLegalEntity { get; set; }
    }
    internal class AccountingSupplierParty
    {
        public Party Party { get; set; }
    }
    internal class UblInvoice
    {
        public string ProfileID { get; set; }
        public string ID { get; set; }
        public string IssueDate { get; set; }
        public string DueDate { get; set; }
        public string InvoiceTypeCode { get; set; }
        public note Note { get; set; }
        public string DocumentCurrencyCode { get; set; }

    }
    class SumInvIICRefs
    {
        public string IIC { get; set; }
        public string IssueDateTime { get; set; }
    }
    class SupplyDateOrPeriod
    {
        public string End { get; set; }
        public string Start { get; set; }
    }
    internal class Invoice
    {
        public string BusinUnitCode { get; set; }
        public string IIC { get; set; }
        public string IICSignature { get; set; }
        public Int64 InvOrdNum { get; set; }
        public string InvNum { get; set; }
        public bool IsEinvoice { get; set; }
        public bool IsIssuerInVAT { get; set; }
        public bool IsReverseCharge { get; set; }
        public bool IsSimplifiedInv { get; set; }
        public string IssueDateTime { get; set; }
        public string OperatorCode { get; set; }
        public string PayDeadline { get; set; }
        public bool PayDeadlineSpecified { get; set; }
        public string TCRCode { get; set; }
        public double TotPrice { get; set; }
        public double TotPriceWoVAT { get; set; }
        public double TotVATAmt { get; set; }
        public bool TotVATAmtSpecified { get; set; }
        public string TypeOfInv { get; set; }
        public Buyer Buyer { get; set; }
        public List<Item> Items { get; set; }
        public List<PayMethod> PayMethods { get; set; }
        public List<SameTax> SameTaxes { get; set; }
        public Seller Seller { get; set; }
    }

    internal class Buyer
    {
        public string Address { get; set; }
        public string Country { get; set; }
        public bool CountrySpecified { get; set; }
        public string IDNum { get; set; }
        public string IDType { get; set; }
        public string Name { get; set; }
        public string Town { get; set; }
    }

    internal class Item
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

    internal class PayMethod
    {
        public double Amt { get; set; }
        public string Type { get; set; }
    }

    internal class SameTax
    {
        public int NumOfItems { get; set; }
        public double PriceBefVAT { get; set; }
        public double VATAmt { get; set; }
        public bool VATAmtSpecified { get; set; }
        public double VATRate { get; set; }
        public bool VATRateSpecified { get; set; }

    }

    internal class Seller
    {
        public string Address { get; set; }
        public string Country { get; set; }
        public bool CountrySpecified { get; set; }
        public string IDNum { get; set; }
        public string IDType { get; set; }
        public string Name { get; set; }
        public string Town { get; set; }
    }

    internal class RegisterInvoiceReq : RequestBase
    {
        public RegisterInvoiceReq(FiskConfigs Configs):base(Configs)
        {

        }
        public Invoice Invoice { get; set; }
    }

    internal class RegisterCashDeskReq : RequestBase
    {
        public RegisterCashDeskReq(FiskConfigs Configs) : base(Configs)
        {

        }
        public TCR TCR { get; set; }

    }

    internal class RegisterCashDepositReq : RequestBase
    {
        public RegisterCashDepositReq(FiskConfigs Configs) : base(Configs)
        {

        }
        public CashDeposit CashDeposit { get; set; }
    }

    internal class GenerateIICTYPEReq
    {
        public GenerateIICTYPEReq(FiskConfigs configs)
        {
            IssuerNuis = configs.IssuerNUIS;
            IssueDateTime = System.DateTime.UtcNow.ToString("o");
            BusinUnitCode = configs.BusinUnitCode;
            Certificate = new certificate
            {
                CertificatePassword = configs.CertificatePassword,
                CertificatePath = configs.CertificatePath,
                CertificateData = configs.CertificateData
            };

            IsServiceTest = configs.IsServiceTest;
        }
        public string IssuerNuis { get; set; }
        public string IssueDateTime { get; set; }
        public string InvNum { get; set; }
        public string BusinUnitCode { get; set; }
        public string TcrCode { get; set; }
        public double TotPrice { get; set; }
        public certificate Certificate { get; set; }
        public bool IsServiceTest { get; set; }
    }

    internal class CalculateQRCodeReq
    {
        public CalculateQRCodeReq(FiskConfigs configs)
        {
            IssuerNuis = configs.IssuerNUIS;
            IssueDateTime = System.DateTime.UtcNow.ToString("O");
            IsServiceTest = configs.IsServiceTest;
        }
        public string IIC { get; set; }
        public string IssuerNuis { get; set; }
        public string IssueDateTime { get; set; }
        public Int32 InvOrdNum { get; set; }
        public string  TcrCode { get; set; }
        public double TotPrice { get; set; }
        public bool IsServiceTest { get; set; }
    }

    internal class GetTaxPayerFilter
    {
        public string Tin { get; set; }
    }

    internal class GetTaxPayersReq:RequestBase
    {
        public GetTaxPayersReq(FiskConfigs Configs) : base(Configs)
        {

        }
        public GetTaxPayerFilter Filter { get; set; }
    }

}
