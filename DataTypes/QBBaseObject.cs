using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        // BaseObject for List and Transactions for QuickBooks        
        public abstract class QBBaseObject : IAddRq, IModRq, IDelRq
        {
            #region // PROPERTIES ///////////////////////////////////////////
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
            #endregion

            #region // CONSTRUCTORS /////////////////////////////////////////
            public QBBaseObject() : this(null) { }
            public QBBaseObject(XElement xElement)
            {
                if(xElement == null)
                {
                    return;
                }
                EditSequence = (string)xElement.Element(nameof(EditSequence));
                TimeCreated = (DateTime?)xElement.Element(nameof(TimeCreated));
                TimeModified = (DateTime?)xElement.Element(nameof(TimeModified));
                // TODO: Test if this will convert properly or throw exception. May need to create explicit conversion
                DataExtRet = (List<DataExt>)xElement.Elements(nameof(DataExtRet));
            }
            #endregion

            #region // METHODS //////////////////////////////////////////////
            public abstract XElement GenerateAddRq();
            public abstract XElement GenerateModRq();
            public abstract XElement GenerateDelRq();
            #endregion
        }
        
        // Base QuickBooks Transaction Object
        public abstract class QBTransaction : QBBaseObject
        {
            #region // PROPERTIES ///////////////////////////////////////////
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
            #endregion

            #region // CONSTRUCTORS /////////////////////////////////////////
            public QBTransaction() : this(null) { }
            public QBTransaction(XElement xElement) : base(xElement)
            {
                if(xElement == null)
                {
                    return;
                }
                TxnID = (string)xElement.Element(nameof(TxnID));
                TxnDate = (DateTime?)xElement.Element(nameof(TxnDate));
            }
            #endregion
        }

        // Base QuickBooks List Object
        public abstract class QBList : QBBaseObject
        {
            #region // PROPERTIES ///////////////////////////////////////////
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
            public bool? IsActive { get; set; }
            public BaseRef ParentRef { get; set; }
            public int? Sublevel { get; set; }
            public List<string> IncludeRetElement { get; set; }
            #endregion

            #region // CONSTRUCTORS /////////////////////////////////////////
            public QBList() : this(null) { }
            public QBList(XElement xElement) : base(xElement)
            {
                if (xElement == null)
                {
                    return;
                }
                ListID = (string)xElement.Element(nameof(ListID));
                Name = (string)xElement.Element(nameof(Name));
                IsActive = (bool?)xElement.Element(nameof(IsActive));
                ParentRef = (BaseRef)xElement.Element(nameof(ParentRef));
                Sublevel = (int?)xElement.Element(nameof(Sublevel));                
            }
            #endregion
        }
    }
}