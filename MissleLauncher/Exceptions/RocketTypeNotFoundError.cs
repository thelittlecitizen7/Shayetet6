using System;
using System.Collections.Generic;
using System.Text;

namespace MissleLauncher.Exceptions
{
    class RocketTypeNotFoundError : MissleLauncherError
    {
        public RocketTypeNotFoundError(string message) : base(message)
        {

        }
    }
}
