using Framework.References;
using RocketsAndGamblers.Data;
using RocketsAndGamblers.Database;
using UnityEngine;

namespace RocketsAndGamblers.Defenses
{
    public class RoamingDefencePathEditing : MonoBehaviour
    {
        [SerializeField] private GameObject pathObject;
        [SerializeField] private ObjectsDatabase database;
        [SerializeField] private DefenceLayoutSnapping planetFromSnapper;
        [SerializeField] private DefenceLayoutSnapping planetToSnapper;

        private RoamingDefenceDataProvider dataProvider;
        private RoamingDefense defence;

        public void OnEditStateChanged(bool newState)
        {
            pathObject.SetActive(newState);
        }

        private void SnapPlanetTo(ObjectIdentity planetTo)
        {
            dataProvider.SetPlanetToId(planetTo);
            defence.Initialize();
        }

        private void SnapPlanetFrom(ObjectIdentity planetFrom)
        {
            dataProvider.SetPlanetFromId(planetFrom);
            defence.Initialize();
        }

        private void SetupPathPoints ()
        {
            var pathData = dataProvider.Data;

            var fromPlanet = database.GetByRuntimeId(pathData.planetIdFrom);
            var toPlanet = database.GetByRuntimeId(pathData.planetIdTo);

            planetFromSnapper.transform.position = fromPlanet.transform.position;
            planetToSnapper.transform.position = toPlanet.transform.position;
        }

        private void Start()
        {
            SetupPathPoints();
        }

        private void Awake()
        {
            dataProvider = GetComponent<RoamingDefenceDataProvider>();
            defence = GetComponent<RoamingDefense>();

            planetFromSnapper.snapped += SnapPlanetFrom;
            planetToSnapper.snapped += SnapPlanetTo;

            //Detaching vfx from the object itself for it to not move with the object
            pathObject.transform.SetParent(null);
        }

        private void OnDestroy()
        {
            planetFromSnapper.snapped -= SnapPlanetFrom;
            planetToSnapper.snapped -= SnapPlanetTo;
        }

    }
}