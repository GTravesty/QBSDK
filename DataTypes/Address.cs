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
            #region // PROPERTIES ///////////////////////////////////////////
            public string Addr1 { get; set; }
            public string Addr2 { get; set; }
            public string Addr3 { get; set; }
            public string Addr4 { get; set; }
            public string Addr5 { get; set; }
            #endregion

            #region // CONSTRUCTORS /////////////////////////////////////////
            public AddressBlock() : this(null) { }
            public AddressBlock(XElement xElement)
            {
                if(xElement == null)
                {
                    return;
                }
                Addr1 = (string)xElement.Element(nameof(Addr1));
                Addr2 = (string)xElement.Element(nameof(Addr2));
                Addr3 = (string)xElement.Element(nameof(Addr3));
                Addr4 = (string)xElement.Element(nameof(Addr4));
                Addr5 = (string)xElement.Element(nameof(Addr5));
            }

            public static explicit operator AddressBlock(XElement xElement)
            {
                if(xElement == null)
                {
                    return null;
                }
                return new AddressBlock(xElement);
            }
            #endregion

            #region // METHODS //////////////////////////////////////////////
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
            #endregion
        }

        public class Address : AddressBlock, IQBXML
        {
            #region // PROPERTIES ///////////////////////////////////////////
            public string Name { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string PostalCode { get; set; }
            public string Country { get; set; }
            public string Note { get; set; }
            public bool? DefaultShipTo { get; set; }
            #endregion

            #region // CONSTRUCTORS /////////////////////////////////////////
            public Address() : this(null) {  }
            public Address(XElement xElement) : base(xElement)
            {
                if(xElement == null)
                {
                    return;
                }
                Name = (string)xElement.Element(nameof(Name));
                City = (string)xElement.Element(nameof(City));
                State = (string)xElement.Element(nameof(State));
                PostalCode = (string)xElement.Element(nameof(PostalCode));
                Country = (string)xElement.Element(nameof(Country));
                Note = (string)xElement.Element(nameof(Note));
                DefaultShipTo = (bool?)xElement.Element(nameof(DefaultShipTo));
            }

            public static explicit operator Address(XElement xElement)
            {
                if (xElement == null)
                {
                    return null;
                }
                return new Address(xElement);
            }
            #endregion

            #region // METHODS //////////////////////////////////////////////
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
            #endregion



        }
    }
}