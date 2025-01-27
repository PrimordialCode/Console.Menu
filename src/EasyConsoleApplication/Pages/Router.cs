using EasyConsoleApplication.Rendering;

namespace EasyConsoleApplication.Pages
{
	/// <summary>
	/// Router: allows navigation between pages.
	/// </summary>
	public class Router
	{
		// the top of the stack is the current page
		private readonly Stack<Tuple<Type, object[]>> _history = new();
		private readonly MenuRenderer _menuRenderer = new();

		/// <summary>
		/// Go to a page.
		/// </summary>
		/// <typeparam name="T">Page Type</typeparam>
		/// <param name="args">Optional arguments to be passed to Page constructor</param>
		public void GoTo<T>(params object[] args) where T : Page
		{
			var page = typeof(T);
			_history.Push(new Tuple<Type, object[]>(page, args));
			RenderPage(page, args);
		}

		/// <summary>
		/// Go back to the previous page.
		/// </summary>
		public void GoBack()
		{
			if (_history.Count > 1)
			{
				_history.Pop();
				var prevPage = _history.Peek();
				RenderPage(prevPage.Item1, prevPage.Item2);
			}
		}

		/// <summary>
		/// Exit the application.
		/// </summary>
		public void Exit()
		{
			_menuRenderer.Exit();
		}

		private void RenderPage(Type page, params object[] args)
		{
			Page p = (Page)Activator.CreateInstance(page, args)!;
			// render a breadcrumb ?
			_menuRenderer.Render(p.Title, p.TitleColor, p.Body, p.BodyColor, p.Menu);
		}
	}
}
