using MenuBuilder.Menus;
using MenuBuilder.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissleLauncher.Options
{
    public class NavigateMenu : IOptions
    {
        private IMenu _menu;
        public NavigateMenu(IMenu menu)
        {
            _menu = menu;
        }

        public void Operation()
        {
            _menu.Run();
        }
    }
}
