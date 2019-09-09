using System.Collections.Generic;
using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        
        public static partial class Query
        {
            public static partial class Customer
            {
                public static XElement ByListID(List<string> ListIDList)
                {
                    return Query.List.ByListID<QBSDK.Customer>(ListIDList);
                }
                public static XElement ByFullName(List<string> FullNameList)
                {
                    return Query.List.ByFullName<QBSDK.Customer>(FullNameList);
                }

                public class QueryFilter : ListFilter<QBSDK.Customer>
                {
                }
            }
        }
    }
}