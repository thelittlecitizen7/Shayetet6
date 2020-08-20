using MenuBuilder;
using MenuBuilder.IO.Input;
using MenuBuilder.Options;
using MissleLauncher.Enums;
using MissleLauncher.Exceptions;
using MissleLauncher.factory;
using MissleLauncher.IO;
using MissleLauncher.IO.Input;
using MissleLauncher.MissleHandler;
using MissleLauncher.models;
using MissleLauncher.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MissleLauncher.Options
{
    public class LaunchMissilesOption : IOptions
    {
        private IMissileStorageHandler _missileStorageHandler;
        public IMissileHandler _missileHandler { get; set; }
        private IOutputSystem _outputSystem;
        private ISystemInput _inputSystem;
        

        public LaunchMissilesOption(IMissileStorageHandler missileStorageHandler, IMissileHandler missileHandler, IOutputSystem outputSystem, ISystemInput input)
        {
            _missileStorageHandler = missileStorageHandler;
            _missileHandler = missileHandler;
            _outputSystem = outputSystem;
            _inputSystem = input;
        }
        public void Operation()
        {

            _outputSystem.Print("Please enter the kind of the rocket you want to launch :");
            _outputSystem.Print($"{Utils.GetStringValues(new RocketType())} : ");
            string rocketTypeChoise = _inputSystem.StringInput();


            RocketType rocketType = GetRocketTypeFactory.GetRocketType(rocketTypeChoise);

            _outputSystem.Print("Please enter the number of the rocket you want to launch");
            string totalRocketNumberChoise = _inputSystem.StringInput();

            
            if (!Utils.IsNumber(totalRocketNumberChoise))
            {
                throw new ILigalArgsValidation($"Error : The Input must be type of number");
            }

            if (_missileStorageHandler.RocketMisileStorage.Count == 0)
            {
                throw new EmptyRocketStorageError("There is no rockets in storage");
            }

            List<IRocket> allChoosenRockets = _missileStorageHandler.GetRocketsByType(int.Parse(totalRocketNumberChoise), rocketType);
            List<IRocket> allSuccessRockets = _missileHandler.Launch(allChoosenRockets);
            _outputSystem.Print($"Number of success rockets : {allSuccessRockets.Count}");
        }
    }
}
