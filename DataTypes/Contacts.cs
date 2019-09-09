using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public class Contacts : IQBXML
        {
            public string ListID { get; set; }

            private DateTime? _TimeCreated;
            public DateTime? TimeCreated
            {
                get { return _TimeCreated; }
                set
                {
                    if(value != null)
                    {
                        if(value < QBMinDate || value > QBMaxDate)
                        {
                            throw new ArgumentOutOfRangeException(string.Format("{0} must be between {1} and {2}.", nameof(TimeCreated), QBMinDate, QBMaxDate));
                        }
                    }
                    _TimeCreated = value;
                }
            }

            private DateTime? _TimeModified;
            public DateTime? TimeModified
            {
                get { return _TimeModified; }
                set
                {
                    if(value != null)
                    {
                        if(value < QBMinDate || value > QBMaxDate)
                        {
                            throw new ArgumentOutOfRangeException(string.Format("{0} must be between {1} and {2}.", nameof(TimeModified), QBMinDate, QBMaxDate));
                        }
                    }
                    _TimeModified = value;
                }
            }

            public string EditSequence { get; set; }
            public string Contact { get; set; }
            public string Salutation { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public string JobTitle { get; set; }
            public List<ContactRef> AdditionalContactRef { get; set; }

            public XElement ToQBXML(string name)
            {
                XElement xElement = new XElement(name);
                xElement.Add(ListID.ToQBXML(nameof(ListID)));
                xElement.Add(TimeCreated.ToQBXML(nameof(TimeCreated)));
                xElement.Add(TimeModified.ToQBXML(nameof(TimeModified)));
                xElement.Add(EditSequence.ToQBXML(nameof(EditSequence)));
                xElement.Add(Contact.ToQBXML(nameof(Contact)));
                xElement.Add(Salutation.ToQBXML(nameof(Salutation)));
                xElement.Add(FirstName.ToQBXML(nameof(FirstName)));
                xElement.Add(MiddleName.ToQBXML(nameof(MiddleName)));
                xElement.Add(LastName.ToQBXML(nameof(LastName)));
                xElement.Add(JobTitle.ToQBXML(nameof(JobTitle)));
                xElement.Add(AdditionalContactRef?.ToQBXML(nameof(AdditionalContactRef)));                
                return xElement;
            }
            
        }
    }
}