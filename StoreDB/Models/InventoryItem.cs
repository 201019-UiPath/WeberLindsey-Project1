namespace StoreDB.Models
{
    public class InventoryItem
    {
        public int id { get; set; }
        public int bookId { get; set; }
        public Book book { get; set; }
        public int locationId { get; set; }
        public Location location { get; set; }
        public int quantity { get; set; }

    }

}