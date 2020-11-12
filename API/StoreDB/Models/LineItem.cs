namespace StoreDB.Models
{
    public class LineItem
    {
        public int id { get; set; }
        public int orderId { get; set; }
        public Order order { get; set; }
        public int bookId { get; set; }
        public Book book { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }

    }
}