using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public class ContactRef : IQBXML
        {
            public string ContactName { get; set; }
            public string ContactValue { get; set; }

            public XElement ToQBXML(string name)
            {
                XElement xElement = new XElement(name);
                xElement.Add(ContactName.ToQBXML(nameof(ContactName)));
                xElement.Add(ContactValue.ToQBXML(nameof(ContactValue)));
                return xElement;
            }
        }
    }
}