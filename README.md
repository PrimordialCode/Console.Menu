# EasyConsoleApplication

A small library to create very simple menu-driven console applications.

## Features

- Easy to use.
- Supports nested menus.
- Customizable menu options.

## Installation

To install EasyConsoleApplication, you can use NuGet Package Manager:

`Install-Package EasyConsoleApplication`


Or via .NET CLI:

`dotnet add package EasyConsoleApplication`


## Usage

Here's a basic example of how to use the library:

```csharp
internal static class Program
{
	private static void Main(string[] _)
	{
		// define the application main menu
		var mainMenu = new Menu("Application");
		mainMenu.Items.Add(new MenuItem("Option 1", () => Console.WriteLine("Action 1")));
		mainMenu.Items.Add(new MenuItem("opt2", "Option 2", () => Console.WriteLine("Action 2")));
		mainMenu.Items.Add(new MenuItem("Go to Home", () => Application.GoTo<HomePage>())
		{
			Color = ConsoleColor.Green
		});
		mainMenu.Items.Add(Separator.Instance);
		mainMenu.Items.Add(new MenuItem("Quit", () => Application.Exit()));

		// render the menu
		Application.Render(mainMenu);

		// application ended via Application.Exit
		Console.WriteLine("Application Terminated.");
		ConsoleHelpers.HitEnterToContinue();
	}
}

public class HomePage : Page
{
	public HomePage()
	{
		Title = "Home";
		TitleColor = ConsoleColor.Green;
		Body = "----";
		BodyColor = ConsoleColor.DarkGreen;
		MenuItems.Add(new MenuItem("Page 1", () => Application.GoTo<Page1>()));
		MenuItems.Add(new MenuItem("Page 2", () => Application.GoTo<Page2>()));
		MenuItems.Add(new MenuItem("Page 3", () => Application.GoTo<Page3>("With Dependency"))
		{
			Color = ConsoleColor.Yellow
		});
		MenuItems.Add(Separator.Instance);
		MenuItems.Add(new MenuItem("Back", () => Application.GoBack()));
		MenuItems.Add(new MenuItem("Quit", () => Application.Exit()));
	}
}
```


## Sample Project

Take a look at the sample project to learn how to use the library in more detail. The sample project demonstrates various features and best practices for creating menu-driven console applications.

## Contributing

Contributions are welcome! Please feel free to submit a pull request or open an issue if you have any suggestions or improvements.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.
