﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace RocketsAndGamblers.Data
{
    [Serializable]
    public class PositionData
    {
        public int id;
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
    public class BaseDescription
    {
        public List<PositionData> layout;
        public List<UpgradeData> upgrades;

        /// <summary>
        /// Timestamp of the gold mining start time
        /// </summary>
        public long goldMiningStarted;
        public int goldMiningLimit;

        public int omoniumVeinsMax;
        public int omoniumVeinsLeft;

        /// <summary>
        /// Timestamp of the omonium mining start time
        /// </summary>
        public long omoniumMiningStarted;
    }
}