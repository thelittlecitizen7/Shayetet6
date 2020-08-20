using MenuBuilder;
using MenuBuilder.Options;
using MissleLauncher.IO;
using MissleLauncher.IO.Input;
using MissleLauncher.MissleHandler;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissleLauncher.Options
{
    public class StorageMissileReportOption : IOptions
    {

        private IMissileStorageHandler _missileStorageHandler;
        private IOutputSystem _outputSystem;

        public StorageMissileReportOption(IMissileStorageHandler missileStorageHandler, IOutputSystem outputSystem)
        {
            _missileStorageHandler = missileStorageHandler;
            _outputSystem = outputSystem;
        }
        public void Operation()
        {
            _outputSystem.Print("All rockets : ");
            _outputSystem.Print(_missileStorageHandler.ToString());
        }
    }
}
