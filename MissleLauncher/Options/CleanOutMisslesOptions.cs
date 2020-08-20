using MenuBuilder;
using MenuBuilder.IO.Input;
using MenuBuilder.Options;
using MissleLauncher.Exceptions;
using MissleLauncher.IO;
using MissleLauncher.IO.Input;
using MissleLauncher.MissleHandler;
using MissleLauncher.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissleLauncher.Options
{
    public class CleanOutMisslesOptions : IOptions
    {
        private IMissileStorageHandler _missileStorageHandler;
        private IOutputSystem _outputSystem;
        private ISystemInput _inputSystem;
        public CleanOutMisslesOptions(IMissileStorageHandler missileStorageHandler, IOutputSystem outputSystem, ISystemInput input)
        {
            _missileStorageHandler = missileStorageHandler;
            _outputSystem = outputSystem;
            _inputSystem = input;
        }
        public void Operation()
        {
            _outputSystem.Print("Please enter the index number of the rocket you want to remove");
            string rocketIndex = _inputSystem.StringInput();

            if (!Utils.IsNumber(rocketIndex))
            {
                throw new ILigalArgsValidation($"Error : The Input must be type of number");
            }
            _missileStorageHandler.RemoveRocketByIndex(int.Parse(rocketIndex));

        }
    }
}
