using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public class CreditCard : IQBXML
        {
            #region // PROPERTIES ///////////////////////////////////////////
            public string CreditCardNumber { get; set; }
            public int? ExpirationMonth { get; set; }
            public int? ExpirationYear { get; set; }
            public string NameOnCard { get; set; }
            public string CreditCardAddress { get; set; }
            public string CreditCardPostalCode { get; set; }
            #endregion

            #region // CONSTRUCTORS /////////////////////////////////////////
            public CreditCard() : this(null) { }
            public CreditCard(XElement xElement)
            {
                CreditCardNumber = (string)xElement.Element(nameof(CreditCardNumber));
                ExpirationMonth = (int?)xElement.Element(nameof(ExpirationMonth));
                ExpirationYear = (int?)xElement.Element(nameof(ExpirationYear));
                NameOnCard = (string)xElement.Element(nameof(NameOnCard));
                CreditCardAddress = (string)xElement.Element(nameof(CreditCardAddress));
                CreditCardPostalCode = (string)xElement.Element(nameof(CreditCardPostalCode));
            }

            public static explicit operator CreditCard(XElement xElement)
            {
                if(xElement == null)
                {
                    return null;
                }
                return new CreditCard(xElement);
            }
            #endregion

            #region // METHODS //////////////////////////////////////////////
            public XElement ToQBXML(string name)
            {
                XElement xElement = new XElement(name);
                xElement.Add(CreditCardNumber.ToQBXML(nameof(CreditCardNumber)));
                xElement.Add(ExpirationMonth.ToQBXML(nameof(ExpirationMonth)));
                xElement.Add(ExpirationYear.ToQBXML(nameof(ExpirationYear)));
                xElement.Add(NameOnCard.ToQBXML(nameof(NameOnCard)));
                xElement.Add(CreditCardAddress.ToQBXML(nameof(CreditCardAddress)));
                xElement.Add(CreditCardPostalCode.ToQBXML(nameof(CreditCardPostalCode)));
                return xElement;
            }
            #endregion
        }
    }

}