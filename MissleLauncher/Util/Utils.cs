using System;
using System.Collections.Generic;
using System.Text;

namespace MissleLauncher.Util
{
    public class Utils
    {
        public static string GetStringValues(Enum e) 
        {
            string msg = "";
            foreach (var rocket in Enum.GetNames(e.GetType()))
            {
                msg += $" - {rocket} {Environment.NewLine}";
            }
            return msg;

        }

        public static bool IsNumber(string value) 
        {
            int number;
            return int.TryParse(value, out number);
            
        }
    }
}
