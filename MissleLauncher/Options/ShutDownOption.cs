using MenuBuilder.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissleLauncher.Options
{
    public class ShutDownOption : IOptions
    {
        public void Operation()
        {
            Environment.Exit(1);
        }
    }
}
