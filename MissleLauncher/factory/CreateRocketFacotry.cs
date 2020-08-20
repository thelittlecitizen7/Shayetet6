using MissleLauncher.models;
using MissleLauncher.Models;
using MissleLauncher.Techniques;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissleLauncher.factory
{
    public class CreateRocketFacotry
    {
        public static IRocket Create(RocketType rocketType)
        {
            IRocket rocket = null;
            switch (rocketType)
            {
                case RocketType.Ballistic:
                    rocket = new Ballistic(new List<ITechnique>() { new BallisticTechniques()});
                    break;

                case RocketType.Cruise:
                    rocket = new Cruise(new List<ITechnique>() { new CruiseTechniques() });
                    break;

                case RocketType.Torpedo:
                    rocket = new Torpedo(new List<ITechnique>() { new TorpedoTechniques() });
                    break;

                case RocketType.LongTermRocket:
                    rocket = new LongTermRocket(new List<ITechnique>() { new LongTermTechniques() });
                    break;
                    
            }
            return rocket;
        }
    }
}
