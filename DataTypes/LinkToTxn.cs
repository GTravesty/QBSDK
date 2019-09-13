using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public class LinkToTxn : IQBXML
        {
            #region // PROPERTIES ///////////////////////////////////////////
            public string TxnID { get; set; }
            public string TxnLineID { get; set; }
            #endregion

            #region // CONSTRUCTORS /////////////////////////////////////////
            public LinkToTxn() : this(null) { }
            public LinkToTxn(XElement xElement)
            {
                if (xElement == null)
                {
                    return;
                }
                TxnID = (string)xElement.Element(nameof(TxnID));
                TxnLineID = (string)xElement.Element(nameof(TxnLineID));
            }

            public static explicit operator LinkToTxn(XElement xElement)
            {
                if(xElement == null)
                {
                    return null;
                }
                return new LinkToTxn(xElement);

            }
            #endregion

            #region // METHODS //////////////////////////////////////////////
            public XElement ToQBXML(string name)
            {
                XElement xElement = new XElement(name);
                xElement.Add(TxnID.ToQBXML(nameof(TxnID)));
                xElement.Add(TxnLineID.ToQBXML(nameof(TxnLineID)));
                return xElement;
            }
            #endregion
        }
    }

}