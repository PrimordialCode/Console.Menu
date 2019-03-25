using EasyConsoleApplication.Menus;
using System;

namespace EasyConsoleApplication.Example
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            // define the menu
            Menu mainMenu = new Menu("Application");
            mainMenu.Items.Add(new MenuItem("Option 1", () => Console.WriteLine("Action 1")));
            mainMenu.Items.Add(new MenuItem("Option 2", () => Console.WriteLine("Action 2")));
            mainMenu.Items.Add(new MenuItem("Quit", () => Environment.Exit(0)));

            // render the menu
            Application.Render(mainMenu);

            Console.WriteLine("Hello World!");
        }
    }
}
