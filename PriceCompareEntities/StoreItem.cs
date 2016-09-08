namespace PriceCompareEntities
{
    public class StoreItem : Item
    {
        public double Price { get;  set; }
        public string ChainId { get; set; }
        public string SubChainId { get; set; }
        public string StoreId { get; set; }
        public double TotalPrice => Price*Qty;
    }
}