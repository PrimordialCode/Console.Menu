using EasyConsoleApplication.Menus;
using System;
using System.Collections.Generic;

namespace EasyConsoleApplication.Pages
{
    public class Router
    {
        // the top of the stack is the current page
        private readonly Stack<Type> _history = new Stack<Type>();
        private readonly Rendering _menuRenderer = new Rendering();

        public void GoTo<T>() where T : Page
        {
            var page = typeof(T);
            _history.Push(page);
            RenderPage(page);
        }

        public void GoBack()
        {
            if (_history.Count > 1)
            {
                _history.Pop();
                var prevPage = _history.Peek();
                RenderPage(prevPage);
            }
        }

        private void RenderPage(Type page)
        {
            Page p = (Page)Activator.CreateInstance(page);
            // render a breadcrumb ?
            _menuRenderer.Render(p.Title, p.Body, p.Menu.Items);
        }
    }
}
