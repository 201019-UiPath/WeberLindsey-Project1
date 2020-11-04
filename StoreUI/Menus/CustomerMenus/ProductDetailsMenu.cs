using System;
using StoreDB;
using StoreDB.Models;
using StoreLib;
using StoreDB.Repos;

namespace StoreUI.Menus.CustomerMenus
{
    public class ProductDetailsMenu : IMenu
    {
        private string userInput;
        private User signedInUser;
        private int invQuantity;
        private Book book;
        private IUserRepo userRepo;
        private UserService userService;
        private IInventoryItemRepo inventoryItemRepo;
        private InventoryService inventoryService;
        private IBookRepo bookRepo;
        private BookService bookService;
        private ICartRepo cartRepo;
        private CartService cartService;
        private ICartItemRepo cartItemRepo;
        private CartItemService cartItemService;

        public ProductDetailsMenu(User user, Book book, StoreContext context, IUserRepo userRepo, IInventoryItemRepo inventoryItemRepo, IBookRepo bookRepo, ICartRepo cartRepo, ICartItemRepo cartItemRepo) {
            this.signedInUser = user;
            this.book = book;
            this.userRepo = userRepo;
            this.bookRepo = bookRepo;
            this.cartRepo = cartRepo;
            this.cartItemRepo = cartItemRepo;
            
            this.inventoryItemRepo = inventoryItemRepo;
            this.userService = new UserService(userRepo);
            this.inventoryService = new InventoryService(inventoryItemRepo);
            this.bookService = new BookService(bookRepo);
            this.cartService = new CartService(cartRepo);
            this.cartItemService = new CartItemService(cartItemRepo);
        }

        /// <summary>
        /// Menu for customer to view detailed information of product 
        /// and add it to their cart for purchase or return to the previous menu
        /// </summary>
        public void Start() {

            do {
                InventoryItem selectedItem = inventoryService.GetItemByLocationIdBookId(signedInUser.locationId, book.id);
                invQuantity = selectedItem.quantity;

                //TODO add some code here & the add to cart function to also subtract any existing cart quantity for that same item from the inv available amount so customers cant purchase more than what's available

                Console.WriteLine("\nWhat would you like to do? ");

                Console.WriteLine($" [{book.id}] {book.title} | {book.author} | {book.price} | Quantity: {invQuantity} ");
                Console.WriteLine($" {book.synopsis} \n");

                Console.WriteLine("[1] Add to cart");
                Console.WriteLine("[2] Back");

                userInput = Console.ReadLine();

                switch(userInput) {
                    case "1":
                        int quantity;

                        do{
                            Console.WriteLine("How many would you like? ");
                            quantity = Int32.Parse(Console.ReadLine());
                        } while(ValidationService.InvalidQuantity(invQuantity, quantity) == false);

                        CartItem item = new CartItem();
                        Cart userCart = cartService.GetCartByUserId(signedInUser.id);
                        item.cartId = userCart.id;
                        item.bookId = book.id;
                        item.quantity = quantity;
                        cartItemService.AddCartItem(item);
                        Console.WriteLine("Added to cart!");
                        break;

                    case "2":
                        break;

                    default:
                        ValidationService.InvalidInput();
                        break;
                }
            } while(!userInput.Equals("2"));


        }
    }
}