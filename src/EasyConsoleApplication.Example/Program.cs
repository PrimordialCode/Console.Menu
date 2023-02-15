using EasyConsoleApplication.Menus;
using EasyConsoleApplication.Pages;
using System;
using System.Threading.Tasks;

namespace EasyConsoleApplication.Example
{
    internal static class Program
    {
        private static void Main(string[] _)
        {
            // set some global settings
            ConsoleSettings.DefaultColor = ConsoleColor.White;

            // define the menu
            var mainMenu = new Menu("Application");
            mainMenu.Items.Add(new MenuItem("Option 1", () => Console.WriteLine("Action 1")));
            mainMenu.Items.Add(new MenuItem("opt2", "Option 2", () => Console.WriteLine("Action 2")));
            mainMenu.Items.Add(new MenuItem("Go to Home", () => Application.GoTo<HomePage>())
            {
                Color = ConsoleColor.Green
            });
            mainMenu.Items.Add(new MenuItem("Option 3 (async)", async () =>
            {
                Console.WriteLine("Action 2");
                Console.WriteLine("... delay ...");
                await Task.Delay(1000).ConfigureAwait(false);
                Console.WriteLine("Action 2 Completed");
            }));
            mainMenu.Items.Add(Separator.Instance);
            mainMenu.Items.Add(new MenuItem("Quit", () => Application.Exit()));

            // render the menu
            Application.Render(mainMenu);

            // application ended via Application.Exit
            Console.WriteLine("Application Terminated.");
            ConsoleHelpers.HitEnterToContinue();
        }
    }

    public class HomePage : Page
    {
        public HomePage()
        {
            Title = "Home";
            TitleColor = ConsoleColor.Green;
            Body = "----";
            BodyColor = ConsoleColor.DarkGreen;
            MenuItems.Add(new MenuItem("Page 1", () => Application.GoTo<Page1>()));
            MenuItems.Add(new MenuItem("Page 2", () => Application.GoTo<Page2>()));
            MenuItems.Add(new MenuItem("Page 3", () => Application.GoTo<Page3>("With Dependency"))
            {
                Color = ConsoleColor.Yellow
            });
            MenuItems.Add(Separator.Instance);
            MenuItems.Add(new MenuItem("Quit", () => Application.Exit()));
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
            MenuItems.Add(new MenuItem("opt3", "Option 3", () => Console.WriteLine("Action 3")));
            MenuItems.Add(Separator.Instance);
            MenuItems.Add(new MenuItem("exit", "Menu Exit", () => Application.Exit()));
            MenuItems.Add(Separator.Instance);
            MenuItems.Add(new MenuItem("Back", () => Application.GoBack()));
            MenuItems.Add(new MenuItem("Quit", () => Application.Exit()));
        }
    }

    public class Page2 : Page
    {
        public Page2()
        {
            Title = "Page2";
            Body = "-----";
            MenuItems.Add(new MenuItem("opt1", "Option 1", () => Console.WriteLine("Action 1")));
            MenuItems.Add(new MenuItem("Option 2", () => Console.WriteLine("Action 2")));
            MenuItems.Add(new MenuItem("Option 3", () => Console.WriteLine("Action 3")));
            MenuItems.Add(Separator.Instance);
            MenuItems.Add(new MenuItem("Back", () => Application.GoBack()));
            MenuItems.Add(new MenuItem("Quit", () => Application.Exit()));
        }
    }

    public class Page3 : Page
    {
        private readonly string _dependency;

        public Page3(string dependency)
        {
            _dependency = dependency;
            Title = "Page3";
            Body = "-----";
            MenuItems.Add(new MenuItem("opt1", "Option 1", () => Console.WriteLine($"{_dependency} Action 1")));
            MenuItems.Add(new MenuItem("Option 2", () => Console.WriteLine($"{_dependency} Action 2")));
            MenuItems.Add(new MenuItem("Option 3", () => Console.WriteLine($"{_dependency} Action 3")));
            MenuItems.Add(Separator.Instance);
            MenuItems.Add(new MenuItem("Back", () => Application.GoBack()));
            MenuItems.Add(new MenuItem("Quit", () => Application.Exit()));
        }
    }
}
