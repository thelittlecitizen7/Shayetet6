using MenuBuilder;
using MenuBuilder.IO.Input;
using MenuBuilder.Options;
using MissleLauncher.Exceptions;
using MissleLauncher.MissleHandler;
using MissleLauncher.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissleLauncher.Options
{
    public class LaunchAllRocketsOptions : IOptions
    {
        private IMissileStorageHandler _missileStorageHandler;
        private IMissileHandler _missileHandler;
        private IOutputSystem _outputSystem;
        private static Random _rnd = new Random();

        public LaunchAllRocketsOptions(IMissileStorageHandler missileStorageHandler, IMissileHandler missileHandler, IOutputSystem outputSystem)
        {
            _missileStorageHandler = missileStorageHandler;
            _missileHandler = missileHandler;
            _outputSystem = outputSystem;
        }
        public void Operation()
        {
            if (_missileStorageHandler.RocketMisileStorage.Count == 0)
            {
                throw new EmptyRocketStorageError("There is no rockets in storage");
            }
            List<IRocket> allSuccessRockets = _missileHandler.Launch(_missileStorageHandler.RocketMisileStorage);
            _outputSystem.Print($"Number of success rockets : {allSuccessRockets.Count}");
            
        }

    }
}
