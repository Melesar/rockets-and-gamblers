using System;
using RocketsAndGamblers.Database;
using RocketsAndGamblers.Defenses;
using UnityEngine;

namespace RocketsAndGamblers.Data
{
    [RequireComponent(typeof(RoamingDefense))]
    public class RoamingDefenceDataProvider : AdditionalDataProvider
    {

        /*public ObjectIdentity planetFrom;
        public ObjectIdentity planetTo;*/

        private RoamingDefenceData data = new RoamingDefenceData();
        private RoamingDefense defense;

        public override void InitFromString (string data)
        {
            this.data = JsonUtility.FromJson<RoamingDefenceData>(data);
            defense.Initialize(this.data);
        }

        protected override string SerializeToString ()
        {
            /*data.planetIdFrom = planetFrom.RuntimeId;
            data.planetIdTo = planetTo.RuntimeId;*/
            return JsonUtility.ToJson(data);
        }

        private void Awake()
        {
            defense = GetComponent<RoamingDefense>();
        }

        [Serializable]
        public class RoamingDefenceData
        {
            public int planetIdFrom;
            public int planetIdTo;
        }
    }
}