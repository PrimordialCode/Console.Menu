using EasyConsoleApplication.Menus;
using System;
using System.Collections.Generic;

namespace EasyConsoleApplication.Pages
{
    public class Router
    {
        // the top of the stack is the current page
        private readonly Stack<Tuple<Type, object[]>> _history = new Stack<Tuple<Type, object[]>>();
        private readonly Rendering _menuRenderer = new Rendering();

        public void GoTo<T>(params object[] args) where T : Page
        {
            var page = typeof(T);
            _history.Push(new Tuple<Type, object[]>(page, args));
            RenderPage(page, args);
        }

        public void GoBack()
        {
            if (_history.Count > 1)
            {
                _history.Pop();
                var prevPage = _history.Peek();
                RenderPage(prevPage.Item1, prevPage.Item2);
            }
        }

        public void Exit()
        {
            _menuRenderer.Exit();
        }

        private void RenderPage(Type page, params object[] args)
        {
            Page p = (Page)Activator.CreateInstance(page, args);
            // render a breadcrumb ?
            _menuRenderer.Render(p.Title, p.TitleColor, p.Body, p.BodyColor, p.Menu);
        }
    }
}
