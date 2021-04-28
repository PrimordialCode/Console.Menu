using System;
using System.Threading.Tasks;

namespace EasyConsoleApplication.Menus
{
    public class MenuItem : IMenuItem
    {
        /// <summary>
        /// The command the user has to type to activate the menu item.
        /// If Empty the position inside the menu will be used.
        /// </summary>
        public string? Command { get; }

        public string Title { get; }
        public ConsoleColor Color { get; set; } = ConsoleSettings.DefaultColor;

        public Action? Action { get; }
        public Func<Task>? ActionAsync { get; }

        public MenuItem(string title, Action action)
            : this(null, title, action)
        {
        }

        public MenuItem(string? command, string title, Action action)
        {
            Title = title;
            Action = action;
            Command = command;
        }

        public MenuItem(string title, Func<Task> actionAsync)
            : this(null, title, actionAsync)
        {
        }

        public MenuItem(string? command, string title, Func<Task> actionAsync)
        {
            Title = title;
            ActionAsync = actionAsync;
            Command = command;
        }
    }
}
