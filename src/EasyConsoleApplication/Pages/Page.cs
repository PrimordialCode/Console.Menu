using EasyConsoleApplication.Menus;
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

        public List<MenuItem> MenuItems
        {
            get { return Menu.Items; }
        }
    }
}
