using System;
using StoreDB;
using StoreDB.Models;
using StoreLib;
using StoreDB.Repos;
using System.Collections.Generic;

namespace StoreUI.Menus.CustomerMenus
{
    public class EditCartMenu : IMenu
    {
        private string userInput;
        private User signedInUser;
        private IUserRepo userRepo;
        private UserService userService;
        private ILocationRepo locationRepo;
        private LocationService locationService;
        private IInventoryItemRepo inventoryItemRepo;
        private InventoryService inventoryService;
        private IBookRepo bookRepo;
        private BookService bookService;
        private ICartRepo cartRepo;
        private CartService cartService;
        private ICartItemRepo cartItemRepo;
        private CartItemService cartItemService;
        

        public EditCartMenu(User user, StoreContext context, IUserRepo userRepo, ILocationRepo locationRepo, IInventoryItemRepo inventoryItemRepo, IBookRepo bookRepo, ICartRepo cartRepo, ICartItemRepo cartItemRepo) {
            this.signedInUser = user;
            this.userRepo = userRepo;
            this.locationRepo = locationRepo;
            this.inventoryItemRepo = inventoryItemRepo;
            this.bookRepo = bookRepo;
            this.cartRepo = cartRepo;
            this.cartItemRepo = cartItemRepo;

            this.userService = new UserService(userRepo);
            this.locationService = new LocationService(locationRepo);
            this.inventoryService = new InventoryService(inventoryItemRepo);
            this.bookService = new BookService(bookRepo);
            this.cartService = new CartService(cartRepo);
            this.cartItemService = new CartItemService(cartItemRepo);
        }


        public void Start() {

            //Get current user's cart and items
            Cart cart = cartService.GetCartByUserId(signedInUser.id);
            List<CartItem> items = cartItemService.GetAllCartItemsByCartId(cart.id);

            //Display items in current user's cart
            Console.WriteLine("\nItems currently in your cart: ");
            foreach(CartItem item in items) {
                Book book = bookService.GetBookById(item.bookId);
                Console.WriteLine($" - {book.title} | {book.author} | {book.price} | {item.quantity} ");
            } 

            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("[1] Remove Item");
            Console.WriteLine("[2] Change item quantity");
            Console.WriteLine("[3] Back");


            userInput = Console.ReadLine();
            switch(userInput) {
                case "1":
                    Console.WriteLine("Remove Item Selected");
                    // RemoveItemFromCart();
                    break;

                case "2":
                    Console.WriteLine("Change Item Quantity Selected");
                    break;

                case "3":
                    break;

                default:
                    ValidationService.InvalidInput();
                    break;
            }
        }


        //TODO make this work
        public void RemoveItemFromCart() {
            string input;

            do{
                Console.WriteLine("\nSelect item to remove: ");

                Cart cart = cartService.GetCartByUserId(signedInUser.id);
                List<CartItem> items = cartItemService.GetAllCartItemsByCartId(cart.id);
                int i = 0;
                foreach(CartItem item in items) {
                    i++; 
                    Book book = bookService.GetBookById(item.bookId);
                    Console.WriteLine($" [{i}] {book.title} | {book.author} | {book.price} | {item.quantity} ");
                }

                input = Console.ReadLine();
                switch(input) {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                    default:
                        ValidationService.InvalidInput();
                        break;
                }

            } while(!input.Equals("6"));

        }

        //TODO make this work
        public void ChangeCartItemQuantity() {
            string input;

            do{
                Console.WriteLine("\nSelect item to adjust: ");

                Cart cart = cartService.GetCartByUserId(signedInUser.id);
                List<CartItem> items = cartItemService.GetAllCartItemsByCartId(cart.id);
                int i = 0;
                foreach(CartItem item in items) {
                    i++;
                    Book book = bookService.GetBookById(item.bookId);
                    Console.WriteLine($" [{i}] {book.title} | {book.author} | {book.price} | {item.quantity} ");
                }
                
                input = Console.ReadLine();
                switch(input) {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                    default:
                        ValidationService.InvalidInput();
                        break;
                }

            } while(!input.Equals("6"));
        }



    }
}