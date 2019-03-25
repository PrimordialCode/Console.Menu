using System;
using System.Collections.Generic;

namespace EasyConsoleApplication.Menus
{
    public class MenuItem
    {
        public string Title { get; private set; }

        // public List<MenuItem> Items { get; set; } = new List<MenuItem>();

        public Action Action { get; private set; }

        public MenuItem(string title, Action action)
        {
            Title = title;
            Action = action;
        }
    }
}
