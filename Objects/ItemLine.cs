using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace QBSDK_Helper
{
    public partial class QBSDK
    { 
        public interface IItemLine : IAddRq, IModRq, IQBXML
        {
            string TxnLineID { get; set; }
            BaseRef ItemRef { get; set; }
            BaseRef InventorySiteRef { get; set; }
            BaseRef InventorySiteLocationRef { get; set; }
            string Desc { get; set; }
            decimal? Quantity { get; set; }
            string UnitOfMeasure { get; set; }
            decimal? Amount { get; set; }
        }

        public class ItemLine : IItemLine
        {
            #region // PROPERTIES ///////////////////////////////////////////
            public string TxnLineID { get; set; }
            public BaseRef ItemRef { get; set; }
            public BaseRef InventorySiteRef { get; set; }
            public BaseRef InventorySiteLocationRef { get; set; }
            public string SerialNumber { get; set; }
            public string LotNumber { get; set; }
            public string Desc { get; set; }
            public decimal? Quantity { get; set; }
            public string UnitOfMeasure { get; set; }            
            public BaseRef OverrideUOMSetRef { get; set; }
            public decimal? Cost { get; set; }
            public decimal? Amount { get; set; }
            public BaseRef CustomerRef { get; set; }
            public BaseRef ClassRef { get; set; }
            public BillableStatus? BillableStatus { get; set; }            
            public BaseRef SalesRepRef { get; set; }
            public List<DataExt> DataExt { get; set; }
            #endregion

            #region // CONSTRUCTORS /////////////////////////////////////////
            public ItemLine() : this(null) { }
            public ItemLine(XElement xElement)
            {
                if(xElement == null)
                {
                    return;
                }
                TxnLineID = (string)xElement.Element(nameof(TxnLineID));
                ItemRef = (BaseRef)xElement.Element(nameof(ItemRef));
                InventorySiteRef = (BaseRef)xElement.Element(nameof(InventorySiteRef));
                InventorySiteLocationRef = (BaseRef)xElement.Element(nameof(InventorySiteLocationRef));
                SerialNumber = (string)xElement.Element(nameof(SerialNumber));
                LotNumber = (string)xElement.Element(nameof(LotNumber));
                Desc = (string)xElement.Element(nameof(Desc));
                Quantity = (decimal?)xElement.Element(nameof(Quantity));
                UnitOfMeasure = (string)xElement.Element(nameof(UnitOfMeasure));
                OverrideUOMSetRef = (BaseRef)xElement.Element(nameof(OverrideUOMSetRef));
                Cost = (decimal?)xElement.Element(nameof(Cost));
                Amount = (decimal?)xElement.Element(nameof(Amount));
                CustomerRef = (BaseRef)xElement.Element(nameof(CustomerRef));
                ClassRef = (BaseRef)xElement.Element(nameof(ClassRef));
                BillableStatus = (BillableStatus?)xElement.Parse<BillableStatus>();
                SalesRepRef = (BaseRef)xElement.Element(nameof(SalesRepRef));
                DataExt = (List<DataExt>)xElement.Elements(nameof(DataExt) + "Ret");
            }

            public static explicit operator ItemLine(XElement xElement)
            {
                if(xElement == null)
                {
                    return null;
                }
                return new ItemLine(xElement);
            }
            #endregion

            #region // METHODS //////////////////////////////////////////////
            public virtual XElement GenerateAddRq()
            {
                return GenerateAddRq(null, null);
            }
            public virtual XElement GenerateAddRq(BaseRef OverrideItemAccountRef=null, List<LinkToTxn> LinkToTxn = null)
            {
                XElement xElement = new XElement(nameof(ItemLine) + "Add");
                xElement.Add(ItemRef.ToQBXML(nameof(ItemRef)));
                xElement.Add(InventorySiteRef.ToQBXML(nameof(InventorySiteRef)));
                xElement.Add(InventorySiteLocationRef.ToQBXML(nameof(InventorySiteLocationRef)));
                xElement.Add(SerialNumber.ToQBXML(nameof(SerialNumber)));
                xElement.Add(LotNumber.ToQBXML(nameof(LotNumber)));
                xElement.Add(Desc.ToQBXML(nameof(Desc)));
                xElement.Add(Quantity.ToQBXML(nameof(Quantity)));
                xElement.Add(UnitOfMeasure.ToQBXML(nameof(UnitOfMeasure)));
                xElement.Add(Cost.ToQBXML(nameof(Cost)));
                xElement.Add(Amount.ToQBXML(nameof(Amount)));
                xElement.Add(CustomerRef.ToQBXML(nameof(CustomerRef)));
                xElement.Add(ClassRef.ToQBXML(nameof(ClassRef)));
                xElement.Add(BillableStatus.ToQBXML(nameof(BillableStatus)));
                xElement.Add(OverrideItemAccountRef.ToQBXML(nameof(OverrideItemAccountRef)));
                xElement.Add(LinkToTxn.ToQBXML(nameof(LinkToTxn)));
                xElement.Add(SalesRepRef.ToQBXML(nameof(SalesRepRef)));
                xElement.Add(DataExt.ToQBXML(nameof(DataExt)));
                return xElement;
            }

            public virtual XElement GenerateModRq()
            {
                return GenerateModRq(null);
            }
            public virtual XElement GenerateModRq(BaseRef OverrideItemAccountRef=null)
            {
                XElement xElement = new XElement(nameof(ItemLine) + "Mod");
                xElement.Add(TxnLineID.ToQBXML(nameof(TxnLineID)));
                xElement.Add(ItemRef.ToQBXML(nameof(ItemRef)));
                xElement.Add(InventorySiteRef.ToQBXML(nameof(InventorySiteRef)));
                xElement.Add(InventorySiteLocationRef.ToQBXML(nameof(InventorySiteLocationRef)));
                xElement.Add(SerialNumber.ToQBXML(nameof(SerialNumber)));
                xElement.Add(LotNumber.ToQBXML(nameof(LotNumber)));
                xElement.Add(Desc.ToQBXML(nameof(Desc)));
                xElement.Add(Quantity.ToQBXML(nameof(Quantity)));
                xElement.Add(UnitOfMeasure.ToQBXML(nameof(UnitOfMeasure)));
                xElement.Add(OverrideUOMSetRef.ToQBXML(nameof(OverrideUOMSetRef)));
                xElement.Add(Cost.ToQBXML(nameof(Cost)));
                xElement.Add(Amount.ToQBXML(nameof(Amount)));
                xElement.Add(CustomerRef.ToQBXML(nameof(CustomerRef)));
                xElement.Add(ClassRef.ToQBXML(nameof(ClassRef)));
                xElement.Add(BillableStatus.ToQBXML(nameof(BillableStatus)));
                xElement.Add(OverrideItemAccountRef.ToQBXML(nameof(OverrideItemAccountRef)));
                xElement.Add(SalesRepRef.ToQBXML(nameof(SalesRepRef)));
                return xElement;
            }

            public XElement ToQBXML(string name)
            {
                return ToQBXML(name, null);
            }
            public XElement ToQBXML(string name, BaseRef OverrideItemAccountRef = null)
            {
                XElement xElement = new XElement(name);
                xElement.Add(TxnLineID.ToQBXML(nameof(TxnLineID)));
                xElement.Add(ItemRef.ToQBXML(nameof(ItemRef)));
                xElement.Add(InventorySiteRef.ToQBXML(nameof(InventorySiteRef)));
                xElement.Add(InventorySiteLocationRef.ToQBXML(nameof(InventorySiteLocationRef)));
                xElement.Add(SerialNumber.ToQBXML(nameof(SerialNumber)));
                xElement.Add(LotNumber.ToQBXML(nameof(LotNumber)));
                xElement.Add(Desc.ToQBXML(nameof(Desc)));
                xElement.Add(UnitOfMeasure.ToQBXML(nameof(UnitOfMeasure)));
                xElement.Add(OverrideUOMSetRef.ToQBXML(nameof(OverrideUOMSetRef)));
                xElement.Add(Cost.ToQBXML(nameof(Cost)));
                xElement.Add(Amount.ToQBXML(nameof(Amount)));
                xElement.Add(CustomerRef.ToQBXML(nameof(CustomerRef)));
                xElement.Add(ClassRef.ToQBXML(nameof(ClassRef)));
                xElement.Add(BillableStatus.ToQBXML(nameof(BillableStatus)));
                xElement.Add(OverrideItemAccountRef.ToQBXML(nameof(OverrideItemAccountRef)));
                xElement.Add(SalesRepRef.ToQBXML(nameof(SalesRepRef)));
                return xElement;
            }
            #endregion
        }

        public class ItemGroupLine : IItemLine
        {
            #region // PROPERTIES ///////////////////////////////////////////
            public string TxnLineID { get; set; }
            public BaseRef ItemRef { get; set; }
            public BaseRef ItemGroupRef { get { return ItemRef; } set { ItemRef = value; } }
            public BaseRef InventorySiteRef { get; set; }
            public BaseRef InventorySiteLocationRef { get; set; }
            public string Desc { get; set; }
            public decimal? Quantity { get; set; }
            public string UnitOfMeasure { get; set; }
            public BaseRef OverrideUOMSetRef { get; set; }
            public decimal? Amount { get; set; }
            public decimal? TotalAmount { get { return Amount; } set { Amount = value; } }            
            public List<ItemLine> ItemLine { get; private set; }
            public List<DataExt> DataExt { get; set; }
            #endregion

            #region // CONSTRUCTORS /////////////////////////////////////////
            public ItemGroupLine() : this(null) { }
            public ItemGroupLine(XElement xElement)
            {
                if(xElement == null)
                {
                    return;
                }
                TxnLineID = (string)xElement.Element(nameof(TxnLineID));
                ItemGroupRef = (BaseRef)xElement.Element(nameof(ItemGroupRef));
                InventorySiteRef = (BaseRef)xElement.Element(nameof(InventorySiteRef));
                InventorySiteLocationRef = (BaseRef)xElement.Element(nameof(InventorySiteLocationRef));
                Desc = (string)xElement.Element(nameof(Desc));
                Quantity = (decimal?)xElement.Element(nameof(Quantity));
                UnitOfMeasure = (string)xElement.Element(nameof(UnitOfMeasure));
                OverrideUOMSetRef = (BaseRef)xElement.Element(nameof(OverrideUOMSetRef));
                TotalAmount = (decimal?)xElement.Element(nameof(TotalAmount));
                ItemLine = (List<ItemLine>)xElement.Elements(nameof(ItemLine) + "Ret");
                DataExt = (List<DataExt>)xElement.Elements(nameof(DataExt) + "Ret");
            }
            #endregion

            #region // METHODS //////////////////////////////////////////////
            public XElement GenerateAddRq()
            {
                return GenerateAddRq(null, null);
            }
            public  XElement GenerateAddRq(BaseRef OverrideItemAccountRef = null, List<LinkToTxn> LinkToTxn = null)
            {
                XElement xElement = new XElement(nameof(ItemGroupLine) + "Add");
                xElement.Add(ItemGroupRef.ToQBXML(nameof(ItemGroupRef)));
                xElement.Add(Quantity.ToQBXML(nameof(Quantity)));
                xElement.Add(UnitOfMeasure.ToQBXML(nameof(UnitOfMeasure)));
                xElement.Add(InventorySiteRef.ToQBXML(nameof(InventorySiteRef)));
                xElement.Add(InventorySiteLocationRef.ToQBXML(nameof(InventorySiteLocationRef)));                
                xElement.Add(DataExt.ToQBXML(nameof(DataExt)));
                return xElement;
            }

            public XElement GenerateModRq()
            {
                return GenerateModRq(null);
            }
            public XElement GenerateModRq(BaseRef OverrideItemAccountRef = null)
            {
                XElement xElement = new XElement(nameof(ItemLine) + "Mod");
                xElement.Add(TxnLineID.ToQBXML(nameof(TxnLineID)));
                xElement.Add(ItemGroupRef.ToQBXML(nameof(ItemGroupRef)));
                xElement.Add(Quantity.ToQBXML(nameof(Quantity)));
                xElement.Add(UnitOfMeasure.ToQBXML(nameof(UnitOfMeasure)));
                xElement.Add(OverrideUOMSetRef.ToQBXML(nameof(OverrideUOMSetRef)));
                xElement.Add(ItemLine.ToQBXML(nameof(ItemLine) + "Mod"));
                return xElement;
            }

            public XElement ToQBXML(string name)
            {
                throw new NotImplementedException();
            }
            #endregion
        }
    }
}