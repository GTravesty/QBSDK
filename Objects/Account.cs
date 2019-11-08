using System;
using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public class Account : List
        {
            #region // PROPERTIES ///////////////////////////////////////////
            public AccountType? AccountType { get; set; }
            public SpecialAccountType? SpecialAccountType { get; set; }
            public string AccountNumber { get; set; }
            public string BankNumber { get; set; }
            public string Desc { get; set; }
            public decimal? Balance { get; set; }
            public decimal? TotalBalance { get; set; }
            private string TaxLineInfoRet;
            public int? TaxLineID { get; set; }
            public string TaxLineName { get; set; }
            public CashFlowClassification? CashFlowClassification { get; set; }
            public BaseRef CurrencyRef { get; set; }

            #endregion

            #region // CONSTRUCTORS /////////////////////////////////////////
            public Account() : this(null) { }
            public Account(XElement xElement) : base(xElement)
            {
                if (xElement == null)
                {
                    return;
                }
                AccountType = (AccountType?)xElement.Element(nameof(AccountType)).Parse<AccountType>();
                SpecialAccountType = (SpecialAccountType?)xElement.Element(nameof(SpecialAccountType)).Parse<SpecialAccountType>();
                AccountNumber = (string)xElement.Element(nameof(AccountNumber));
                BankNumber = (string)xElement.Element(nameof(BankNumber));
                Desc = (string)xElement.Element(nameof(Desc));
                Balance = (decimal?)xElement.Element(nameof(Balance));
                TotalBalance = (decimal?)xElement.Element(nameof(TotalBalance));
                TaxLineID = (int?)xElement.Element(nameof(TaxLineInfoRet))?.Element(nameof(TaxLineID));
                TaxLineName = (string)xElement.Element(nameof(TaxLineInfoRet))?.Element(nameof(TaxLineName));
                CashFlowClassification = (CashFlowClassification?)xElement.Element(nameof(CashFlowClassification)).Parse<CashFlowClassification>();
                CurrencyRef = (BaseRef)xElement.Element(nameof(CurrencyRef));
            }
            #endregion

            #region // METHODS //////////////////////////////////////////////
            public override XElement GenerateAddRq()
            {
                throw new NotImplementedException();
            }

            public override XElement GenerateModRq()
            {
                throw new NotImplementedException();
            }

            public override XElement GenerateDelRq()
            {
                throw new NotImplementedException();
            }
            #endregion
        }
    }
}