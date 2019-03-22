using System.Collections.Generic;

namespace EasyConsoleApplication.Menus
{
    public class MenuItem
    {
        public string Title { get; set; }

        public List<MenuItem> Items { get; set; } = new List<MenuItem>();

        public MenuItem(string title)
        {
            Title = title;
        }
    }
}
