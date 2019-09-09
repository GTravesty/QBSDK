using System.Collections.Generic;
using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public static partial class Query
        {
            public class TransactionFilter<T>
            {
                public List<string> TxnID { get; set; }
                public List<string> RefNumber { get; set; }
                public List<string> RefNumberCaseSensitive { get; set; }

                public int? MaxReturned { get; set; }
                public ModifiedDateRange ModifiedDateRangeFilter { get; set; }
                public TxnDateRange TxnDateRangeFilter { get; set; }
                public RefFilter EntityFilter { get; set; }
                public RefFilter AccountFilter { get; set; }
                public MatchFilter MatchFilter { get; set; }
                public MatchRangeFilter MatchRangeFilter { get; set; }
                public RefFilter CurrencyFilter { get; set; }

                public string OwnerID { get; set; }

                public virtual XElement GenerateQueryRq()
                {
                    XElement xElement = new XElement(typeof(T).Name + "QueryRq");
                    xElement.Add(TxnID?.ToQBXML(nameof(TxnID)));
                    xElement.Add(RefNumber?.ToQBXML(nameof(RefNumber)));
                    xElement.Add(RefNumberCaseSensitive?.ToQBXML(nameof(RefNumberCaseSensitive)));
                    xElement.Add(MaxReturned?.ToQBXML(nameof(MaxReturned)));
                    xElement.Add(ModifiedDateRangeFilter?.ToQBXML(nameof(ModifiedDateRangeFilter)));
                    xElement.Add(TxnDateRangeFilter?.ToQBXML(nameof(TxnDateRangeFilter)));
                    xElement.Add(EntityFilter?.ToQBXML(nameof(EntityFilter)));
                    xElement.Add(AccountFilter?.ToQBXML(nameof(AccountFilter)));
                    xElement.Add(MatchFilter?.ToQBXML(nameof(MatchFilter)));
                    xElement.Add(MatchRangeFilter?.ToQBXML(nameof(MatchRangeFilter)));
                    xElement.Add(CurrencyFilter?.ToQBXML(nameof(CurrencyFilter)));
                    xElement.Add(OwnerID?.ToQBXML(nameof(OwnerID)));
                    return xElement;

                }

            }
        }
    }
}
