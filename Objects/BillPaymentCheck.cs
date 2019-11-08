using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public class BillPaymentCheck : Txn
        {
            #region // PROPERTIES ///////////////////////////////////////////
            private static TxnType TxnType = TxnType.BillPaymentCheck;

            public int? TxnNumber { get; set; }
            public BaseRef PayeeEntityRef { get; set; }
            public BaseRef APAccountRef { get; set; }
            public BaseRef BankAccountRef { get; set; }
            public decimal? Amount { get; set; }
            public BaseRef CurrencyRef { get; set; }
            public float? ExchangeRate { get; set; }
            public decimal? AmountInHomeCurrency { get; set; }
            public string RefNumber { get; set; }
            public string Memo { get; set; }
            public Address Address { get; set; }
            public bool? IsToBePrinted { get; set; }
            public string ExternalGUID { get; set; }
            public List<AppliedToTxn> AppliedToTxnList { get; set; }
            public List<DataExt> DataExtList { get; set; }

            #endregion

            #region // CONSTRUCTORS /////////////////////////////////////////
            public BillPaymentCheck() : this(null) { }
            public BillPaymentCheck(XElement xElement)
            {
                if (xElement == null)
                {
                    return;
                }
                TxnID = (string)xElement.Element(nameof(TxnID));
                TimeCreated = (DateTime)xElement.Element(nameof(TimeCreated));
                TimeModified = (DateTime)xElement.Element(nameof(TimeModified));
                EditSequence = (string)xElement.Element(nameof(EditSequence));
                TxnNumber = (int)xElement.Element(nameof(TxnNumber));
                PayeeEntityRef = (BaseRef)xElement.Element(nameof(PayeeEntityRef));
                APAccountRef = (BaseRef)xElement.Element(nameof(APAccountRef));
                TxnDate = (DateTime)xElement.Element(nameof(TxnDate));
                BankAccountRef = (BaseRef)xElement.Element(nameof(BankAccountRef));
                Amount = (decimal)xElement.Element(nameof(Amount));
                CurrencyRef = (BaseRef)xElement.Element(nameof(CurrencyRef));
                ExchangeRate = (float)xElement.Element(nameof(ExchangeRate));
                AmountInHomeCurrency = (decimal)xElement.Element(nameof(AmountInHomeCurrency));
                RefNumber = (string)xElement.Element(nameof(RefNumber));
                Memo = (string)xElement.Element(nameof(Memo));
                Address = (Address)xElement.Element(nameof(Address));
                IsToBePrinted = (bool)xElement.Element(nameof(IsToBePrinted));
                ExternalGUID = (string)xElement.Element(nameof(ExternalGUID));
                AppliedToTxnList = (List<AppliedToTxn>)xElement.Elements(nameof(AppliedToTxnList));
                DataExtList = (List<DataExt>)xElement.Elements(nameof(DataExtList));

            }
            #endregion

            #region // METHODS //////////////////////////////////////////////
            public override XElement GenerateAddRq()
            {
                XElement xElement = new XElement(nameof(BillPaymentCheck) + "Add");
                xElement.Add(TxnID?.ToQBXML(nameof(TxnID)));
                xElement.Add(TimeCreated?.ToQBXML(nameof(TimeCreated)));
                xElement.Add(TimeModified?.ToQBXML(nameof(TimeModified)));
                xElement.Add(EditSequence?.ToQBXML(nameof(EditSequence)));
                xElement.Add(TxnNumber?.ToQBXML(nameof(TxnNumber)));
                xElement.Add(PayeeEntityRef?.ToQBXML(nameof(PayeeEntityRef)));
                xElement.Add(APAccountRef?.ToQBXML(nameof(APAccountRef)));
                xElement.Add(TxnDate?.ToQBXML(nameof(TxnDate)));
                xElement.Add(BankAccountRef?.ToQBXML(nameof(BankAccountRef)));
                xElement.Add(Amount?.ToQBXML(nameof(Amount)));
                xElement.Add(CurrencyRef?.ToQBXML(nameof(CurrencyRef)));
                xElement.Add(ExchangeRate?.ToQBXML(nameof(ExchangeRate)));
                xElement.Add(AmountInHomeCurrency?.ToQBXML(nameof(AmountInHomeCurrency)));
                xElement.Add(RefNumber?.ToQBXML(nameof(RefNumber)));
                xElement.Add(Memo?.ToQBXML(nameof(Memo)));
                xElement.Add(Address?.ToQBXML(nameof(Address)));
                xElement.Add(IsToBePrinted?.ToQBXML(nameof(IsToBePrinted)));
                xElement.Add(ExternalGUID?.ToQBXML(nameof(ExternalGUID)));
                xElement.Add(AppliedToTxnList?.ToQBXML(nameof(AppliedToTxnList)));
                xElement.Add(DataExtList?.ToQBXML(nameof(DataExtList)));

                return xElement;
            }

            public override XElement GenerateModRq()
            {
                return GenerateModRq(null);
            }
            public XElement GenerateModRq(bool? ClearExpenseLines = null)
            {
                XElement xElement = new XElement(nameof(BillPaymentCheck) + "Mod");
                xElement.Add(TxnID?.ToQBXML(nameof(TxnID)));
                xElement.Add(TimeCreated?.ToQBXML(nameof(TimeCreated)));
                xElement.Add(TimeModified?.ToQBXML(nameof(TimeModified)));
                xElement.Add(EditSequence?.ToQBXML(nameof(EditSequence)));
                xElement.Add(TxnNumber?.ToQBXML(nameof(TxnNumber)));
                xElement.Add(PayeeEntityRef?.ToQBXML(nameof(PayeeEntityRef)));
                xElement.Add(APAccountRef?.ToQBXML(nameof(APAccountRef)));
                xElement.Add(TxnDate?.ToQBXML(nameof(TxnDate)));
                xElement.Add(BankAccountRef?.ToQBXML(nameof(BankAccountRef)));
                xElement.Add(Amount?.ToQBXML(nameof(Amount)));
                xElement.Add(CurrencyRef?.ToQBXML(nameof(CurrencyRef)));
                xElement.Add(ExchangeRate?.ToQBXML(nameof(ExchangeRate)));
                xElement.Add(AmountInHomeCurrency?.ToQBXML(nameof(AmountInHomeCurrency)));
                xElement.Add(RefNumber?.ToQBXML(nameof(RefNumber)));
                xElement.Add(Memo?.ToQBXML(nameof(Memo)));
                xElement.Add(Address?.ToQBXML(nameof(Address)));
                xElement.Add(IsToBePrinted?.ToQBXML(nameof(IsToBePrinted)));
                xElement.Add(ExternalGUID?.ToQBXML(nameof(ExternalGUID)));
                xElement.Add(AppliedToTxnList?.ToQBXML(nameof(AppliedToTxnList)));
                xElement.Add(DataExtList?.ToQBXML(nameof(DataExtList)));

                return xElement;
            }

            public override XElement GenerateDelRq()
            {
                XElement xElement = new XElement("TxnDelRq");
                xElement.Add(TxnType.ToQBXML("TxnDelType"));
                xElement.Add(TxnID.ToQBXML(nameof(TxnID)));
                return xElement;
            }

            public XElement GenerateVoidRq()
            {
                XElement xElement = new XElement("TxnVoidRq");
                xElement.Add(TxnType.ToQBXML("TxnVoidType"));
                xElement.Add(TxnID.ToQBXML(nameof(TxnID)));
                return xElement;
            }

            #endregion
        }
    }

}
