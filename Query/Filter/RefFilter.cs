using System.Collections.Generic;
using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public static partial class Query
        {
            public class RefFilter
            {
                public List<string> ListID { get; set; }
                public List<string> FullName { get; set; }
                public string ListIDWithChildren { get; set; }
                public string FullNameWithChildren { get; set; }

                public XElement ToQBXML(string name)
                {
                    XElement xElement = new XElement(name);
                    xElement.Add(ListID?.ToQBXML(nameof(ListID)));
                    xElement.Add(FullName?.ToQBXML(nameof(FullName)));
                    xElement.Add(ListIDWithChildren.ToQBXML(nameof(ListIDWithChildren)));
                    xElement.Add(FullNameWithChildren.ToQBXML(nameof(FullNameWithChildren)));
                    return xElement;
                }
            }
        }
    }
}