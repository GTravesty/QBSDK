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
            public abstract class MatchFilter
            {
                public MatchCriterion MatchCriterion { get; set; }
                public string Value { get; set; }

                protected MatchFilter() { }
                protected MatchFilter(string value) : this()
                {
                    MatchCriterion = MatchCriterion.Contains;
                    Value = value;
                }
                protected MatchFilter(string value, MatchCriterion matchCriterion) : this(value)
                {
                    MatchCriterion = matchCriterion;
                }

                public abstract XElement ToQBXML(string name);
            }

            public class NameFilter : MatchFilter
            {
                public string Name
                {
                    get { return Value; }
                    set { Value = value; }
                }

                public NameFilter() : base() { }
                public NameFilter(string name) : base(name) { }
                public NameFilter(string name, MatchCriterion matchCriterion) : base(name, matchCriterion) { }

                public override XElement ToQBXML(string name)
                {
                    XElement xElement = new XElement(name);
                    xElement.Add(MatchCriterion.ToQBXML(nameof(MatchCriterion)));
                    xElement.Add(Name.ToQBXML(nameof(Name)));
                    return xElement;
                }
            }

            public class RefNumberFilter : MatchFilter
            {
                public string RefNumber
                {
                    get { return Value; }
                    set { Value = value; }
                }
                public RefNumberFilter() : base() { }
                public RefNumberFilter(string refNumber) : base(refNumber) { }
                public RefNumberFilter(string refNumber, MatchCriterion matchCriterion) : base(refNumber, matchCriterion) { }

                public override XElement ToQBXML(string name)
                {
                    XElement xElement = new XElement(name);
                    xElement.Add(MatchCriterion.ToQBXML(nameof(MatchCriterion)));
                    xElement.Add(RefNumber.ToQBXML(nameof(RefNumber)));
                    return xElement;
                }

            }
        }
    }
}