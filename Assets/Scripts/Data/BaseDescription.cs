using RocketsAndGamblers.Database;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace RocketsAndGamblers.Data
{
    [Serializable]
    public class PositionData
    {
        public int id;
        public int runtimeId;
        public Vector3 position;
        public Quaternion rotation;
    }

    [Serializable]
    public class UpgradeData
    {
        public int id;
        public long startTimestamp;
        public int duration;
    }

    [Serializable]
    public class AdditionalData
    {
        public int objectRuntimeId;
        public string data;
    }

    [Serializable]
    public class BaseDescription
    {
        public List<PositionData> layout;
        public List<UpgradeData> upgrades;
        public List<AdditionalData> additionalData;

        /// <summary>
        /// Timestamp of the gold mining start time
        /// </summary>
        public long goldMiningStarted;
        public int goldMiningLimit;

        public int omoniumVeinsMax;
        public int omoniumVeinsLeft;

        public int[] availableDefenses;

        public string bundleName;

        public bool isPersistant;

        /// <summary>
        /// Timestamp of the omonium mining start time
        /// </summary>
        public long omoniumMiningStarted;

        [NonSerialized] public bool isAttacking;

        public void AddToLayout (ObjectIdentity objectId)
        {
            layout.Add(new PositionData {
                id = objectId.Id,
                runtimeId = objectId.RuntimeId,
                position = objectId.transform.position,
                rotation = objectId.transform.rotation
            });
        }

        public void AddAdditionalData(AdditionalDataProvider dataProvider)
        {
            additionalData.Add(dataProvider.GetAdditionalData());
        }

        public BaseDescription ()
        {
            layout = new List<PositionData>();
            additionalData = new List<AdditionalData>();
            upgrades = new List<UpgradeData>();
        }
    }
}
