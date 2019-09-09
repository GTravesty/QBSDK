using System.Collections.Generic;
using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public static partial class Query
        {
            public static partial class ItemInventoryQuery
            {
                public static XElement ByListID(List<string> ListID)
                {
                    return Query.List.ByListID<QBSDK.ItemInventory>(ListID);
                }
                public static XElement ByFullName(List<string> FullNameList)
                {
                    return Query.List.ByFullName<QBSDK.ItemInventory>(FullNameList);
                }

                public class QueryFilter : ListFilter<QBSDK.ItemInventory>
                {

                }
            }
        }
    }
}