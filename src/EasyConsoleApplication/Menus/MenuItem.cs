namespace EasyConsoleApplication.Menus
{
	/// <summary>
	/// Represents a menu item.
	/// </summary>
	public class MenuItem : IMenuItem
	{
		/// <summary>
		/// The command the user has to type to activate the menu item.
		/// If Empty the position inside the menu will be used.
		/// </summary>
		public string? Command { get; }

		/// <summary>
		/// The title of the menu item.
		/// </summary>
		public string Title { get; }

		/// <summary>
		/// Menu item color.
		/// </summary>
		public ConsoleColor Color { get; set; } = ConsoleSettings.DefaultColor;

		/// <summary>
		/// The action to execute when the menu item is selected.
		/// </summary>
		public Action? Action { get; }

		/// <summary>
		/// The async action to execute when the menu item is selected.
		/// </summary>
		public Func<Task>? ActionAsync { get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="MenuItem"/> class.
		/// </summary>
		public MenuItem(string title, Action action)
			: this(null, title, action)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MenuItem"/> class.
		/// </summary>
		public MenuItem(string? command, string title, Action action)
		{
			Title = title;
			Action = action;
			Command = command;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MenuItem"/> class.
		/// </summary>
		public MenuItem(string title, Func<Task> actionAsync)
			: this(null, title, actionAsync)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MenuItem"/> class.
		/// </summary>
		public MenuItem(string? command, string title, Func<Task> actionAsync)
		{
			Title = title;
			ActionAsync = actionAsync;
			Command = command;
		}
	}
}
