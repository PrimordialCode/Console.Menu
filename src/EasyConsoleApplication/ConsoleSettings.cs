namespace EasyConsoleApplication
{
	/// <summary>
	/// Allows to set some global configuration settings
	/// </summary>
	public static class ConsoleSettings
	{
		/// <summary>
		/// The default color for the console.
		/// </summary>
		public static ConsoleColor DefaultColor { get; set; } = ConsoleColor.Gray;
		/// <summary>
		/// The color for the "Hit Enter to continue." message.
		/// </summary>
		public static ConsoleColor HitEnterToContinueColor { get; set; } = ConsoleColor.DarkGray;
	}
}
