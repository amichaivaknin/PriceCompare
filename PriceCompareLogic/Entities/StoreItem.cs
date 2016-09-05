namespace PriceCompareLogic.Entities
{
    public class StoreItem : Item
    {
        public double Price { get; internal set; }
        public string ChainId { get; set; }
        public string SubChainId { get; set; }
        public string StoreId { get; set; }
        public double TotalPrice => Price*Qty;
    }
}