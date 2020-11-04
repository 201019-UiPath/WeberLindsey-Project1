using StoreUI.Menus;
using StoreDB;
using Serilog;

namespace StoreUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Calls Welcome Menu
            StoreContext context = new StoreContext();
            IMenu welcomeMenu = new WelcomeMenu(context, new DBRepo(context), new DBRepo(context), new DBRepo(context));
            welcomeMenu.Start();
        }
    }
}


