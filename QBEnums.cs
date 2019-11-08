using System;
using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public enum QBEdition { SimpleStart, Pro, Premier, Enterprise }
        
        public enum MatchCriterion { StartsWith, Contains, EndsWith }

        public enum JobStatus { None, Awarded, Closed, InProgress, NotAwarded, Pending }

        public enum PreferredDeliveryMethod { None, Email, Fax }

        public enum ListType { Account, BillingRate, Class, Currency, Customer, CustomerMsg, CustomerType, DateDrivenTerms, Employee, InventorySite, ItemDiscount, ItemFixedAsset, ItemGroup, ItemInventory, ItemInventoryAssembly, ItemNonInventory, ItemOtherCharge, ItemPayment, ItemSalesTax, ItemSalesTaxGroup, ItemService, ItemSubtotal, JobType, OtherName, PaymentMethod, PayrollItemNonWage, PayrollItemWage, PriceLevel, SalesRep, SalesTaxCode, ShipMethod, StandardTerms, ToDo, UnitOfMeasureSet, Vehicle, Vendor, VendorType, WorkersCompCode }

        public enum TxnType { ARRefundCreditCard, Bill, BillPaymentCheck, BillPaymentCreditCard, BuildAssembly, Charge, Check, CreditCardCharge, CreditCardCredit, CreditMemo, Deposit, Estimate, InventoryAdjustment, Invoice, ItemReceipt, JournalEntry, LiabilityAdjustment, Paycheck, PayrollLiabilityCheck, PurchaseOrder, ReceivePayment, SalesOrder, SalesReceipt, SalesTaxPaymentCheck, Transfer, VendorCredit, YTDAdjustment }

        public enum LinkType { AMTTYPE, QUANTYPE }

        public static Nullable<T> Parse<T>(this XElement xElement) where T : struct, Enum
        {
            if (xElement == null)
            {
                return null;
            }
            T result = Activator.CreateInstance<T>();
            Enum.TryParse<T>((string)xElement.Element(typeof(T).Name), out result);
            return result;
        }
    }
}