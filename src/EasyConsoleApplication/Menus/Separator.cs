using System;

namespace EasyConsoleApplication.Menus
{
    public class Separator : IMenuItem
    {
        public static Separator Instance { get; } = new Separator();

        public string? Title { get; }

        public ConsoleColor Color { get; set; } = ConsoleSettings.DefaultColor;

        public Separator()
        {
        }

        public Separator(string title)
        {
            Title = title;
        }
    }
}
