using System;

namespace EasyConsoleApplication.Menus
{
    internal class MenuRenderer
    {
        public void Render(Menu menu)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(menu.Title);
                for (int idx = 0; idx < menu.Items.Count; idx++)
                {
                    var mi = menu.Items[idx];
                    Console.WriteLine($" {idx + 1} - {mi.Title}");
                }
                string value = ConsoleHelpers.Readline(Console.ForegroundColor, "Select an option: ");

                if (int.TryParse(value, out int option))
                {
                    var selectedIdx = option - 1;
                    if (selectedIdx > -1 && selectedIdx <= menu.Items.Count)
                    {
                        var mi = menu.Items[selectedIdx];
                        mi.Action?.Invoke();

                        ConsoleHelpers.HitEnterToContinue();
                    }
                }
            }
        }
    }
}
