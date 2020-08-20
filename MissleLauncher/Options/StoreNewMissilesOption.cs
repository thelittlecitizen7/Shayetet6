using MenuBuilder;
using MenuBuilder.Options;
using MenuBuilder.IO.Input;
using MissleLauncher.factory;
using MissleLauncher.MissleHandler;
using System;
using System.Collections.Generic;
using System.Text;
using MissleLauncher.Util;
using MissleLauncher.Exceptions;

namespace MissleLauncher.Options
{
    public class StoreNewMissilesOption : IOptions
    {
        private IMissileStorageHandler _missileStorageHandler;
        private IOutputSystem _outputSystem;
        private ISystemInput _input;
        public StoreNewMissilesOption(IMissileStorageHandler missileStorageHandler , IOutputSystem outputSystem , ISystemInput input)
        {
            _missileStorageHandler = missileStorageHandler;
            _outputSystem = outputSystem;
            _input = input;
        }
        public void Operation()
        {
            _outputSystem.Print("Please eneter Which kind of rocket you want to add");

            _outputSystem.Print(Utils.GetStringValues(new RocketType()));
            
            string rocketTypeChoise = _input.StringInput();
            RocketType rocketType = GetRocketTypeFactory.GetRocketType(rocketTypeChoise);
            
            _outputSystem.Print("Please eneter hoe much rocket you want to add");
            string totalRocketToInsertChoise = _input.StringInput();

            if (!Utils.IsNumber(totalRocketToInsertChoise))
            {
                throw new ILigalArgsValidation($"Error : The Input must be type of number");
            }

            _missileStorageHandler.AddRockets(int.Parse(totalRocketToInsertChoise), rocketType);
        }
    }
}
