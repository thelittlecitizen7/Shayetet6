using MissleLauncher.models;
using MissleLauncher.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissleLauncher.Techniques
{
    public class CruiseTechniques : ITechnique
    {
        public static Random rnd = new Random();
        public bool DoTechnique(IRocket rocket)
        {
            int number = rnd.Next(100);
            return number > 0 && number < 20;
        }
    }
}
