using System;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public enum MatchCriterion { StartsWith, Contains, EndsWith }

        public enum JobStatus { None, Awarded, Closed, InProgress, NotAwarded, Pending }

        public enum PreferredDeliveryMethod { None, Email, Fax }

        public enum ListType { Account, BillingRate, Class, Currency, Customer, CustomerMsg, CustomerType, DateDrivenTerms, Employee, InventorySite, ItemDiscount, ItemFixedAsset, ItemGroup, ItemInventory, ItemInventoryAssembly, ItemNonInventory, ItemOtherCharge, ItemPayment, ItemSalesTax, ItemSalesTaxGroup, ItemService, ItemSubtotal, JobType, OtherName, PaymentMethod, PayrollItemNonWage, PayrollItemWage, PriceLevel, SalesRep, SalesTaxCode, ShipMethod, StandardTerms, ToDo, UnitOfMeasureSet, Vehicle, Vendor, VendorType, WorkersCompCode }
    }
}