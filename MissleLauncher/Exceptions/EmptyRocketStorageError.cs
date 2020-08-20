using System;
using System.Collections.Generic;
using System.Text;

namespace MissleLauncher.Exceptions
{
    public class EmptyRocketStorageError : MissleLauncherError
    {
        public EmptyRocketStorageError(string message) : base(message)
        {

        }
    }
}
