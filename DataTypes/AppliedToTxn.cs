using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public class AppliedToTxn : IQBXML
        {
            #region // PROPERTIES ///////////////////////////////////////////
            public string TxnID { get; set; }
            public TxnType TxnType { get; set; }
            public DateTime? TxnDate { get; set; }
            public string RefNumber { get; set; }
            public decimal? BalanceRemaining { get; set; }
            public decimal? Amount { get; set; }
            public decimal? DiscountAmount { get; set; }
            public BaseRef DiscountAccountRef { get; set; }
            public BaseRef DiscountClassRef { get; set; }
            public List<LinkedTxn> LinkedTxnList { get; set; }

            #endregion

            #region // CONSTRUCTORS /////////////////////////////////////////
            public AppliedToTxn() : this(null) { }
            public AppliedToTxn(XElement xElement)
            {
                if (xElement == null)
                {
                    return;
                }
                TxnID = (string)xElement.Element(nameof(TxnID));
                TxnType = (TxnType)xElement.Parse<TxnType>();
                TxnDate = (DateTime)xElement.Element(nameof(TxnDate));
                RefNumber = (string)xElement.Element(nameof(RefNumber));
                BalanceRemaining = (decimal)xElement.Element(nameof(BalanceRemaining));
                Amount = (decimal)xElement.Element(nameof(Amount));
                DiscountAmount = (decimal)xElement.Element(nameof(DiscountAmount));
                DiscountAccountRef = (BaseRef)xElement.Element(nameof(DiscountAccountRef));
                DiscountClassRef = (BaseRef)xElement.Element(nameof(DiscountClassRef));
                LinkedTxnList = (List<LinkedTxn>)xElement.Elements(nameof(LinkedTxnList));

            }
            #endregion

            #region // METHODS //////////////////////////////////////////////
            public XElement ToQBXML(string name)
            {
                XElement xElement = new XElement(name);
                xElement.Add(TxnID.ToQBXML(nameof(TxnID)));
                xElement.Add(TxnType.ToQBXML(nameof(TxnType)));
                xElement.Add(TxnDate?.ToQBXML(nameof(TxnDate)));
                xElement.Add(RefNumber.ToQBXML(nameof(RefNumber)));
                xElement.Add(BalanceRemaining?.ToQBXML(nameof(BalanceRemaining)));
                xElement.Add(Amount?.ToQBXML(nameof(Amount)));
                xElement.Add(DiscountAmount?.ToQBXML(nameof(DiscountAmount)));
                xElement.Add(DiscountAccountRef.ToQBXML(nameof(DiscountAccountRef)));
                xElement.Add(DiscountClassRef.ToQBXML(nameof(DiscountClassRef)));
                xElement.Add(LinkedTxnList.ToQBXML(nameof(LinkedTxn)));
                return xElement;
            }

            #endregion
        }
    }

}
