using System;
using System.Collections.Generic;
using System.Text;

namespace MissleLauncher.Models
{
    public class Cruise : Rocket
    {
        public Cruise(List<ITechnique> techniques) : base(RocketType.Cruise, techniques)
        {

        }
    }
}
