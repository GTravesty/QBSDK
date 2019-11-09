using System;
using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public class BillingRatePerItem : IQBXML
        {
            #region // PROPERTIES ///////////////////////////////////////////
            public BaseRef ItemRef { get; set; }
            public float? CustomRate { get; set; }
            public float? CustomRatePercent { get; set; }

            #endregion

            #region // CONSTRUCTORS /////////////////////////////////////////
            public BillingRatePerItem() : this(null) { }
            public BillingRatePerItem(XElement xElement)
            {
                if (xElement == null)
                {
                    return;
                }
                ItemRef = (BaseRef)xElement.Element(nameof(ItemRef));
                CustomRate = (float?)xElement.Element(nameof(CustomRate));
                CustomRatePercent = (float?)xElement.Element(nameof(CustomRatePercent));
            }

            public static explicit operator BillingRatePerItem(XElement xElement)
            {
                if (xElement == null)
                {
                    return null;
                }
                return new BillingRatePerItem(xElement);
            }

            #endregion

            #region // METHODS //////////////////////////////////////////////
            public XElement ToQBXML(string name)
            {
                XElement xElement = new XElement(name);
                xElement.Add(ItemRef.ToQBXML(nameof(ItemRef)));
                xElement.Add(CustomRate.ToQBXML(nameof(CustomRate)));
                xElement.Add(CustomRatePercent.ToQBXML(nameof(CustomRatePercent)));
                return xElement;
            }

            #endregion

        }
    }
}