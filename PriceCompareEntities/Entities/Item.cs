namespace PriceCompareLogic.Entities
{
    public class Item
    {
        public int Id { get; internal set; }
        public string ItemName { get; internal set; }
        public string UnitQty { get; internal set; }
        public double Qty { get; set; }
    }
}