using System.Collections.Generic;
using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public static partial class Query
        {
            public static partial class List
            {
                public static XElement ByListID<T>(List<string> ListIDList)
                {
                    XElement xElement = new XElement(typeof(T).Name + "QueryRq");
                    foreach(string ListID in ListIDList)
                    {
                        xElement.Add(ListID.ToQBXML(nameof(ListID)));
                    }
                    return xElement;
                }

                public static XElement ByFullName<T>(List<string> FullNameList)
                {
                    XElement xElement = new XElement(typeof(T).Name + "QueryRq");
                    foreach (string FullName in FullNameList)
                    {
                        xElement.Add(FullName.ToQBXML(nameof(FullName)));
                    }
                    return xElement;
                }
            }

            public static partial class Transaction
            {
                public static XElement ByTxnID<T>(List<string> TxnIDList)
                {
                    XElement xElement = new XElement(typeof(T).Name + "QueryRq");
                    foreach (string TxnID in TxnIDList)
                    {
                        xElement.Add(TxnID.ToQBXML(nameof(TxnID)));
                    }
                    return xElement;
                }

                public static XElement ByRefNumber<T>(List<string> RefNumberList)
                {
                    XElement xElement = new XElement(typeof(T).Name + "QueryRq");
                    foreach (string RefNumber in RefNumberList)
                    {
                        xElement.Add(RefNumber.ToQBXML(nameof(RefNumber)));
                    }
                    return xElement;
                }

                public static XElement ByRefNumberCaseSensitive<T>(List<string> RefNumberList)
                {
                    XElement xElement = new XElement(typeof(T).Name + "QueryRq");
                    foreach (string RefNumberCaseSensitive in RefNumberList)
                    {
                        xElement.Add(RefNumberCaseSensitive.ToQBXML(nameof(RefNumberCaseSensitive)));
                    }
                    return xElement;
                }
            }
        }
    }

}