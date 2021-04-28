using System;

namespace EasyConsoleApplication.Menus
{
    public interface IMenuItem
    {
        string? Title { get; }

        ConsoleColor Color { get; }
    }
}
