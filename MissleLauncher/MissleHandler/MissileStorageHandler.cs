using MissleLauncher.Enums;
using MissleLauncher.Exceptions;
using MissleLauncher.factory;
using MissleLauncher.models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MissleLauncher.MissleHandler
{
    public class MissileStorageHandler : IMissileStorageHandler
    {
        public List<IRocket> RocketMisileStorage { get; private set; }
        public Dictionary<IRocket, LaunchStatusType> RocketStatusMissleStorage { get; private set; }

        private Dictionary<RocketType, List<int>> _rocketsTypeCount = new Dictionary<RocketType, List<int>>();


        public MissileStorageHandler()
        {
            RocketMisileStorage = new List<IRocket>();
            RocketStatusMissleStorage = new Dictionary<IRocket, LaunchStatusType>();
            _rocketsTypeCount = new Dictionary<RocketType, List<int>>();
        }


        public void AddRockets(int totalTocketNumber, RocketType rocketType)
        {

            for (int i = 0; i < totalTocketNumber; i++)
            {
                IRocket rocket = CreateRocketFacotry.Create(rocketType);
                if (rocket != null)
                {
                    RocketMisileStorage.Add(rocket);
                    AddRocketTypeCount(rocketType, RocketMisileStorage.IndexOf(rocket));
                }
            }
        }

        public bool IsRocketExistInStatus(IRocket rocket, LaunchStatusType status)
        {
            if (!RocketStatusMissleStorage.ContainsKey(rocket))
            {
                return false;
            }

            foreach (var rocketStatus in RocketStatusMissleStorage)
            {
                if (rocketStatus.Key.Id == rocket.Id && rocketStatus.Value == status)
                {
                    return true;
                }
            }
            return false;
        }

        public void RemoveRocketByIndex(int rocketIndex)
        {
            if (rocketIndex >= RocketMisileStorage.Count)
            {
                throw new RocketNotFoundError($"The rocket with index {rocketIndex} not found in rockets storage");
            }
            RocketType type = RocketMisileStorage[rocketIndex].RocketType;
            RocketMisileStorage.RemoveAt(rocketIndex);
            RemoveRocketTypeCount(type, rocketIndex);
        }


        public void ReomveRockets(IRocket rocket)
        {
            bool isRocketExist = RocketMisileStorage.Any(r => r == rocket);
            if (isRocketExist)
            {
                int rocketIndex = RocketMisileStorage.IndexOf(rocket);
                RocketMisileStorage.Remove(rocket);
                RemoveRocketTypeCount(rocket.RocketType, rocketIndex);
            }
            else
            {
                throw new RocketNotFoundError($"The Rocket not found in map");
            }
        }

        public void SetRocketStatus(LaunchStatusType rocketStatus, IRocket rocket)
        {

            if (!RocketStatusMissleStorage.ContainsKey(rocket))
            {
                RocketStatusMissleStorage.Add(rocket, rocketStatus);
            }
            else
            {
                RocketStatusMissleStorage[rocket] = rocketStatus;
            }
        }

        public List<IRocket> GetRocketsByType(int rocketNumbers, RocketType rocketType)
        {
            if (!_rocketsTypeCount.ContainsKey(rocketType))
            {
                throw new RocketTypeNotFoundError($"There is no rockets of type {rocketType} in storage");
            }
            List<int> rockets = _rocketsTypeCount[rocketType];

            if (rocketNumbers < rockets.Count)
            {
                List<IRocket> allFoundRockets = new List<IRocket>();
                for (int i = 0; i < rocketNumbers; i++)
                {
                    IRocket rocketFromStorage = RocketMisileStorage[rockets[i]];
                    allFoundRockets.Add(rocketFromStorage);
                }
                return allFoundRockets;

            }
            throw new RocketNotFoundError($"There is only {rockets.Count} rocket of type {rocketType} and you ask {rocketNumbers}");

        }

        public LaunchStatusType GetRocketStatus(IRocket rocket) 
        {


            bool isRocketExist = RocketStatusMissleStorage.Any(r => r.Key.Id == rocket.Id);

            if (!isRocketExist)
            {
                return LaunchStatusType.NotLaunched;
            }

            KeyValuePair<IRocket,LaunchStatusType> foundRocket = RocketStatusMissleStorage.Where(r => r.Key.Id == rocket.Id).First();
            
            return foundRocket.Value;
            
        }

        public override string ToString()
        {
            string msg = $"All rockets in missle : {Environment.NewLine}";
            int count = 0;
            foreach (var rocket in RocketMisileStorage)
            {
                LaunchStatusType rocketStatus = GetRocketStatus(rocket);
                msg += $"{count}. id : {rocket.Id} ,  {rocket.ToString()} , status : {rocketStatus} {Environment.NewLine}";
                count++;
            }
            return msg;
        }

        private void AddRocketTypeCount(RocketType type, int index)
        {
            if (!_rocketsTypeCount.ContainsKey(type))
            {
                _rocketsTypeCount.Add(type, new List<int>());
                _rocketsTypeCount[type].Add(index);
            }
            else
            {
                if (!_rocketsTypeCount[type].Contains(index))
                {
                    _rocketsTypeCount[type].Add(index);
                }
            }
        }

        private void RemoveRocketTypeCount(RocketType type, int index)
        {
            if (_rocketsTypeCount.ContainsKey(type))
            {
                if (_rocketsTypeCount[type].Contains(index))
                {
                    _rocketsTypeCount[type].Remove(index);
                }

            }
        }




    }
}
