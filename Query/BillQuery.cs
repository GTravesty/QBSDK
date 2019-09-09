using System.Collections.Generic;
using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public static partial class Query
        {
            public static partial class Bill
            {
                public static XElement ByTxnID(List<string> TxnIDList)
                {
                    return Query.Transaction.ByTxnID<QBSDK.Bill>(TxnIDList);
                }
                public static XElement ByRefNumber(List<string> RefNumberList)
                {
                    return Query.Transaction.ByRefNumber<QBSDK.Bill>(RefNumberList);
                }
                public static XElement ByRefNumberCaseSensitive(List<string> RefNumberList)
                {
                    return Query.Transaction.ByRefNumberCaseSensitive<QBSDK.Bill>(RefNumberList);
                }

                public class QueryFilter : TransactionFilter<QBSDK.Bill>
                {

                }
            }
        }
    }

}