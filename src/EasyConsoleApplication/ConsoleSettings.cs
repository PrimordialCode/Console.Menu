using System;

namespace EasyConsoleApplication.Menus
{
    /// <summary>
    /// Allows to set some global configuration settings
    /// </summary>
    public static class ConsoleSettings
    {
        public static ConsoleColor DefaultColor { get; set; } = ConsoleColor.Gray;
        public static ConsoleColor HitEnterToContinueColor { get; set; } = ConsoleColor.DarkGray;
    }
}
