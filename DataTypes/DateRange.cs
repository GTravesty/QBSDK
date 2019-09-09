using System;
using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public abstract class DateRange
        {
            public DateTime? FromDate { get; set; }
            public DateTime? ToDate { get; set; }

            protected DateRange() { }
            protected DateRange(DateTime from) : this()
            {
                FromDate = from;
            }
            protected DateRange(DateTime from, DateTime to) : this(from)
            {
                ToDate = to;
            }
            protected DateRange(DateMacro dateMacro)
            {
                switch (dateMacro)
                {
                    case DateMacro.Today:
                        FromDate = DateTime.Today;
                        ToDate = DateTime.Today.AddDays(1).AddSeconds(-1);
                        break;

                    case DateMacro.Yesterday:
                        FromDate = DateTime.Today.AddDays(-1);
                        ToDate = DateTime.Today.AddSeconds(-1);
                        break;

                    // TODO: Add additional date macros

                    case DateMacro.All:
                    default:
                        FromDate = QBMinDate;
                        ToDate = QBMaxDate;
                        break;
                }
            }

            public abstract XElement ToQBXML(string name);
        }

        public class TxnDateRange : DateRange
        {
            public DateTime? FromTxnDate
            {
                get { return FromDate; }
                set { FromDate = value; }
            }
            public DateTime? ToTxnDate
            {
                get { return ToDate; }
                set { ToDate = value; }
            }
            
            public TxnDateRange() : base() { }
            public TxnDateRange(DateTime from) : base(from) { }
            public TxnDateRange(DateTime from, DateTime to) : base(from, to) { }
            public TxnDateRange(DateMacro dateMacro) : base(dateMacro) { }

            public override XElement ToQBXML(string name)
            {
                XElement xElement = new XElement(name);
                xElement.Add(FromTxnDate?.ToQBXML(nameof(FromTxnDate)));
                xElement.Add(ToTxnDate?.ToQBXML(nameof(ToTxnDate)));
                return xElement;
            }
        }

        public class ModifiedDateRange : DateRange
        {
            public DateTime? FromModifiedDate
            {
                get { return FromDate; }
                set { FromDate = value; }
            }
            public DateTime? ToModifiedDate
            {
                get { return ToDate; }
                set { ToDate = value; }
            }

            public ModifiedDateRange() : base() { }
            public ModifiedDateRange(DateTime from) : base(from) { }
            public ModifiedDateRange(DateTime from, DateTime to) : base(from, to) { }
            public ModifiedDateRange(DateMacro dateMacro) : base(dateMacro) { }

            public override XElement ToQBXML(string name)
            {
                XElement xElement = new XElement(name);
                xElement.Add(FromModifiedDate?.ToQBXML(nameof(FromModifiedDate)));
                xElement.Add(ToModifiedDate?.ToQBXML(nameof(ToModifiedDate)));
                return xElement;
            }
        }

        public enum DateMacro
        {
            All, Today, Yesterday, ThisWeek, ThisMonth, ThisQuarter, ThisYear, LastWeek, LastMonth, LastQuarter, LastYear
        }
       
    }
}
