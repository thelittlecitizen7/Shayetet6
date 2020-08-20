using MissleLauncher.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissleLauncher.Models
{
    public interface ITechnique
    {
        bool DoTechnique(IRocket rocket);
    }
}
