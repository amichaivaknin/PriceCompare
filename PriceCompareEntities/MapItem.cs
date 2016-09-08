using System.Collections.Generic;

namespace PriceCompareEntities
{
    public class MapItem : Item
    {
        public bool IsGlobalCode { get; set; }
        public string GlobalItemCode {get; set;}
        public IDictionary<string, string> ItemCodeByChains { get; set; }
        
    }
}