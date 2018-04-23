using System;
using RocketsAndGamblers.Database;
using UnityEngine;

namespace RocketsAndGamblers.Data
{
    public class RoamingDefenceDataProvider : AdditionalDataProvider
    {
        public RoamingDefenceData Data { get; private set; } = new RoamingDefenceData();

        public override void InitFromString (string data)
        {
            Data = JsonUtility.FromJson<RoamingDefenceData>(data);
        }

        public void SetPlanetToId(ObjectIdentity planetTo)
        {
            Data.planetIdTo = planetTo.RuntimeId;
        }

        public void SetPlanetFromId(ObjectIdentity planetFrom)
        {
            Data.planetIdFrom = planetFrom.RuntimeId;
        }

        protected override string SerializeToString ()
        {
            return JsonUtility.ToJson(Data);
        }

        [Serializable]
        public class RoamingDefenceData
        {
            public int planetIdFrom;
            public int planetIdTo;
        }
    }
}