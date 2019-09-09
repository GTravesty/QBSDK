using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public static partial class Query
        {
            public class ListFilter<T>
            {
                public List<string> ListID { get; set; }
                public List<string> FullName { get; set; }

                public int? MaxReturned { get; set; }
                public bool? ActiveStatus { get; set; }

                protected internal DateTime? _FromModifiedDate;
                public DateTime? FromModifiedDate
                {
                    get { return _FromModifiedDate; }
                    set
                    {
                        if(value != null)
                        {
                            if(value < QBMinDate || value > QBMaxDate)
                            {
                                throw new ArgumentOutOfRangeException(string.Format("{0} must be between {1} and {2}.", nameof(FromModifiedDate), QBMinDate, QBMaxDate));
                            }
                        }
                        _FromModifiedDate = value;
                    }
                }

                protected internal DateTime? _ToModifiedDate;
                public DateTime? ToModifiedDate
                {
                    get { return _ToModifiedDate; }
                    set
                    {
                        if(value != null)
                        {
                            if(value < QBMinDate || value > QBMaxDate)
                            {
                                throw new ArgumentOutOfRangeException(string.Format("{0} must be between {1} and {2}.", nameof(ToModifiedDate), QBMinDate, QBMaxDate));
                            }
                        }
                        _ToModifiedDate = value;
                    }
                }

                public NameFilter NameFilter { get; set; }
                public NameRangeFilter NameRangeFilter { get; set; }

                public List<string> IncludeRetElement { get; set; }

                public virtual XElement GenerateQueryRq()
                {
                    XElement xElement = new XElement(typeof(T).Name + "QueryRq");
                    xElement.Add(ListID?.ToQBXML(nameof(ListID)));
                    xElement.Add(FullName?.ToQBXML(nameof(FullName)));
                    xElement.Add(MaxReturned?.ToQBXML(nameof(MaxReturned)));
                    xElement.Add(ActiveStatus?.ToQBXML(nameof(ActiveStatus)));
                    xElement.Add(FromModifiedDate?.ToQBXML(nameof(FromModifiedDate)));
                    xElement.Add(ToModifiedDate?.ToQBXML(nameof(ToModifiedDate)));
                    xElement.Add(NameFilter?.ToQBXML(nameof(NameFilter)));
                    xElement.Add(NameRangeFilter?.ToQBXML(nameof(NameRangeFilter)));
                    xElement.Add(IncludeRetElement?.ToQBXML(nameof(IncludeRetElement)));
                    return xElement;
                }
            }
        }
    }
}