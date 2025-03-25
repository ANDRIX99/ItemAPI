namespace ItemAPI.Model
{
    public class ItemDetail
    {
        public int Id { get; set; }
        public int? ItemId { get; set; } // FK
        public float? Amount { get; set; }

        public int IdItem { get; set; } 
        public Item? Item { get; set; }
    }
}
