using System;
using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public class BaseRef
        {
            public string ListID { get; set; }
            public string FullName { get; set; }

            public BaseRef() { }
            public BaseRef(string fullName) : this()
            {
                FullName = fullName;
            }
            public BaseRef(XElement value) : this()
            {
                if (value == null)
                {
                    return;
                }
                ListID = (string)value.Element(nameof(ListID));
                FullName = (string)value.Element(nameof(FullName));
            }
            public static explicit operator BaseRef(XElement value)
            {
                if(value == null)
                {
                    return null;
                }
                return new BaseRef(value);
            }
        
            public XElement ToQBXML(string name)
            {
                XElement xElement = new XElement(name);
                xElement.Add(ListID?.ToQBXML(nameof(ListID)));
                xElement.Add(FullName?.ToQBXML(nameof(FullName)));
                return xElement;
            }
        }
    }
}