namespace EasyConsoleApplication.Menus
{
	/// <summary>
	/// Represents a menu item.
	/// </summary>
	public interface IMenuItem
	{
		/// <summary>
		/// The title of the menu item.
		/// </summary>
		string? Title { get; }

		/// <summary>
		/// Menu item color.
		/// </summary>
		ConsoleColor Color { get; }
	}
}
