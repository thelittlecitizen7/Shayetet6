using MissleLauncher.models;
using MissleLauncher.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissleLauncher.Techniques
{
    public class TorpedoTechniques : ITechnique
    {
        public static Random rnd = new Random();
        public bool DoTechnique(IRocket rocket)
        {
            return true;
        }
    }
}
