using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public abstract class QBBaseObject : IAddRq, IModRq, IDelRq
        {
            public string SourceID { get; set; }
            public string QBStaus { get; set; }
            public string QBMessage { get; set; }
            public virtual string ID { get; set; }
            public string EditSequence { get; set; }

            protected DateTime? _TimeCreated;
            public DateTime? TimeCreated
            {
                get { return _TimeCreated; }
                set
                {
                    if (value != null)
                    {
                        if (value < QBMinDate || value > QBMaxDate)
                        {
                            throw new ArgumentOutOfRangeException(string.Format("{0} must be between {1} and {2}.", nameof(TimeCreated), QBMinDate, QBMaxDate));

                        }
                    }
                    _TimeCreated = value;
                }
            }
            protected DateTime? _TimeModified;
            public DateTime? TimeModified
            {
                get { return _TimeModified; }
                set
                {
                    if (value != null)
                    {
                        if (value < QBMinDate || value > QBMaxDate)
                        {
                            throw new ArgumentOutOfRangeException(string.Format("{0} must be between {1} and {2}.", nameof(TimeModified), QBMinDate, QBMaxDate));
                        }
                    }
                    _TimeModified = value;
                }
            }

            public List<DataExt> DataExtRet { get; set; }

            public abstract XElement GenerateAddRq();
            public abstract XElement GenerateModRq();
            public abstract XElement GenerateDelRq();
        }

        public abstract class QBTransaction : QBBaseObject
        {
            public string TxnID { get; set; }
            public override string ID { get { return TxnID; } set { TxnID = value; } }

            protected DateTime? _TxnDate;
            public DateTime? TxnDate
            {
                get { return _TxnDate; }
                set
                {
                    if (value != null)
                    {
                        if (value < QBMinDate || value > QBMaxDate)
                        {
                            throw new ArgumentOutOfRangeException(string.Format("{0} must be between {1} and {2}.", nameof(TxnDate), QBMinDate, QBMaxDate));
                        }
                    }
                    _TxnDate = value;
                }
            }
        }
        public abstract class QBList : QBBaseObject
        {
            public string ListID { get; set; }
            public override string ID { get { return ListID; } set { ListID = value; } }
            public string Name { get; set; }
            public string FullName
            {
                get
                {
                    if (ParentRef == null)
                    {
                        return Name;
                    }
                    return string.Join(":", ParentRef.FullName, Name);
                }
                set
                {
                    if (value == null)
                    {
                        ParentRef = null;
                        Name = null;
                        return;
                    }

                    int index = value.LastIndexOf(':');
                    if (index != -1)
                    {
                        ParentRef = new BaseRef(value.Substring(0, index));
                        Name = value.Substring(index + 1);
                    }
                    else
                    {
                        Name = value;
                    }
                }
            }
            public bool IsActive { get; set; } = true;
            public BaseRef ParentRef { get; set; }
            public int Sublevel { get; set; }
            public List<string> IncludeRetElement { get; set; }
        }
    }
}