using System;

namespace EasyConsoleApplication.Menus
{
    public class Separator : IMenuItem
    {
        public static Separator Instance { get; } = new Separator();

        public string Title { get; private set; }

        public ConsoleColor Color { get; set; } = ConsoleColor.White;

        public Separator()
        {
        }

        public Separator(string title)
        {
            Title = title;
        }
    }
}
