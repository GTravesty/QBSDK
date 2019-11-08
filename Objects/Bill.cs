using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public class Bill : Txn, IVoidRq
        {
            #region // PROPERTIES ///////////////////////////////////////////
            private static TxnType TxnType = TxnType.Bill;

            public int? TxnNumber { get; set; }
            public BaseRef VendorRef { get; set; }
            public Address VendorAddress { get; set; }
            public BaseRef APAccountRef { get; set; }
            public DateTime? DueDate { get; set; }
            public decimal? AmountDue { get; set; }
            public BaseRef CurrencyRef { get; set; }
            public float? ExchangeRate { get; set; }
            public decimal? AmountDueInHomeCurrency { get; set; }
            public string RefNumber { get; set; }
            public BaseRef TermsRef { get; set; }
            public string Memo { get; set; }
            public bool? IsTaxIncluded { get; set; }
            public BaseRef SalesTaxCodeRef { get; set; }
            public bool? IsPaid { get; set; }
            public string ExternalGUID { get; set; }
            public List<LinkedTxn> LinkedTxnList { get; set; }
            public List<ExpenseLine> ExpenseLineList { get; set; }
            public List<ItemLine> ItemLineList { get; set; }
            public decimal? OpenAmount { get; set; }
            public List<DataExt> DataExtList { get; set; }

            #endregion

            #region // CONSTRUCTORS /////////////////////////////////////////
            public Bill() : this(null) { }
            public Bill(XElement xElement)
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
                VendorRef = (BaseRef)xElement.Element(nameof(VendorRef));
                VendorAddress = (Address)xElement.Element(nameof(VendorAddress));
                APAccountRef = (BaseRef)xElement.Element(nameof(APAccountRef));
                TxnDate = (DateTime)xElement.Element(nameof(TxnDate));
                DueDate = (DateTime)xElement.Element(nameof(DueDate));
                AmountDue = (decimal)xElement.Element(nameof(AmountDue));
                CurrencyRef = (BaseRef)xElement.Element(nameof(CurrencyRef));
                ExchangeRate = (float)xElement.Element(nameof(ExchangeRate));
                AmountDueInHomeCurrency = (decimal)xElement.Element(nameof(AmountDueInHomeCurrency));
                RefNumber = (string)xElement.Element(nameof(RefNumber));
                TermsRef = (BaseRef)xElement.Element(nameof(TermsRef));
                Memo = (string)xElement.Element(nameof(Memo));
                IsTaxIncluded = (bool)xElement.Element(nameof(IsTaxIncluded));
                SalesTaxCodeRef = (BaseRef)xElement.Element(nameof(SalesTaxCodeRef));
                IsPaid = (bool)xElement.Element(nameof(IsPaid));
                ExternalGUID = (string)xElement.Element(nameof(ExternalGUID));
                LinkedTxnList = (List<LinkedTxn>)xElement.Elements(nameof(LinkedTxnList));
                ExpenseLineList = (List<ExpenseLine>)xElement.Elements(nameof(ExpenseLineList));
                ItemLineList = (List<ItemLine>)xElement.Elements(nameof(ItemLineList));
                OpenAmount = (decimal)xElement.Element(nameof(OpenAmount));
                DataExtList = (List<DataExt>)xElement.Elements(nameof(DataExtList));

            }
            #endregion

            #region // METHODS //////////////////////////////////////////////
            public override XElement GenerateAddRq()
            {
                XElement xElement = new XElement(nameof(Bill) + "Add");
                xElement.Add(TxnID?.ToQBXML(nameof(TxnID)));
                xElement.Add(TimeCreated?.ToQBXML(nameof(TimeCreated)));
                xElement.Add(TimeModified?.ToQBXML(nameof(TimeModified)));
                xElement.Add(EditSequence?.ToQBXML(nameof(EditSequence)));
                xElement.Add(TxnNumber?.ToQBXML(nameof(TxnNumber)));
                xElement.Add(VendorRef?.ToQBXML(nameof(VendorRef)));
                xElement.Add(VendorAddress?.ToQBXML(nameof(VendorAddress)));
                xElement.Add(APAccountRef?.ToQBXML(nameof(APAccountRef)));
                xElement.Add(TxnDate?.ToQBXML(nameof(TxnDate)));
                xElement.Add(DueDate?.ToQBXML(nameof(DueDate)));
                xElement.Add(AmountDue?.ToQBXML(nameof(AmountDue)));
                xElement.Add(CurrencyRef?.ToQBXML(nameof(CurrencyRef)));
                xElement.Add(ExchangeRate?.ToQBXML(nameof(ExchangeRate)));
                xElement.Add(AmountDueInHomeCurrency?.ToQBXML(nameof(AmountDueInHomeCurrency)));
                xElement.Add(RefNumber?.ToQBXML(nameof(RefNumber)));
                xElement.Add(TermsRef?.ToQBXML(nameof(TermsRef)));
                xElement.Add(Memo?.ToQBXML(nameof(Memo)));
                xElement.Add(IsTaxIncluded?.ToQBXML(nameof(IsTaxIncluded)));
                xElement.Add(SalesTaxCodeRef?.ToQBXML(nameof(SalesTaxCodeRef)));
                xElement.Add(IsPaid?.ToQBXML(nameof(IsPaid)));
                xElement.Add(ExternalGUID?.ToQBXML(nameof(ExternalGUID)));
                xElement.Add(LinkedTxnList?.ToQBXML(nameof(LinkedTxnList)));
                xElement.Add(ExpenseLineList?.ToQBXML(nameof(ExpenseLineList)));
                xElement.Add(ItemLineList?.ToQBXML(nameof(ItemLineList)));
                xElement.Add(OpenAmount?.ToQBXML(nameof(OpenAmount)));
                xElement.Add(DataExtList?.ToQBXML(nameof(DataExtList)));

                return xElement;
            }

            public override XElement GenerateModRq()
            {
                return GenerateModRq(null);
            }
            public XElement GenerateModRq(bool? ClearExpenseLines = null)
            {
                XElement xElement = new XElement(nameof(Bill) + "Mod");
                xElement.Add(TxnID?.ToQBXML(nameof(TxnID)));
                xElement.Add(TimeCreated?.ToQBXML(nameof(TimeCreated)));
                xElement.Add(TimeModified?.ToQBXML(nameof(TimeModified)));
                xElement.Add(EditSequence?.ToQBXML(nameof(EditSequence)));
                xElement.Add(TxnNumber?.ToQBXML(nameof(TxnNumber)));
                xElement.Add(VendorRef?.ToQBXML(nameof(VendorRef)));
                xElement.Add(VendorAddress?.ToQBXML(nameof(VendorAddress)));
                xElement.Add(APAccountRef?.ToQBXML(nameof(APAccountRef)));
                xElement.Add(TxnDate?.ToQBXML(nameof(TxnDate)));
                xElement.Add(DueDate?.ToQBXML(nameof(DueDate)));
                xElement.Add(AmountDue?.ToQBXML(nameof(AmountDue)));
                xElement.Add(CurrencyRef?.ToQBXML(nameof(CurrencyRef)));
                xElement.Add(ExchangeRate?.ToQBXML(nameof(ExchangeRate)));
                xElement.Add(AmountDueInHomeCurrency?.ToQBXML(nameof(AmountDueInHomeCurrency)));
                xElement.Add(RefNumber?.ToQBXML(nameof(RefNumber)));
                xElement.Add(TermsRef?.ToQBXML(nameof(TermsRef)));
                xElement.Add(Memo?.ToQBXML(nameof(Memo)));
                xElement.Add(IsTaxIncluded?.ToQBXML(nameof(IsTaxIncluded)));
                xElement.Add(SalesTaxCodeRef?.ToQBXML(nameof(SalesTaxCodeRef)));
                xElement.Add(IsPaid?.ToQBXML(nameof(IsPaid)));
                xElement.Add(ExternalGUID?.ToQBXML(nameof(ExternalGUID)));
                xElement.Add(LinkedTxnList?.ToQBXML(nameof(LinkedTxnList)));
                xElement.Add(ExpenseLineList?.ToQBXML(nameof(ExpenseLineList)));
                xElement.Add(ItemLineList?.ToQBXML(nameof(ItemLineList)));
                xElement.Add(OpenAmount?.ToQBXML(nameof(OpenAmount)));
                xElement.Add(DataExtList?.ToQBXML(nameof(DataExtList)));

                return xElement;
            }

            public override XElement GenerateDelRq()
            {
                XElement xElement = new XElement("TxnDelRq");
                xElement.Add(TxnType.ToQBXML(nameof(TxnType)));
                xElement.Add(TxnID.ToQBXML(nameof(TxnID)));
                return xElement;
            }

            public XElement GenerateVoidRq()
            {
                XElement xElement = new XElement("TxnVoidRq");
                xElement.Add(TxnType.ToQBXML(nameof(TxnType)));
                xElement.Add(TxnID.ToQBXML(nameof(TxnID)));
                return xElement;
            }

            #endregion
        }
    }

}
