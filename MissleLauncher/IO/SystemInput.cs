using MenuBuilder.IO.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissleLauncher.IO.Input
{
    public class ConsoleSystemInput : ISystemInput
    {
        

        public string StringInput()
        {
            return Console.ReadLine();
        }
    }
}
