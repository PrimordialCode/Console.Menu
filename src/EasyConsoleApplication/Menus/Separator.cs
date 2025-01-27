namespace EasyConsoleApplication.Menus
{
	/// <summary>
	/// Represents a separator in a menu.
	/// </summary>
	public class Separator : IMenuItem
	{
		/// <summary>
		/// Separator instance.
		/// </summary>
		public static Separator Instance { get; } = new Separator();

		/// <summary>
		/// The title of the separator.
		/// </summary>
		public string? Title { get; }

		/// <summary>
		/// Separator color.
		/// </summary>
		public ConsoleColor Color { get; set; } = ConsoleSettings.DefaultColor;

		/// <summary>
		/// Initializes a new instance of the <see cref="Separator"/> class.
		/// </summary>
		public Separator()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Separator"/> class.
		/// </summary>
		/// <param name="title"></param>
		public Separator(string title)
		{
			Title = title;
		}
	}
}
