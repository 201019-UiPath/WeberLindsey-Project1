using System;
using StoreDB;
using StoreDB.Models;
using StoreLib;
using StoreDB.Repos;
using System.Collections.Generic;

namespace StoreUI.Menus.CustomerMenus
{
    public class OrderHistoryMenu : IMenu
    {
        private string userInput;
        private User signedInUser;
        private IUserRepo userRepo;
        private UserService userService;
        private IInventoryItemRepo inventoryItemRepo;
        private InventoryService inventoryService;
        private IBookRepo bookRepo;
        private BookService bookService;
        private IOrderRepo orderRepo;
        private OrderService orderService;
        private ILineItemRepo lineItemRepo;
        private LineItemService lineItemService;
        private ILocationRepo locationRepo;
        private LocationService locationService;

        public OrderHistoryMenu(User user, StoreContext context, IUserRepo userRepo, IInventoryItemRepo inventoryItemRepo, IBookRepo bookRepo, IOrderRepo orderRepo, ILineItemRepo lineItemRepo, ILocationRepo locationRepo) {
            this.signedInUser = user;
            this.userRepo = userRepo;
            this.bookRepo = bookRepo;
            this.orderRepo = orderRepo;
            this.lineItemRepo = lineItemRepo;
            this.locationRepo = locationRepo;

            this.inventoryItemRepo = inventoryItemRepo;
            this.userService = new UserService(userRepo);
            this.inventoryService = new InventoryService(inventoryItemRepo);
            this.bookService = new BookService(bookRepo);
            this.orderService = new OrderService(orderRepo);
            this.lineItemService = new LineItemService(lineItemRepo);
            this.locationService = new LocationService(locationRepo);
        }

        /// <summary>
        /// Outputs user's previous order history at all locations
        /// and provides options to sort orders by Date and Cost
        /// </summary>
        public void Start() {
            do {
                //TODO add ability to view order history by locations (select a location before the orders are displayed)

                Console.WriteLine("How would you like to view your previous orders? ");

                Console.WriteLine("[1] Sort By Date Asc");
                Console.WriteLine("[2] Sort By Date Desc");
                Console.WriteLine("[3] Sort By Price Asc");
                Console.WriteLine("[4] Sort By Price Desc");
                Console.WriteLine("[5] Back");

                userInput = Console.ReadLine();
                switch(userInput) {
                    case "1":
                        GetOrdersSortedByDateAsc();
                        break;

                    case "2":
                        GetOrdersSortedByDateDesc();
                        break;

                    case "3":
                        GetOrdersSortedByPriceAsc();
                        break;

                    case "4":
                        GetOrdersSortedByPriceDesc(); 
                        break;

                    case "5":
                        break;

                    default:
                        ValidationService.InvalidInput();
                        break;
                }

            } while(!userInput.Equals("5"));

        }

        /// <summary>
        /// Gets all orders for signed in user and sorts by date ascending
        /// </summary>
        public void GetOrdersSortedByDateAsc() {
            Console.WriteLine("\nPrevious orders: ");

            List<Order> orders = orderService.GetAllOrdersByUserIdDateAsc(signedInUser.id);
            foreach(Order order in orders) {
                Location location = locationService.GetLocationById(order.locationId);
                Console.WriteLine($" Date: {order.orderDate} | Total: {order.totalPrice} | Location: {location.city}, {location.state} ");

                Console.WriteLine($"\tLine Items: ");
                List<LineItem> items = lineItemService.GetAllLineItemsByOrderId(order.id);
                foreach(LineItem item in items) {
                    Book book = bookService.GetBookById(item.bookId);
                    Console.WriteLine($"\tBook: {book.title} by  {book.author} | Price: {item.price} | Quantity: {item.quantity}");
                }
                Console.WriteLine("\n");
            }
        }
        
        /// <summary>
        /// Gets all orders for signed in user and sorts by date descending
        /// </summary>
        public void GetOrdersSortedByDateDesc() {
            Console.WriteLine("\nPrevious orders: ");

            List<Order> orders = orderService.GetAllOrdersByUserIdDateDesc(signedInUser.id);
            foreach(Order order in orders) {
                Location location = locationService.GetLocationById(order.locationId);
                Console.WriteLine($" Date: {order.orderDate} | Total: {order.totalPrice} | Location: {location.city}, {location.state} ");

                Console.WriteLine($"\tLine Items: ");
                List<LineItem> items = lineItemService.GetAllLineItemsByOrderId(order.id);
                foreach(LineItem item in items) {
                    Book book = bookService.GetBookById(item.bookId);
                    Console.WriteLine($"\tBook: {book.title} by  {book.author} | Price: {item.price} | Quantity: {item.quantity}");
                }
                Console.WriteLine("\n");
            }
        }

        /// <summary>
        /// Gets all orders for signed in user and sorts by price ascending
        /// </summary>
        public void GetOrdersSortedByPriceAsc() {
            Console.WriteLine("\nPrevious orders: ");

            List<Order> orders = orderService.GetAllOrdersByUserIdPriceAsc(signedInUser.id);
            foreach(Order order in orders) {
                Location location = locationService.GetLocationById(order.locationId);
                Console.WriteLine($" Date: {order.orderDate} | Total: {order.totalPrice} | Location: {location.city}, {location.state} ");

                Console.WriteLine($"\tLine Items: ");
                List<LineItem> items = lineItemService.GetAllLineItemsByOrderId(order.id);
                foreach(LineItem item in items) {
                    Book book = bookService.GetBookById(item.bookId);
                    Console.WriteLine($"\tBook: {book.title} by  {book.author} | Price: {item.price} | Quantity: {item.quantity}");
                }
                Console.WriteLine("\n");
            }
        }

        /// <summary>
        /// Gets all orders for signed in user and sorts by price descending
        /// </summary>
        public void GetOrdersSortedByPriceDesc() {
            Console.WriteLine("\nPrevious orders: ");

            List<Order> orders = orderService.GetAllOrdersByUserIdPriceDesc(signedInUser.id);
            foreach(Order order in orders) {
                Location location = locationService.GetLocationById(order.locationId);
                Console.WriteLine($" Date: {order.orderDate} | Total: {order.totalPrice} | Location: {location.city}, {location.state} ");

                Console.WriteLine($"\tLine Items: ");
                List<LineItem> items = lineItemService.GetAllLineItemsByOrderId(order.id);
                foreach(LineItem item in items) {
                    Book book = bookService.GetBookById(item.bookId);
                    Console.WriteLine($"\tBook: {book.title} by  {book.author} | Price: {item.price} | Quantity: {item.quantity}");
                }
                Console.WriteLine("\n");
            }
        }



    }
}