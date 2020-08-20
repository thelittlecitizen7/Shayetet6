using MissleLauncher.Enums;
using MissleLauncher.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissleLauncher.MissleHandler
{
    public interface IMissileStorageHandler
    {
        List<IRocket> RocketMisileStorage { get; }

        Dictionary<IRocket, LaunchStatusType> RocketStatusMissleStorage { get; }

        void AddRockets(int totalTocketNumber, RocketType rocketType);

        void RemoveRocketByIndex(int rocketIndex);

        void ReomveRockets(IRocket rocket);

        bool IsRocketExistInStatus(IRocket rocket, LaunchStatusType status);

        void SetRocketStatus(LaunchStatusType rocketStatus, IRocket rocket);


        List<IRocket> GetRocketsByType(int rocketNumbers, RocketType rocketType);

        string ToString();
    }
}
