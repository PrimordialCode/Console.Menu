using EasyConsoleApplication.Menus;
using System;

namespace EasyConsoleApplication.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // todo: define the menu
            Menu mainMenu = new Menu("Application");
            mainMenu.Items.Add(new MenuItem("Option 1"));
            mainMenu.Items.Add(new MenuItem("Option 2"));

            // todo: render the menu
            Application.Render(mainMenu);

            Console.WriteLine("Hello World!");
        }
    }
}
