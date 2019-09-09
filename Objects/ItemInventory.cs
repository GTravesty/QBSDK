using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public class ItemInventory : Item
        {
            public BarCode BarCode { get; set; }
            public BaseRef ClassRef { get; set; }
            public string ManufacturerPartnumber { get; set; }
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

            public override XElement GenerateAddRq()
            {
                throw new NotImplementedException();
            }
            public override XElement GenerateModRq()
            {
                throw new NotImplementedException();
            }
            public override XElement GenerateDelRq()
            {
                throw new NotImplementedException();
            }
        }
    }
}