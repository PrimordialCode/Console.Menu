using System;
using System.Collections.Generic;

namespace EasyConsoleApplication.Menus
{
    internal class Rendering
    {
        public void Render(
            string title,
            string body,
            List<MenuItem> menuItems)
        {
            while (true)
            {
                Console.Clear();
                if (!string.IsNullOrWhiteSpace(title))
                {
                    Console.WriteLine(title);
                }
                if (!string.IsNullOrWhiteSpace(body))
                {
                    Console.WriteLine(body);
                }
                if (menuItems != null)
                {
                    for (int idx = 0; idx < menuItems.Count; idx++)
                    {
                        var mi = menuItems[idx];
                        Console.WriteLine($" {idx + 1} - {mi.Title}");
                    }
                    string value = ConsoleHelpers.Readline(Console.ForegroundColor, "Select an option: ");

                    if (int.TryParse(value, out int option))
                    {
                        var selectedIdx = option - 1;
                        if (selectedIdx > -1 && selectedIdx < menuItems.Count)
                        {
                            var mi = menuItems[selectedIdx];
                            mi.Action?.Invoke();

                            ConsoleHelpers.HitEnterToContinue();
                        }
                    }
                }
            }
        }
    }
}
