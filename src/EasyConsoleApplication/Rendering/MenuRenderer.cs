using System;
using System.Linq;

namespace EasyConsoleApplication.Menus
{
    internal class Rendering
    {
        /// <summary>
        /// variable that will be chacked to know if it's time
        /// to terminate the loop that keep asking for new commands
        /// from this menu
        /// </summary>
        internal bool terminate;

        /// <summary>
        /// Call exit whenever you want to terminate the loop that
        /// keep asking for new commands from this menu
        /// </summary>
        public void Exit()
        {
            terminate = true;
        }

        public void Render(
            string? title,
            ConsoleColor titleColor,
            string? body,
            ConsoleColor bodyColor,
            Menu menu)
        {
            var menuItems = menu.Items;
            var menuActions = menuItems
                .Where(mi => mi.GetType() == typeof(MenuItem))
                .Cast<MenuItem>()
                .ToList();
            while (true)
            {
                Console.Clear();
                if (!string.IsNullOrWhiteSpace(title))
                {
                    ConsoleHelpers.Write(titleColor, title!, true);
                }
                if (!string.IsNullOrWhiteSpace(body))
                {
                    ConsoleHelpers.Write(bodyColor, body!, true);
                }
                if (menuItems != null)
                {
                    RenderMenuItems(menuItems);

                    Console.WriteLine();
                    var value = ConsoleHelpers.Readline(Console.ForegroundColor, "Select an option: ");

                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        // check the string commands first
                        var selectedMi = menuActions.Find(m => m.Command == value);
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
                                if (selectedIdx > -1 && selectedIdx < menuActions.Count)
                                {
                                    var mi = menuActions[selectedIdx];
                                    if (string.IsNullOrWhiteSpace(mi.Command))
                                    {
                                        ExecuteAction(mi);
                                    }
                                }
                            }
                        }
                    }

                    if (terminate)
                    {
                        break;
                    }
                }
            }
        }

        private static void RenderMenuItems(System.Collections.Generic.List<IMenuItem> menuItems)
        {
            int commandIndex = 0;
            for (int idx = 0; idx < menuItems.Count; idx++)
            {
                switch (menuItems[idx])
                {
                    case MenuItem mi:
                        commandIndex++;
                        var cmd = mi.Command;
                        if (string.IsNullOrWhiteSpace(cmd))
                        {
                            cmd = commandIndex.ToString();
                        }
                        ConsoleHelpers.Write(mi.Color, $" {cmd} - {mi.Title}", true);
                        break;
                    case Separator sep:
                        ConsoleHelpers.Write(sep.Color, $" {sep.Title}", true);
                        break;
                }
            }
        }

        /// <summary>
        /// Execute the command and decide if its time to terminare the
        /// command loop
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="mi"></param>
        /// <returns>
        /// true = terminate the loop
        /// false = keep asking for another command
        /// </returns>
        private void ExecuteAction(MenuItem mi)
        {
            mi.Action?.Invoke();
            mi.ActionAsync?.Invoke().Wait();

            if (!terminate)
            {
                ConsoleHelpers.HitEnterToContinue();
            }
        }
    }
}
