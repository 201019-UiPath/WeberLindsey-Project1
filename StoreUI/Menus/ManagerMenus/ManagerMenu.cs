using System;
using StoreDB;
using StoreDB.Models;
using StoreLib;
using StoreDB.Repos;
using System.Collections.Generic;

namespace StoreUI.Menus.ManagerMenus
{
    /// <summary>
    /// The main menu for managers that were able to log in successfully
    /// </summary>
    public class ManagerMenu : IMenu
    {
        private string userInput;
        private User signedInUser;
        private IUserRepo userRepo;
        private UserService userService;
        private ILocationRepo locationRepo;
        private LocationService locationService;
        private EditInvMenu editInvMenu;


        public ManagerMenu(User user, StoreContext context, IUserRepo userRepo, ILocationRepo locationRepo) {
            this.signedInUser = user;
            this.userRepo = userRepo;
            this.locationRepo = locationRepo;
            this.userService = new UserService(userRepo);
            this.locationService = new LocationService(locationRepo);

            this.editInvMenu = new EditInvMenu(signedInUser, context, new DBRepo(context), new DBRepo(context), new DBRepo(context));
        }


        public void Start() {

            do{
                System.Console.WriteLine("\nWelcome to CF Books! What would you like to do today?");

                //Manager Menu Options
                System.Console.WriteLine("[1] Manage Inventory");
                System.Console.WriteLine("[2] Create Manager User");
                System.Console.WriteLine("[3] Exit");

                userInput = System.Console.ReadLine();
                switch (userInput)
                {
                    case "1" :
                        editInvMenu.Start();
                        break;
                    case "2":
                        User newUser = GetNewManagerDetails();
                        userService.AddUser(newUser);
                        break;
                    case "3":
                        System.Console.WriteLine("Goodbye!");
                        Environment.Exit(0);
                        break;
                    default:
                        ValidationService.InvalidInput();
                        break;
                }

            } while(!userInput.Equals("3"));

        }


        /// <summary>
        /// Obtain user input to create new Manager User account
        /// </summary>
        /// <returns></returns>
        public User GetNewManagerDetails() {
            List<User> users = userService.GetAllUsers();
            User user = new User();
            user.type = User.userType.Manager;
            string selectedLocation;

            do {
                Console.WriteLine("\nEnter name: ");
                user.name = Console.ReadLine();
            } while(ValidationService.ValidName(user.name) == false);
            
            do {
                Console.WriteLine("Enter email: ");
                user.email = Console.ReadLine();
            } while(ValidationService.ValidEmail(user.email) == false);

            do {
                Console.WriteLine("Create a username: ");
                user.username = Console.ReadLine();
            } while(ValidationService.ValidUsername(user.username, users) == false);

            Console.WriteLine("Create a password: ");
            user.password = Console.ReadLine();

            Console.WriteLine("Select preferred location: ");
            Boolean invalidSelection = true;
            do {
                List<Location> locs = locationService.GetAllLocations();
                foreach(Location loc in locs) {
                    Console.WriteLine($" [{loc.id}] {loc.city} {loc.state}");
                }

                selectedLocation = Console.ReadLine();
                switch(selectedLocation) {
                    case "1":
                        user.locationId = 1;
                        invalidSelection = false;
                        break;

                    case "2":
                        user.locationId = 2;
                        invalidSelection = false;
                        break;

                    case "3":
                        user.locationId = 3;
                        invalidSelection = false;
                        break;
                    
                    default:
                        ValidationService.InvalidInput();
                        break;
                } 
            } while (invalidSelection);

            Console.WriteLine("User account created!");
            return user;
        }

    }
}