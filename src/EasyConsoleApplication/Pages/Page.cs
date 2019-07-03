using EasyConsoleApplication.Menus;
using System;
using System.Collections.Generic;

namespace EasyConsoleApplication.Pages
{
    public abstract class Page
    {
        public Menu Menu { get; } = new Menu();

        public string Title
        {
            get { return Menu.Title; }
            protected set { Menu.Title = value; }
        }

        public ConsoleColor TitleColor
        {
            get { return Menu.Color; }
            protected set { Menu.Color = value; }
        }

        public string Body { get; set; }

        public ConsoleColor BodyColor { get; set; } = ConsoleColor.White;

        public List<IMenuItem> MenuItems
        {
            get { return Menu.Items; }
        }
    }
}
