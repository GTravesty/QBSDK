using System;
using System.Collections.Generic;
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
            public LinkType? LinkType { get; set; }
            public decimal Amount { get; set; }
            #endregion

            #region // CONSTRUCTORS /////////////////////////////////////////
            public LinkedTxn() : this(null) { }
            public LinkedTxn(XElement xElement)
            {
                if (xElement == null)
                {
                    return;
                }
                TxnID = (string)xElement.Element(nameof(TxnID));
                TxnType = (TxnType)xElement.Parse<TxnType>();
                TxnDate = (DateTime)xElement.Element(nameof(TxnDate));
                RefNumber = (string)xElement.Element(nameof(RefNumber));
                LinkType = (LinkType?)xElement.Parse<LinkType>();
                Amount = (decimal)xElement.Element(nameof(Amount));
            }

            public static explicit operator LinkedTxn(XElement xElement)
            {
                if (xElement == null)
                {
                    return null;
                }
                return new LinkedTxn(xElement);
            }
            #endregion

            #region // METHODS //////////////////////////////////////////////
            public XElement ToQBXML(string name)
            {
                return new XElement(name, TxnID);
            }
            #endregion
        }
        public static List<XElement> ToIDList(this List<LinkedTxn> values, string name)
        {
            if (values == null)
            {
                return null;
            }
            List<XElement> xElements = new List<XElement>();
            foreach (LinkedTxn value in values)
            {
                xElements.Add(new XElement(name, value.TxnID));
            }
            return xElements;
        }
    }
}