using System.Collections.Generic;

namespace EasyConsoleApplication.Menus
{
    public class Menu : IMenuItem
    {
        public string Title { get; set; }

        public List<IMenuItem> Items { get; set; } = new List<IMenuItem>();

        internal Menu() { }

        public Menu(string title)
        {
            Title = title;
        }
    }
}
