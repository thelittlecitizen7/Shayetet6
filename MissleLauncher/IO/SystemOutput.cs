using MenuBuilder;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissleLauncher.IO.Output
{
    public class ConsoleSystemOutput : IOutputSystem
    {
        public ConsoleSystemOutput()
        {

        }

        public void Print(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
