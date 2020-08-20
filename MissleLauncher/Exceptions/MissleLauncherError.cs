using System;
using System.Collections.Generic;
using System.Text;

namespace MissleLauncher.Exceptions
{
    public class MissleLauncherError : Exception
    {
        public MissleLauncherError(string message) : base(message)
        {

        }
    }
}
