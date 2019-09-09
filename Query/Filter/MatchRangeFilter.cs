using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public static partial class Query
        {
            public abstract class MatchRangeFilter
            {
                public string From { get; set; }
                public string To { get; set; }

                public MatchRangeFilter() { }
                public MatchRangeFilter(string from, string to) : this()
                {
                    From = from;
                    To = to;
                }

                public abstract XElement ToQBXML(string name);
            }

            public class NameRangeFilter : MatchRangeFilter
            {
                public string FromName
                {
                    get { return From; }
                    set { From = value; }
                }
                public string ToName
                {
                    get { return To; }
                    set { To = value; }
                }

                public NameRangeFilter() : base() { }
                public NameRangeFilter(string fromName, string toName) : base(fromName, toName) {  }

                public override XElement ToQBXML(string name)
                {
                    XElement xElement = new XElement(name);
                    xElement.Add(FromName.ToQBXML(nameof(FromName)));
                    xElement.Add(ToName.ToQBXML(nameof(ToName)));
                    return xElement;
                }
            }

            public class RefNumberRangeFilter : MatchRangeFilter
            {
                public string FromRefNumber
                {
                    get { return From; }
                    set { From = value; }
                }
                public string ToRefNumber
                {
                    get { return To; }
                    set { To = value; }
                }

                public RefNumberRangeFilter() : base() { }
                public RefNumberRangeFilter(string fromRefNumber, string toRefNumber) : base(fromRefNumber, toRefNumber) { }

                public override XElement ToQBXML(string RefNumber)
                {
                    XElement xElement = new XElement(RefNumber);
                    xElement.Add(FromRefNumber.ToQBXML(nameof(FromRefNumber)));
                    xElement.Add(ToRefNumber.ToQBXML(nameof(ToRefNumber)));
                    return xElement;
                }
            }

        }

    }
}