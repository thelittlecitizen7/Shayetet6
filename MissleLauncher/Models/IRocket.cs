using MissleLauncher.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissleLauncher.models
{
    public interface IRocket
    {
        public string Id { get; }
        RocketType RocketType { get; set; }

        string ToString();

        List<ITechnique> Techniques { get; set; }
    }
}
