using System;
using System.Collections.Generic;
using System.Linq;

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
                        var cmd = mi.Command;
                        if (string.IsNullOrWhiteSpace(cmd))
                        {
                            cmd = (idx + 1).ToString();
                        }
                        Console.WriteLine($" {cmd} - {mi.Title}");
                    }
                    string value = ConsoleHelpers.Readline(Console.ForegroundColor, "Select an option: ");

                    // check the string commands first
                    var selectedMi = menuItems.Find(m => m.Command == value);
                    if (selectedMi != null)
                    {
                        ExecuteAction(selectedMi);
                    }
                    else
                    {
                        // use the positional value (only if the Command property does not have a value).
                        if (int.TryParse(value, out int option))
                        {
                            var selectedIdx = option - 1;
                            if (selectedIdx > -1 && selectedIdx < menuItems.Count)
                            {
                                var mi = menuItems[selectedIdx];
                                if (string.IsNullOrWhiteSpace(mi.Command))
                                {
                                    ExecuteAction(mi);
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void ExecuteAction(MenuItem mi)
        {
            mi.Action?.Invoke();

            ConsoleHelpers.HitEnterToContinue();
        }
    }
}
