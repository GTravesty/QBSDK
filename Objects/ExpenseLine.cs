using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public class ExpenseLine : IAddRq, IModRq, IQBXML
        {
            #region // PROPERTIES ///////////////////////////////////////////
            public int TxnLineID { get; set; }
            public BaseRef AccountRef { get; set; }
            public decimal? Amount { get; set; }
            public string Memo { get; set; }
            public BaseRef CustomerRef { get; set; }
            public BaseRef ClassRef { get; set; }
            public BillableStatus BillableStatus { get; set; }
            public BaseRef SalesRepRef { get; set; }
            public List<DataExt> DataExt { get; set; }
            #endregion

            #region // CONSTRUCTORS /////////////////////////////////////////
            public ExpenseLine() : this(null) { }
            public ExpenseLine(XElement xElement)
            {
                if(xElement == null)
                {
                    return;
                }
                TxnLineID = (int)xElement.Element(nameof(TxnLineID));
                AccountRef = (BaseRef)xElement.Element(nameof(AccountRef));
                Amount = (decimal?)xElement.Element(nameof(Amount));
                Memo = (string)xElement.Element(nameof(Memo));
                CustomerRef = (BaseRef)xElement.Element(nameof(CustomerRef));
                ClassRef = (BaseRef)xElement.Element(nameof(ClassRef));
                BillableStatus = (BillableStatus)xElement.Parse<BillableStatus>();
                SalesRepRef = (BaseRef)xElement.Element(nameof(SalesRepRef));
                DataExt = (List<DataExt>)xElement.Elements(nameof(DataExt) + "Ret");
            }

            public static explicit operator ExpenseLine(XElement xElement)
            {
                if(xElement == null)
                {
                    return null;
                }
                return new ExpenseLine(xElement);
            }
            #endregion

            #region // METHODS //////////////////////////////////////////////
            public XElement GenerateAddRq()
            {
                XElement Add = new XElement(nameof(ExpenseLine) + "Add");
                Add.Add(AccountRef.ToQBXML(nameof(AccountRef)));
                Add.Add(Amount.ToQBXML(nameof(Amount)));
                Add.Add(Memo.ToQBXML(nameof(Memo)));
                Add.Add(CustomerRef.ToQBXML(nameof(CustomerRef)));
                Add.Add(ClassRef.ToQBXML(nameof(ClassRef)));
                Add.Add(BillableStatus.ToQBXML(nameof(BillableStatus)));
                Add.Add(SalesRepRef.ToQBXML(nameof(SalesRepRef)));
                Add.Add(DataExt.ToQBXML(nameof(DataExt)));
                return Add;
            }

            public XElement GenerateModRq()
            {
                XElement Mod = new XElement(nameof(ExpenseLine) + "Mod");
                Mod.Add(TxnLineID.ToQBXML(nameof(TxnLineID)));
                Mod.Add(AccountRef.ToQBXML(nameof(AccountRef)));
                Mod.Add(Amount.ToQBXML(nameof(Amount)));
                Mod.Add(Memo.ToQBXML(nameof(Memo)));
                Mod.Add(CustomerRef.ToQBXML(nameof(CustomerRef)));
                Mod.Add(ClassRef.ToQBXML(nameof(ClassRef)));
                Mod.Add(BillableStatus.ToQBXML(nameof(BillableStatus)));
                Mod.Add(SalesRepRef.ToQBXML(nameof(SalesRepRef)));

                return Mod;
            }

            public XElement ToQBXML(string name)
            {
                return ToQBXML(name, null);
            }
            public XElement ToQBXML(string name, BaseRef OverrideItemAccountRef = null)
            {
                throw new NotImplementedException();
            }
            #endregion

        }
    }
}