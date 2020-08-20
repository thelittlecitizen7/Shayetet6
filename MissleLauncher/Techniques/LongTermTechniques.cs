using Microsoft.VisualBasic;
using MissleLauncher.models;
using MissleLauncher.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissleLauncher.Techniques
{
    public class LongTermTechniques : ITechnique
    {
        public static Random rnd = new Random();

        public LongTermTechniques()
        {

        }
        public bool DoTechnique(IRocket rocket)
        {
            int maxDistanceNumber = 1500;
            int distanceNumberRandom = rnd.Next(maxDistanceNumber);
            int totalPrecentSuccess = (maxDistanceNumber - distanceNumberRandom) / maxDistanceNumber * 100;
            int randomPrecentNumber = rnd.Next(100);
            return randomPrecentNumber > 0 && randomPrecentNumber < totalPrecentSuccess;
        }
    }
}
