namespace StoreDB.Models
{
    public class CartItem
    {
        public int id { get; set; }
        public int cartId { get; set; }
        public Cart cart { get; set; }
        public int bookId { get; set; }
        public Book book { get; set; }
        public int quantity { get; set;}

    }
}