using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public class BillingRate : List
        {
            #region // PROPERTIES ///////////////////////////////////////////
            private static ListType ListType = ListType.BillingRate;

            public BillingRateType BillingRateType { get; set; }
            public float? FixedBillingRate { get; set; }
            public List<BillingRatePerItem> BillingRatePerItemList { get; set; }

            #endregion

            #region // CONSTRUCTORS /////////////////////////////////////////
            public BillingRate() : this(null) { }
            public BillingRate(XElement xElement) : base(xElement)
            {
                if (xElement == null)
                {
                    return;
                }
                BillingRateType = (BillingRateType)xElement.Parse<BillingRateType>();
                BillingRatePerItemList = (List<BillingRatePerItem>)xElement.Elements(nameof(BillingRatePerItem));

            }
            #endregion

            #region // METHODS //////////////////////////////////////////////
            public override XElement GenerateAddRq()
            {
                XElement xElement = new XElement(nameof(BillingRate) + "Add");
                xElement.Add(ListID?.ToQBXML(nameof(ListID)));
                xElement.Add(TimeCreated?.ToQBXML(nameof(TimeCreated)));
                xElement.Add(TimeModified?.ToQBXML(nameof(TimeModified)));
                xElement.Add(EditSequence?.ToQBXML(nameof(EditSequence)));
                xElement.Add(Name?.ToQBXML(nameof(Name)));
                xElement.Add(BillingRateType.ToQBXML(nameof(BillingRateType)));
                xElement.Add(BillingRatePerItemList?.ToQBXML(nameof(BillingRatePerItem)));

                return xElement;
            }

            public override XElement GenerateModRq()
            {
                return GenerateModRq(null);
            }
            public XElement GenerateModRq(bool? ClearExpenseLines = null)
            {
                XElement xElement = new XElement(nameof(BillingRate) + "Mod");
                xElement.Add(ListID?.ToQBXML(nameof(ListID)));
                xElement.Add(TimeCreated?.ToQBXML(nameof(TimeCreated)));
                xElement.Add(TimeModified?.ToQBXML(nameof(TimeModified)));
                xElement.Add(EditSequence?.ToQBXML(nameof(EditSequence)));
                xElement.Add(Name?.ToQBXML(nameof(Name)));
                xElement.Add(BillingRateType.ToQBXML(nameof(BillingRateType)));
                xElement.Add(BillingRatePerItemList?.ToQBXML(nameof(BillingRatePerItem)));

                return xElement;
            }

            public override XElement GenerateDelRq()
            {
                XElement xElement = new XElement("ListDelRq");
                xElement.Add(ListType.ToQBXML("ListDelType"));
                xElement.Add(ListID.ToQBXML(nameof(ListID)));
                return xElement;
            }
            #endregion
        }
    }

}
