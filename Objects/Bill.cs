using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public class Bill : QBTransaction
        {
            public int? TxnNumber { get; set; }
            public BaseRef VendorRef { get; set; }
            public Address VendorAddress { get; set; }
            public BaseRef APAccountRef { get; set; }
            public DateTime? DueDate { get; set; }
            public decimal? AmountDue { get; set; }
            public BaseRef CurrencyRef { get; set; }
            public float? ExchangeRate { get; set; }
            public decimal? AmountDueInHomeCurrency { get; set; }
            public BaseRef TermsRef { get; set; }
            public string Memo { get; set; }
            public bool? IsPaid { get; set; }
            public string ExternalGUID { get; set; }
            public List<Txn> LinkedTxn { get; set; }
            public List<ExpenseLine> ExpenseLine { get; set; }
            public List<ItemLine> ItemLine { get; set; }

            public override XElement GenerateAddRq()
            {
                XElement xElement = new XElement("BillAdd");
                xElement.Add(VendorRef?.ToQBXML(nameof(VendorRef)));
                xElement.Add(APAccountRef?.ToQBXML(nameof(APAccountRef)));
                xElement.Add(TxnDate?.ToQBXML(nameof(TxnDate)));
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
        }
    }

}