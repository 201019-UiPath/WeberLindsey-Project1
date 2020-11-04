using System;
using StoreDB;
using StoreDB.Models;
using StoreLib;
using StoreDB.Repos;
using System.Collections.Generic;

namespace StoreUI.Menus.CustomerMenus
{
    public class ChangeLocationMenu : IMenu
    {
        private string userInput;
        private User signedInUser;
        private IUserRepo userRepo;
        private UserService userService;
        private ILocationRepo locationRepo;
        private LocationService locationService;
        private ICartRepo cartRepo;
        private CartService cartService;
        private ICartItemRepo cartItemRepo;
        private CartItemService cartItemService;
 
        public ChangeLocationMenu(User user, StoreContext context, IUserRepo userRepo, ILocationRepo locationRepo, ICartRepo cartRepo, ICartItemRepo cartItemRepo) {
            this.signedInUser = user;
            this.userRepo = userRepo;
            this.locationRepo = locationRepo;
            this.cartRepo = cartRepo;
            this.cartItemRepo = cartItemRepo;

            this.userService = new UserService(userRepo);
            this.locationService = new LocationService(locationRepo);
            this.cartService = new CartService(cartRepo);
            this.cartItemService = new CartItemService(cartItemRepo);
        }

        /// <summary>
        /// Displays all locations 
        /// and allows options for user to change their preferred shopping location
        /// </summary>
        public void Start() {

            do{

                Console.WriteLine("\nSelect your preferred location: ");

                /// <summary>
                /// Displays all locations for user to select from
                /// </summary>
                /// <returns></returns>
                List<Location> locations = locationService.GetAllLocations();
                foreach(Location location in locations) {
                    Console.WriteLine($" [{location.id}] {location.street1} {location.street2} {location.city} {location.state} {location.postalCode} ");
                }
                Console.WriteLine("[4] Back");

                userInput = Console.ReadLine();
                switch(userInput) {
                    case "1":
                        UpdateUserLocation(1);
                        break;
                    case "2":
                        UpdateUserLocation(2);
                        break;
                    case "3":
                        UpdateUserLocation(3);
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
        /// Update's preferred location for user
        /// and saves location selection
        /// </summary>
        public void UpdateUserLocation(int id) {
            signedInUser.locationId = id;
            userService.UpdateUser(signedInUser);

            //Removes user's cart as they can only purchase from one location at a time
            //And creates new cart for them
            Cart cart = cartService.GetCartByUserId(signedInUser.id);
            cartService.DeleteCart(cart);

            Cart newCart = new Cart();
            newCart.userId = signedInUser.id;
            cartService.AddCart(newCart);

            Console.WriteLine("Location updated!\n");
        }

    }
}