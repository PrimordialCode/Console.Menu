using System;
using System.Collections.Generic;

namespace EasyConsoleApplication.Menus
{
    public class Menu : IMenuItem
    {
        public string? Title { get; set; }
        public ConsoleColor Color { get; set; } = ConsoleSettings.DefaultColor;

        public List<IMenuItem> Items { get; set; } = new List<IMenuItem>();

        internal Menu() { }

        public Menu(string title)
        {
            Title = title;
        }

        public Menu(string title, ConsoleColor color)
        {
            Title = title;
            Color = color;
        }
    }
}
