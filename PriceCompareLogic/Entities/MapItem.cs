﻿using System.Collections.Generic;

namespace PriceCompareLogic.Entities
{
    public class MapItem : Item
    {
        internal bool GlobalCode { get; set; }
        internal string GlobalItemCode {get; set;}
        public IDictionary<string, string> ItemCodeByChains { get; internal set; }
        
    }
}