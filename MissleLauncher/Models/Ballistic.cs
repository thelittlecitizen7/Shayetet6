using System;
using System.Collections.Generic;
using System.Text;

namespace MissleLauncher.Models
{
    public class Ballistic : Rocket
    {
        public Ballistic(List<ITechnique> techniques) : base(RocketType.Ballistic, techniques)
        {

        }
    }
}
