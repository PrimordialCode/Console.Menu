using EasyConsoleApplication.Menus;

namespace EasyConsoleApplication.Pages
{
	/// <summary>
	/// Base class for a page.
	/// </summary>
	public abstract class Page
	{
		/// <summary>
		/// Menu instance.
		/// </summary>
		public Menu Menu { get; } = new Menu();

		/// <summary>
		/// The title of the page.
		/// </summary>
		public string? Title
		{
			get { return Menu.Title; }
			protected set { Menu.Title = value; }
		}

		/// <summary>
		/// Title color.
		/// </summary>
		public ConsoleColor TitleColor
		{
			get { return Menu.Color; }
			protected set { Menu.Color = value; }
		}

		/// <summary>
		/// The body of the page.
		/// </summary>
		public string? Body { get; set; }

		/// <summary>
		/// Body color.
		/// </summary>
		public ConsoleColor BodyColor { get; set; } = ConsoleSettings.DefaultColor;

		/// <summary>
		/// List of menu items.
		/// </summary>
		public List<IMenuItem> MenuItems
		{
			get { return Menu.Items; }
		}
	}
}
