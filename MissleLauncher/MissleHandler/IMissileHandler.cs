using MissleLauncher.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissleLauncher.MissleHandler
{
    public interface IMissileHandler
    {
        List<IRocket> Launch(List<IRocket> allChoosenRockets);
    }
}
