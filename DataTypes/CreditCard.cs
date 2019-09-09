using System;
using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public class CreditCard : IQBXML
        {
            public string CreditCardNumber { get; set; }
            public int? ExpirationMonth { get; set; }
            public int? ExpirationYear { get; set; }
            public string NameOnCard { get; set; }
            public string CreditCardAddress { get; set; }
            public string CreditCardPostalCode { get; set; }

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
        }
    }

}