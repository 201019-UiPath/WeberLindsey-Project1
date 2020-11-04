using System;
using StoreDB;
using StoreDB.Models;
using StoreLib;
using StoreDB.Repos;
using System.Collections.Generic;

namespace StoreUI.Menus.ManagerMenus
{
    public class EditInvMenu : IMenu
    {
        private string userInput;
        private Book selectedBook;
        private int selectedLocationId;
        private InventoryItem selectedItem;
        private User signedInUser;
        private StoreContext context;
        private ILocationRepo locationRepo;
        private LocationService locationService;
        private IInventoryItemRepo inventoryItemRepo;
        private InventoryService inventoryService;
        private IBookRepo bookRepo;
        private BookService bookService;

        public EditInvMenu(User user, StoreContext context, ILocationRepo locationRepo, IInventoryItemRepo inventoryItemRepo, IBookRepo bookRepo) {
            this.signedInUser = user;
            this.context = context;
            this.locationRepo = locationRepo;
            this.inventoryItemRepo = inventoryItemRepo;
            this.bookRepo = bookRepo;
            this.locationService = new LocationService(locationRepo);
            this.inventoryService = new InventoryService(inventoryItemRepo);
            this.bookService = new BookService(bookRepo);
        }

        public void Start() {

            do {
                Console.WriteLine("\nSelect location to manage: ");

                List<Location> locs = locationService.GetAllLocations();
                foreach(Location loc in locs) {
                    Console.WriteLine($" [{loc.id}] {loc.street1} {loc.street2} {loc.city} {loc.state} {loc.postalCode} ");
                }

                Console.WriteLine("[4] Back");

                userInput = Console.ReadLine();
                selectedLocationId = Int32.Parse(userInput);

                switch(userInput) {
                    case "1":
                        EditInventory(1);
                        break;

                    case "2":
                        EditInventory(2);
                        break;

                    case "3":
                        EditInventory(3);
                        break;

                    case "4":
                        break;

                    default:
                        ValidationService.InvalidInput();
                        break;
                }

            } while(!userInput.Equals("4"));
        }


        /// <summary>
        /// Gets a list of all products at the manager's selected location
        /// </summary>
        /// <returns></returns>
        public List<InventoryItem> GetProductsForLocation(int locationId) {
            List<InventoryItem> items = inventoryService.GetAllInventoryItemsByLocationId(locationId);
            return items;
        }


        public void EditInventory(int locationId) {
            string input;

            do {
                Console.WriteLine("\nSelect an item to replenish: ");

                List<InventoryItem> items = GetProductsForLocation(locationId);
                foreach(InventoryItem item in items) {
                    Book book = bookService.GetBookById(item.bookId);
                    Console.WriteLine($" [{book.id}] {book.title} | {book.author} | {book.price} | Quantity: {item.quantity} ");
                }
                Console.WriteLine("[6] Back");

                input = Console.ReadLine();
                switch(input) {
                    case "1":
                        ReplenishStock(1);
                        break;

                    case "2":
                        ReplenishStock(2);
                        break;

                    case "3":
                        ReplenishStock(3);
                        break;

                    case "4":
                        ReplenishStock(4);            
                        break;

                    case "5":
                        ReplenishStock(5);                     
                        break;

                    case "6":
                        break;

                    default:
                        ValidationService.InvalidInput();
                        break;
                }

            } while(!input.Equals("6"));

        }

        public void ReplenishStock(int bookId) {
            selectedItem = inventoryService.GetItemByLocationIdBookId(selectedLocationId, bookId);
            Console.WriteLine("\nHow many would you like to add to the current stock?");
            int amount = Int32.Parse(Console.ReadLine());

            selectedItem.quantity = amount + selectedItem.quantity;
            inventoryService.UpdateInventoryItem(selectedItem);

            Console.WriteLine("Order submitted!");
        }

    }
}