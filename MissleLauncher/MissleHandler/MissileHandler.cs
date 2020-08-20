using MissleLauncher.Enums;
using MissleLauncher.Exceptions;
using MissleLauncher.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MissleLauncher.MissleHandler
{
    public class MissileHandler : IMissileHandler
    {
        private IMissileStorageHandler _missileStorageHandler;
        public MissileHandler(IMissileStorageHandler missileStorageHandler)
        {
            _missileStorageHandler = missileStorageHandler;
        }

        public List<IRocket> Launch(List<IRocket> allChoosenRockets)
        {
            List<IRocket> allSuccessRockets = new List<IRocket>();
            List<IRocket> rocketsToReomve = new List<IRocket>();

            foreach (IRocket rocket in allChoosenRockets)
            {
                if (!_missileStorageHandler.IsRocketExistInStatus(rocket, LaunchStatusType.Failed))
                {
                    bool isActionSuccess = rocket.Techniques.All(t => t.DoTechnique(rocket));
                    if (!isActionSuccess)
                    {
                        _missileStorageHandler.SetRocketStatus(LaunchStatusType.Failed, rocket);
                    }
                    else
                    {
                        allSuccessRockets.Add(rocket);
                        rocketsToReomve.Add(rocket);
                        _missileStorageHandler.SetRocketStatus(LaunchStatusType.Success, rocket);
                    }
                }
            }

            rocketsToReomve.ForEach(r => _missileStorageHandler.ReomveRockets(r));
            return allSuccessRockets;
        }
    }
}
