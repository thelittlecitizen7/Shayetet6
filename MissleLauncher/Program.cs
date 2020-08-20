using System;
using System.Collections.Generic;
using MenuBuilder;
using MenuBuilder.IO.Input;
using MenuBuilder.Menus;
using MenuBuilder.Menus.NumberMenu;
using MenuBuilder.Menus.NumberMenu.validations;
using MenuBuilder.Menus.TextFreeMenu;
using MissleLauncher.IO.Input;
using MissleLauncher.IO.Output;
using MissleLauncher.MissleHandler;
using MissleLauncher.Options;

namespace MissleLauncher
{
    class Program
    {
        static void Main(string[] args)
        {
            IOutputSystem outputSystem = new ConsoleSystemOutput();
            ISystemInput systemInput = new ConsoleSystemInput();
            
            IMissileStorageHandler missileStorageHandler = new MissileStorageHandler();
            IMissileHandler missileHandler = new MissileHandler(missileStorageHandler);


            IMenuBuilder launcRocket = new TextMenuBuilder("Launch Menu : ", outputSystem, systemInput)
                .AddOptions("totalWar", new LaunchAllRocketsOptions(missileStorageHandler,missileHandler, outputSystem))
                .AddOptions("regular", new LaunchMissilesOption(missileStorageHandler, missileHandler, outputSystem, systemInput));


            IMenu numberMenuBuilder = new NumberMenuBuilder("Welcom to shayetet-6s Missle Launcher, Commander : ", outputSystem, systemInput)
                .AddOptions("Store new missles", new StoreNewMissilesOption(missileStorageHandler, outputSystem, systemInput))
                .AddOptions("Launch missles", new NavigateMenu(launcRocket.Build()))
                .AddOptions("Inventory report", new StorageMissileReportOption(missileStorageHandler, outputSystem))
                .AddOptions("Clean out missles", new CleanOutMisslesOptions(missileStorageHandler, outputSystem, systemInput))
                .AddOptions("Exist", new ShutDownOption())
                .Build();

            launcRocket.AddOptions("MoveBack", new NavigateMenu(numberMenuBuilder))
                .AddOptions("Exist", new ShutDownOption()).Build();


            numberMenuBuilder.Run();

        }
    }
}
