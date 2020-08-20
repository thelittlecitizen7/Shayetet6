using System;
using System.Collections.Generic;
using System.Text;

namespace MissleLauncher.Models
{
    public class Torpedo : Rocket
    {
        public Torpedo(List<ITechnique> techniques) : base(RocketType.Torpedo,techniques)
        {

        }
    }
}
