namespace ItemAPI.Model
{
    public class ItemDetail
    {
        public int Id { get; set; }
        public int? ItemId { get; set; }
        public float? Amount { get; set; }

        public int IdItem { get; set; } // FK
        public Item? Item { get; set; }
    }
}
