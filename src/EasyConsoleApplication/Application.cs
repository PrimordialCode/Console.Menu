using EasyConsoleApplication.Menus;
using EasyConsoleApplication.Pages;
using EasyConsoleApplication.Rendering;

namespace EasyConsoleApplication
{
	/// <summary>
	/// Represents the whole console application.
	/// </summary>
	public static class Application
	{
		private static MenuRenderer? MenuRendering;

		/// <summary>
		/// Render the menu.
		/// </summary>
		public static void Render(Menu menu)
		{
			MenuRendering = new();
			MenuRendering.Render(menu.Title, menu.Color, null, ConsoleSettings.DefaultColor, menu);
		}

		private static readonly Router Router = new();

		/// <summary>
		/// Go to the specified page.
		/// </summary>
		/// <typeparam name="TPage">The Page Type</typeparam>
		/// <param name="args">Arguments that will be passed to page constructor</param>
		public static void GoTo<TPage>(params object[] args) where TPage : Page
		{
			Router.GoTo<TPage>(args);
		}

		/// <summary>
		/// Go back to the previous page.
		/// </summary>
		public static void GoBack()
		{
			Router.GoBack();
		}

		/// <summary>
		/// Call exit whenever you want to terminate the loop that
		/// keep asking for new commands from this menu
		/// </summary>
		public static void Exit()
		{
			MenuRendering?.Exit();
			Router.Exit();
		}
	}
}
