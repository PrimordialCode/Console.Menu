using EasyConsoleApplication.Menus;
using EasyConsoleApplication.Pages;

namespace EasyConsoleApplication
{
    public static class Application
    {
        public static void Render(Menu menu)
        {
            var menuRenderer = new MenuRenderer();
            menuRenderer.Render(menu);
        }

        private static readonly Router Router = new Router();

        public static void GoTo<TPage>() where TPage : Page
        {
            Router.GoTo<TPage>();
        }

        public static void GoBack()
        {
            Router.GoBack();
        }
    }
}
