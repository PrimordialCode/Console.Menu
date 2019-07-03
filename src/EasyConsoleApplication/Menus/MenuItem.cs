using System;

namespace EasyConsoleApplication.Menus
{
    public class MenuItem : IMenuItem
    {
        /// <summary>
        /// The command the user has to type to activate the menu item.
        /// If Empty the position inside the menu will be used.
        /// </summary>
        public string Command { get; private set; }

        public string Title { get; private set; }
        public ConsoleColor Color { get; set; } = ConsoleColor.White;

        public Action Action { get; private set; }

        public MenuItem(string title, Action action)
            : this(null, title, action)
        {
        }

        public MenuItem(string command, string title, Action action)
        {
            Title = title;
            Action = action;
            Command = command;
        }
    }
}
