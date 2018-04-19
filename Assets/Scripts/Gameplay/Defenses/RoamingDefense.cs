using RocketsAndGamblers.Data;
using RocketsAndGamblers.Database;
using UnityEngine;

namespace RocketsAndGamblers.Defenses
{
    public class RoamingDefense : Defense
    {
        [SerializeField] private float movementSpeed = 0.4f;
        [SerializeField] private ObjectsDatabase database;

        private Ellipse ellipseInstance;

        private float ellipseValue;

        private ObjectIdentity from;
        private ObjectIdentity to;

        private void Update()
        {
            if (ellipseInstance == null) {
                return;
            }

            var offset = movementSpeed * Time.deltaTime;
            ellipseValue = Mathf.Repeat(ellipseValue + offset, 1);

            transform.position = ellipseInstance.GetPoint(ellipseValue);
        }

        private void Start()
        {
            transform.position = ellipseInstance.GetPoint(0f);
        }

        public void Initialize(RoamingDefenceDataProvider.RoamingDefenceData data)
        {
            var ellipseObject = new GameObject("Roaming defence ellipse");
            ellipseInstance = ellipseObject.AddComponent<Ellipse>();

            from = database.GetByRuntimeId(data.planetIdFrom);
            to = database.GetByRuntimeId(data.planetIdTo);

            SetupEllipse();
        }

        private void SetupEllipse()
        {
            var ellipseCenter = (from.transform.position + to.transform.position) / 2f;

            ellipseInstance.transform.position = ellipseCenter;
            ellipseInstance.transform.right = (from.transform.position - ellipseCenter).normalized;

            var width = Vector3.Distance(from.transform.position, to.transform.position) / 2f;
            var planetGravity = from.GetComponent<PlanetGravityField>();
            width += planetGravity.Radius;

            ellipseInstance.Width = width;
            ellipseInstance.Height = planetGravity.Radius + 0.1f;
        }
    }
}