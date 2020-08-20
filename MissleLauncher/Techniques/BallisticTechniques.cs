using MissleLauncher.models;
using MissleLauncher.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissleLauncher.Techniques
{
    public class BallisticTechniques : ITechnique
    {
        public static Random rnd = new Random();
        public bool DoTechnique(IRocket rocket)
        {
            int number = rnd.Next(100);
            return number > 20 && number < 100;
        }
    }
}
