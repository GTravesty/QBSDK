using System;
using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public class ItemInventory : Item
        {
            #region // PROPERTIES /////////////////////////////////////////////
            private static ListType ListDelType = ListType.ItemInventory;
            public BarCode BarCode { get; set; }
            public BaseRef ClassRef { get; set; }
            public string ManufacturerPartNumber { get; set; }
            public BaseRef UnitOfMeasureSetRef { get; set; }
            public BaseRef SalesTaxCodeRef { get; set; }
            public string SalesDesc { get; set; }
            public decimal? SalesPrice { get; set; }
            public BaseRef IncomeAccountRef { get; set; }
            public string PurchaseDesc { get; set; }
            public decimal? PurchaseCost { get; set; }
            public BaseRef COGSAccountRef { get; set; }
            public BaseRef PrefVendorRef { get; set; }
            public BaseRef AssetAccountRef { get; set; }
            public decimal? ReorderPoint { get; set; }
            public decimal? Max { get; set; }
            public decimal? QuantityOnHand { get; set; }
            public decimal? AverageCost { get; set; }
            public decimal? QuantityOnOrder { get; set; }
            public decimal? QuantityOnSalesORder { get; set; }
            public string ExternalGUID { get; set; }
            #endregion

            public override XElement GenerateAddRq()
            {
                return GenerateAddRq(null, null);
            }
            public override XElement GenerateModRq()
            {
                return GenerateModRq(null, null, null);
            }
            public override XElement GenerateDelRq()
            {
                XElement Del = new XElement("ListDelRq");
                Del.Add(ListDelType.ToQBXML(nameof(ListDelType)));
                Del.Add(ListID.ToQBXML(nameof(ListID)));
                return Del;
            }

            public XElement GenerateAddRq(decimal? TotalValue=null, DateTime? InventoryDate=null)
            {
                XElement Add = new XElement(typeof(ItemInventory).Name + "Add");
                Add.Add(Name?.ToQBXML(nameof(Name)));
                Add.Add(BarCode?.ToQBXML(nameof(BarCode)));
                Add.Add(IsActive.ToQBXML(nameof(IsActive)));
                Add.Add(ClassRef?.ToQBXML(nameof(ClassRef)));
                Add.Add(ParentRef?.ToQBXML(nameof(ParentRef)));
                Add.Add(ManufacturerPartNumber?.ToQBXML(nameof(ManufacturerPartNumber)));
                Add.Add(UnitOfMeasureSetRef?.ToQBXML(nameof(UnitOfMeasureSetRef)));
                Add.Add(SalesTaxCodeRef?.ToQBXML(nameof(SalesTaxCodeRef)));
                Add.Add(SalesDesc?.ToQBXML(nameof(SalesDesc)));
                Add.Add(SalesPrice?.ToQBXML(nameof(SalesPrice)));
                Add.Add(IncomeAccountRef?.ToQBXML(nameof(IncomeAccountRef)));
                Add.Add(PurchaseDesc?.ToQBXML(nameof(PurchaseDesc)));
                Add.Add(PurchaseCost?.ToQBXML(nameof(PurchaseCost)));
                Add.Add(COGSAccountRef?.ToQBXML(nameof(COGSAccountRef)));
                Add.Add(PrefVendorRef?.ToQBXML(nameof(PrefVendorRef)));
                Add.Add(AssetAccountRef?.ToQBXML(nameof(AssetAccountRef)));
                Add.Add(ReorderPoint?.ToQBXML(nameof(ReorderPoint)));
                Add.Add(Max?.ToQBXML(nameof(Max)));
                Add.Add(QuantityOnHand?.ToQBXML(nameof(QuantityOnHand)));
                Add.Add(TotalValue?.ToQBXML(nameof(TotalValue)));
                Add.Add(InventoryDate?.ToQBXML(nameof(InventoryDate)));
                Add.Add(ExternalGUID?.ToQBXML(nameof(ExternalGUID)));

                XElement AddRq = new XElement(typeof(ItemInventory).Name + "AddRq", Add);
                foreach(var value in IncludeRetElement)
                {
                    AddRq.Add(value.ToQBXML(nameof(IncludeRetElement)));
                }
                return AddRq;
            }
            public XElement GenerateModRq(bool? ForceUOMChange=null, bool? ApplyIncomeAccountRefToExistingTxns=null, bool? ApplyCOGSAccountRefToExistingTxns=null)
            {
                XElement Mod = new XElement(typeof(ItemInventory).Name + "Mod");
                Mod.Add(ListID?.ToQBXML(nameof(ListID)));
                Mod.Add(EditSequence?.ToQBXML(nameof(EditSequence)));
                Mod.Add(Name?.ToQBXML(nameof(Name)));
                Mod.Add(BarCode?.ToQBXML(nameof(BarCode)));
                Mod.Add(IsActive.ToQBXML(nameof(IsActive)));
                Mod.Add(ClassRef?.ToQBXML(nameof(ClassRef)));
                Mod.Add(ParentRef?.ToQBXML(nameof(ParentRef)));
                Mod.Add(ManufacturerPartNumber?.ToQBXML(nameof(ManufacturerPartNumber)));
                Mod.Add(UnitOfMeasureSetRef?.ToQBXML(nameof(UnitOfMeasureSetRef)));
                Mod.Add(ForceUOMChange?.ToQBXML(nameof(ForceUOMChange)));
                Mod.Add(SalesTaxCodeRef?.ToQBXML(nameof(SalesTaxCodeRef)));
                Mod.Add(SalesDesc?.ToQBXML(nameof(SalesDesc)));
                Mod.Add(SalesPrice?.ToQBXML(nameof(SalesPrice)));
                Mod.Add(IncomeAccountRef?.ToQBXML(nameof(IncomeAccountRef)));
                Mod.Add(ApplyIncomeAccountRefToExistingTxns?.ToQBXML(nameof(ApplyIncomeAccountRefToExistingTxns)));
                Mod.Add(PurchaseDesc?.ToQBXML(nameof(PurchaseDesc)));
                Mod.Add(PurchaseCost?.ToQBXML(nameof(PurchaseCost)));
                Mod.Add(COGSAccountRef?.ToQBXML(nameof(COGSAccountRef)));
                Mod.Add(ApplyCOGSAccountRefToExistingTxns?.ToQBXML(nameof(ApplyCOGSAccountRefToExistingTxns)));
                Mod.Add(PrefVendorRef?.ToQBXML(nameof(PrefVendorRef)));
                Mod.Add(AssetAccountRef?.ToQBXML(nameof(AssetAccountRef)));
                Mod.Add(ReorderPoint?.ToQBXML(nameof(ReorderPoint)));
                Mod.Add(Max?.ToQBXML(nameof(Max)));

                XElement ModRq = new XElement(typeof(ItemInventory).Name + "ModRq", Mod);
                foreach (var value in IncludeRetElement)
                {
                    ModRq.Add(value.ToQBXML(nameof(IncludeRetElement)));
                }
                return ModRq;
            }
        }
    }
}