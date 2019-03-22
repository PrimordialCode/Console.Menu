using EasyConsoleApplication.Menus;

namespace EasyConsoleApplication
{
    public static class Application
    {
        public static void Render(Menu menu)
        {
            var menuRenderer = new MenuRenderer();
            menuRenderer.Render(menu);
        }
    }
}
