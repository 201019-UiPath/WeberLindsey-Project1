using System;
using StoreDB;
using StoreDB.Models;
using StoreLib;
using StoreDB.Repos;
using System.Collections.Generic;

namespace StoreUI.Menus.CustomerMenus
{
    public class CartMenu : IMenu
    {
        private string userInput;
        private User signedInUser;
        private IUserRepo userRepo;
        private UserService userService;
        private ILocationRepo locationRepo;
        private LocationService locationService;
        private IInventoryItemRepo inventoryItemRepo;
        private InventoryService inventoryService;
        private ICartRepo cartRepo;
        private CartService cartService;
        private ICartItemRepo cartItemRepo;
        private CartItemService cartItemService;
        private IBookRepo bookRepo;
        private BookService bookService;
        private IOrderRepo orderRepo;
        private OrderService orderService;
        private ILineItemRepo lineItemRepo;
        private LineItemService lineItemService;


        private EditCartMenu editCartMenu;

        public CartMenu(User user, StoreContext context, IUserRepo userRepo, ILocationRepo locationRepo, IInventoryItemRepo inventoryItemRepo, IBookRepo bookRepo, ICartRepo cartRepo, ICartItemRepo cartItemRepo, IOrderRepo orderRepo, ILineItemRepo lineItemRepo) {
            this.signedInUser = user;
            this.userRepo = userRepo;
            this.locationRepo = locationRepo;
            this.inventoryItemRepo = inventoryItemRepo;

            this.bookRepo = bookRepo;
            this.cartRepo = cartRepo;
            this.cartItemRepo = cartItemRepo;
            this.orderRepo = orderRepo;
            this.lineItemRepo = lineItemRepo;

            this.userService = new UserService(userRepo);
            this.locationService = new LocationService(locationRepo);
            this.inventoryService = new InventoryService(inventoryItemRepo);

            this.bookService = new BookService(bookRepo);
            this.cartService = new CartService(cartRepo);
            this.cartItemService = new CartItemService(cartItemRepo);
            this.orderService = new OrderService(orderRepo);
            this.lineItemService = new LineItemService(lineItemRepo);

            this.editCartMenu = new EditCartMenu(signedInUser, context, new DBRepo(context), new DBRepo(context), new DBRepo(context), new DBRepo(context), new DBRepo(context), new DBRepo(context));

        }

        /// <summary>
        /// Cart menu to remove items from cart 
        /// and complete purchase order for items in cart
        /// </summary>
        public void Start() {

            do{

                //Get current user's cart and items
                Cart cart = cartService.GetCartByUserId(signedInUser.id);
                List<CartItem> items = cartItemService.GetAllCartItemsByCartId(cart.id);

                //Display items in current user's cart
                Console.WriteLine("\nItems currently in your cart: ");
                foreach(CartItem item in items) {
                    Book book = bookService.GetBookById(item.bookId);
                    Console.WriteLine($" - {book.title} | {book.author} | {book.price} | {item.quantity} ");
                } 


                //Cart menu options
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("[1] Purchase items in cart");
                Console.WriteLine("[2] Edit cart"); 
                Console.WriteLine("[3] Back");

                userInput = Console.ReadLine();

                switch(userInput) {
                    case "1":
                        CheckOut();
                        break;

                    case "2":
                        editCartMenu.Start();
                        break;

                    case "3":
                        break;

                    default:
                        ValidationService.InvalidInput();
                        break;
                }
                        
            } while(!userInput.Equals("3"));

        } 

        /// <summary>
        /// Created new order for customer and adds each cart item to the order
        /// Removes cart items once they are added to the order from the customer's cart
        /// </summary>
        public void CheckOut() {
            //Get current user's cart and items
            Cart cart = cartService.GetCartByUserId(signedInUser.id);
            List<CartItem> items = cartItemService.GetAllCartItemsByCartId(cart.id);

            //Create new order for user
            Order order = new Order();
            double total = 0;
            order.userId = signedInUser.id;
            order.locationId = signedInUser.locationId;
            DateTime orderDate = order.orderDate = DateTime.Now;
            orderService.AddOrder(order);

            Order createdOrder = orderService.GetOrderByDate(orderDate);

            Console.WriteLine("\nYour order has been placed!");
            Console.WriteLine("Receipt:");

            //Create line items and gather total price for order
            foreach(CartItem item in items) {
                Book book = bookService.GetBookById(item.bookId);
                
                LineItem lineItem = new LineItem();
                lineItem.orderId = createdOrder.id;
                lineItem.bookId = item.bookId;
                lineItem.price = book.price;
                lineItem.quantity = item.quantity;                
                
                //Adds cost of each book to the order total
                total += (book.price * item.quantity);

                lineItemService.AddLineItem(lineItem);

                //Remove items from cart as line item is created
                cartItemService.DeleteCartItem(item);

                //Updates location's inventory to reflect purchases have been made and stock removed
                InventoryItem itemInInv = inventoryService.GetItemByLocationIdBookId(signedInUser.locationId, book.id);
                itemInInv.quantity -= item.quantity;
                inventoryService.UpdateInventoryItem(itemInInv);

                Console.WriteLine($"Item: {book.title} {book.author} {book.price} {lineItem.quantity}");
            }

            //Update order's total price
            order.totalPrice = total;
            orderService.UpdateOrder(createdOrder);

            Console.WriteLine($"Your total: {order.totalPrice}");
            Console.WriteLine("Thank you for purchasing from CF Books!");
            
        } 

    }
}