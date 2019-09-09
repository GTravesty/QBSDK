using System;
using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public class Bill : QBTransaction
        {
            public BaseRef VendorRef { get; set; }
            // VendorAddress
            public BaseRef APAccountRef { get; set; }

            public override XElement GenerateAddRq()
            {
                XElement xElement = new XElement("BillAdd");
                xElement.Add(VendorRef?.ToQBXML(nameof(VendorRef)));
                xElement.Add(APAccountRef?.ToQBXML(nameof(APAccountRef)));
                xElement.Add(TxnDate?.ToQBXML(nameof(TxnDate)));
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