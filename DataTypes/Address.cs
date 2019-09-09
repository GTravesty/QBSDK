using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public class AddressBlock : IQBXML
        {
            public string Addr1 { get; set; }
            public string Addr2 { get; set; }
            public string Addr3 { get; set; }
            public string Addr4 { get; set; }
            public string Addr5 { get; set; }

            public XElement ToQBXML(string name)
            {
                XElement xElement = new XElement(name);
                xElement.Add(Addr1.ToQBXML(nameof(Addr1)));
                xElement.Add(Addr2.ToQBXML(nameof(Addr2)));
                xElement.Add(Addr3.ToQBXML(nameof(Addr3)));
                xElement.Add(Addr4.ToQBXML(nameof(Addr4)));
                xElement.Add(Addr5.ToQBXML(nameof(Addr5)));
                return xElement;
            }
        }

        public class Address : AddressBlock, IQBXML
        {
            public string Name { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string PostalCode { get; set; }
            public string Country { get; set; }
            public string Note { get; set; }
            public bool? DefaultShipTo { get; set; }

            public new XElement ToQBXML(string name)
            {
                XElement xElement = new XElement(name);
                xElement.Add(Name.ToQBXML(nameof(Name)));
                xElement.Add(Addr1.ToQBXML(nameof(Addr1)));
                xElement.Add(Addr2.ToQBXML(nameof(Addr2)));
                xElement.Add(Addr3.ToQBXML(nameof(Addr3)));
                xElement.Add(Addr4.ToQBXML(nameof(Addr4)));
                xElement.Add(Addr5.ToQBXML(nameof(Addr5)));
                xElement.Add(City.ToQBXML(nameof(City)));
                xElement.Add(State.ToQBXML(nameof(State)));
                xElement.Add(PostalCode.ToQBXML(nameof(PostalCode)));
                xElement.Add(Country.ToQBXML(nameof(Country)));
                xElement.Add(Note.ToQBXML(nameof(Note)));
                xElement.Add(DefaultShipTo.ToQBXML(nameof(DefaultShipTo)));
                return xElement;
            }
        }
    }
}