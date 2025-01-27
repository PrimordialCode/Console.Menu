namespace EasyConsoleApplication.Menus
{
	/// <summary>
	/// Represents a menu.
	/// </summary>
	public class Menu : IMenuItem
	{
		/// <summary>
		/// The title of the menu.
		/// </summary>
		public string? Title { get; set; }

		/// <summary>
		/// Menu color.
		/// </summary>
		public ConsoleColor Color { get; set; } = ConsoleSettings.DefaultColor;

		/// <summary>
		/// The items in the menu.
		/// </summary>
		public List<IMenuItem> Items { get; set; } = [];

		/// <summary>
		/// Initializes a new instance of the <see cref="Menu"/> class.
		/// </summary>
		internal Menu() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="Menu"/> class.
		/// </summary>
		public Menu(string title)
		{
			Title = title;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Menu"/> class.
		/// </summary>
		public Menu(string title, ConsoleColor color)
		{
			Title = title;
			Color = color;
		}
	}
}
