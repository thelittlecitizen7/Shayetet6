using System;
using System.Collections.Generic;
using System.Text;

namespace MissleLauncher.Exceptions
{
    public class RocketNotFoundError : MissleLauncherError
    {
        public RocketNotFoundError(string message) : base(message)
        {

        }
    }
}
