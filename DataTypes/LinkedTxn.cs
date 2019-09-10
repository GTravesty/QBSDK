using System;
using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public class LinkedTxn : IQBXML
        {
            #region // PROPERTIES ///////////////////////////////////////////
            public string TxnID { get; set; }
            public TxnType TxnType { get; set; }
            public DateTime TxnDate { get; set; }
            public string RefNumber { get; set; }
            public LinkType LinkType { get; set; }
            public decimal Amount { get; set; }
            #endregion

            #region // CONSTRUCTORS /////////////////////////////////////////
            public LinkedTxn() : this(null) { }
            public LinkedTxn(XElement xElement)
            {
                TxnID = (string)xElement.Element(nameof(TxnID));
                TxnType = (TxnType)xElement.Parse<TxnType>();
                TxnDate = (DateTime)xElement.Element(nameof(TxnDate));
                RefNumber = (string)xElement.Element(nameof(RefNumber));
                LinkType =(LinkType)xElement.Parse<LinkType>();
                Amount = (decimal)xElement.Element(nameof(Amount));
            }

            public static explicit operator LinkedTxn(XElement xElement)
            {
                if(xElement == null)
                {
                    return null;
                }
                return new LinkedTxn(xElement);
            }
            #endregion

            #region // METHODS //////////////////////////////////////////////
            public XElement ToQBXML(string name)
            {
                XElement xElement = new XElement(name);
                xElement.Add(TxnID.ToQBXML(nameof(TxnID)));
                xElement.Add(TxnType.ToQBXML(nameof(TxnType)));
                xElement.Add(TxnDate.ToQBXML(nameof(TxnDate)));
                xElement.Add(RefNumber.ToQBXML(nameof(RefNumber)));
                xElement.Add(Amount.ToQBXML(nameof(Amount)));

                return xElement;
            }
            #endregion
        }
    }
}