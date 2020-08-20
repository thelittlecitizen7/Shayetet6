using MissleLauncher.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissleLauncher.Models
{
    public abstract class Rocket : IRocket
    {
        public RocketType RocketType { get; set; }

        public List<ITechnique> Techniques { get; set; }
        public string Id { get ;private set ; }

        public Rocket(RocketType rocketType, List<ITechnique> techniques)
        {
            Id = Guid.NewGuid().ToString();
            Techniques = techniques;
            RocketType = rocketType;
        }

        public override string ToString()
        {
            return $"rocket : {RocketType}";
        }

    }
}
