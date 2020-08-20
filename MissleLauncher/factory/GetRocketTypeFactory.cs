using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace MissleLauncher.factory
{
    public class GetRocketTypeFactory
    {
        public static RocketType GetRocketType(string rocketType) 
        {
            string input = rocketType.ToLower();
            switch (input) 
            {
                case "torpedo":
                    return RocketType.Torpedo;
                case "ballistic":
                    return RocketType.Ballistic;
                case "cruise":
                    return RocketType.Cruise;
                case "longtermrocket":
                    return RocketType.LongTermRocket;
                default:
                    throw new Exception($"The Rocket {rocketType} not exist in type");
            }
        }
    }
}
