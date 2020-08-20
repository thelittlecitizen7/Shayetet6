using MissleLauncher.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissleLauncher.Models
{
    public class LongTermRocket : Rocket
    {
        public LongTermRocket(List<ITechnique> techniques) : base(RocketType.Torpedo, techniques)
        {

        }
    }
}
