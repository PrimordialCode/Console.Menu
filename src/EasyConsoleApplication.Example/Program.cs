using EasyConsoleApplication.Menus;
using EasyConsoleApplication.Pages;
using System;

namespace EasyConsoleApplication.Example
{
    internal static class Program
    {
        private static void Main(string[] _)
        {
            // define the menu
            Menu mainMenu = new Menu("Application");
            mainMenu.Items.Add(new MenuItem("Option 1", () => Console.WriteLine("Action 1")));
            mainMenu.Items.Add(new MenuItem("Option 2", () => Console.WriteLine("Action 2")));
            mainMenu.Items.Add(new MenuItem("Go to Home", () => Application.GoTo<HomePage>()));
            mainMenu.Items.Add(new MenuItem("Quit", () => Environment.Exit(0)));

            // render the menu
            Application.Render(mainMenu);

            Console.WriteLine("Hello World!");
        }
    }

    public class HomePage : Page
    {
        public HomePage()
        {
            Title = "Home";
            Body = "----";
            MenuItems.Add(new MenuItem("Page 1", () => Application.GoTo<Page1>()));
            MenuItems.Add(new MenuItem("Page 2", () => Application.GoTo<Page2>()));
            MenuItems.Add(new MenuItem("Quit", () => Environment.Exit(0)));
        }
    }

    public class Page1 : Page
    {
        public Page1()
        {
            Title = "Page1";
            Body = "-----";
            MenuItems.Add(new MenuItem("Option 1", () => Console.WriteLine("Action 1")));
            MenuItems.Add(new MenuItem("Option 2", () => Console.WriteLine("Action 2")));
            MenuItems.Add(new MenuItem("Back", () => Application.GoBack()));
            MenuItems.Add(new MenuItem("Quit", () => Environment.Exit(0)));
        }
    }

    public class Page2 : Page
    {
        public Page2()
        {
            Title = "Page2";
            Body = "-----";
            MenuItems.Add(new MenuItem("Option 1", () => Console.WriteLine("Action 1")));
            MenuItems.Add(new MenuItem("Option 2", () => Console.WriteLine("Action 2")));
            MenuItems.Add(new MenuItem("Back", () => Application.GoBack()));
            MenuItems.Add(new MenuItem("Quit", () => Environment.Exit(0)));
        }
    }
}
