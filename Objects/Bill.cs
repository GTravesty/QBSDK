using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public class Bill : QBTransaction, IVoidRq
        {
            #region // PROPERTIES ///////////////////////////////////////////
            private static TxnType TxnDelType = TxnType.Bill;
            private static TxnType TxnVoidType = TxnType.Bill;

            public string TxnNumber { get; set; }
            public BaseRef VendorRef { get; set; }
            public Address VendorAddress { get; set; }
            public BaseRef APAccountRef { get; set; }
            public DateTime? DueDate { get; set; }
            public string RefNumber { get; set; }
            public decimal? AmountDue { get; set; }
            public BaseRef CurrencyRef { get; set; }
            public float? ExchangeRate { get; set; }
            public decimal? AmountDueInHomeCurrency { get; set; }
            public BaseRef TermsRef { get; set; }
            public string Memo { get; set; }
            public bool? IsPaid { get; set; }
            public string ExternalGUID { get; set; }
            public List<LinkedTxn> LinkedTxn { get; set; }
            public List<ExpenseLine> ExpenseLine { get; set; }
            public List<IItemLine> ItemLine { get; set; }
            #endregion

            #region // CONSTRUCTORS /////////////////////////////////////////
            public Bill() : this(null) { }
            public Bill(XElement xElement)
            {
                if(xElement == null)
                {
                    return;
                }
                TxnID = (string)xElement.Element(nameof(TxnID));
                TimeCreated = (DateTime?)xElement.Element(nameof(TimeCreated));
                TimeModified = (DateTime?)xElement.Element(nameof(TimeModified));
                EditSequence = (string)xElement.Element(nameof(EditSequence));
                TxnNumber = (string)xElement.Element(nameof(TxnNumber));
                VendorRef = (BaseRef)xElement.Element(nameof(VendorRef));
                VendorAddress = (Address)xElement.Element(nameof(VendorAddress));
                APAccountRef = (BaseRef)xElement.Element(nameof(APAccountRef));
                TxnDate = (DateTime?)xElement.Element(nameof(TxnDate));
                DueDate = (DateTime?)xElement.Element(nameof(DueDate));
                AmountDue = (decimal?)xElement.Element(nameof(AmountDue));
                CurrencyRef = (BaseRef)xElement.Element(nameof(CurrencyRef));
                ExchangeRate = (float?)xElement.Element(nameof(ExchangeRate));
                AmountDueInHomeCurrency = (decimal?)xElement.Element(nameof(AmountDueInHomeCurrency));
                RefNumber = (string)xElement.Element(nameof(RefNumber));
                TermsRef = (BaseRef)xElement.Element(nameof(TermsRef));
                Memo = (string)xElement.Element(nameof(Memo));
                IsPaid = (bool?)xElement.Element(nameof(IsPaid));
                ExternalGUID = (string)xElement.Element(nameof(ExternalGUID));
                LinkedTxn = (List<LinkedTxn>)xElement.Elements(nameof(LinkedTxn));
                ExpenseLine = (List<ExpenseLine>)xElement.Elements(nameof(ExpenseLine) + "Ret");
                ItemLine = (List<IItemLine>)xElement.Elements(nameof(ItemLine) + "Ret");
            }
            #endregion

            #region // METHODS //////////////////////////////////////////////
            public override XElement GenerateAddRq()
            {
                XElement xElement = new XElement(nameof(Bill) + "Add");
                xElement.Add(VendorRef?.ToQBXML(nameof(VendorRef)));
                xElement.Add(VendorAddress?.ToQBXML(nameof(VendorAddress)));
                xElement.Add(APAccountRef?.ToQBXML(nameof(APAccountRef)));
                xElement.Add(TxnDate?.ToQBXML(nameof(TxnDate)));
                xElement.Add(DueDate?.ToQBXML(nameof(DueDate)));
                xElement.Add(RefNumber?.ToQBXML(nameof(RefNumber)));
                xElement.Add(TermsRef?.ToQBXML(nameof(TermsRef)));
                xElement.Add(Memo?.ToQBXML(nameof(Memo)));
                xElement.Add(ExchangeRate?.ToQBXML(nameof(ExchangeRate)));
                xElement.Add(ExternalGUID?.ToQBXML(nameof(ExternalGUID)));
                xElement.Add(LinkedTxn?.ToIDList("LinkToTxnID")); // TODO: Better way to structure this?
                xElement.Add(ExpenseLine?.GenerateAddRq<ExpenseLine>());
                xElement.Add(ItemLine.GenerateAddRq<IItemLine>());

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
                xElement.Add(EditSequence?.ToQBXML(nameof(EditSequence)));
                xElement.Add(VendorRef?.ToQBXML(nameof(VendorRef)));
                xElement.Add(VendorAddress?.ToQBXML(nameof(VendorAddress)));
                xElement.Add(APAccountRef?.ToQBXML(nameof(APAccountRef)));
                xElement.Add(TxnDate?.ToQBXML(nameof(TxnDate)));
                xElement.Add(DueDate?.ToQBXML(nameof(DueDate)));
                xElement.Add(RefNumber?.ToQBXML(nameof(RefNumber)));
                xElement.Add(TermsRef?.ToQBXML(nameof(TermsRef)));
                xElement.Add(Memo?.ToQBXML(nameof(Memo)));
                xElement.Add(ExchangeRate?.ToQBXML(nameof(ExchangeRate)));
                xElement.Add(ClearExpenseLines?.ToQBXML(nameof(ClearExpenseLines)));
                xElement.Add(ExpenseLine?.GenerateModRq<ExpenseLine>());
                xElement.Add(ItemLine.GenerateModRq<IItemLine>());

                return xElement;
            }

            public override XElement GenerateDelRq()
            {
                XElement xElement = new XElement("TxnDelRq");
                xElement.Add(TxnDelType.ToQBXML(nameof(TxnDelType)));
                xElement.Add(TxnID.ToQBXML(nameof(TxnID)));
                return xElement;
            }

            public XElement GenerateVoidRq()
            {
                XElement xElement = new XElement("TxnVoidRq");
                xElement.Add(TxnVoidType.ToQBXML(nameof(TxnVoidType)));
                xElement.Add(TxnID.ToQBXML(nameof(TxnID)));
                return xElement;
            }

            #endregion
        }
    }

}