using RocketsAndGamblers.Data;
using UnityEngine;

namespace RocketsAndGamblers
{
    public class BaseBuildingManager : MonoBehaviour
    {
        [SerializeField] private BaseDescriptionProvider baseProvider;
        [SerializeField] private ObjectsSet layoutObjects;

        private BaseDescription currentBaseDescription;

        public void OnBaseBuilt (BaseDescription baseDescription)
        {
            currentBaseDescription = baseDescription;
        }

        public void OnFinishedEditing ()
        {
            UpdateBaseLayout();

            baseProvider.UpdatePlayerBase(Constants.PlayerId, currentBaseDescription);
        }

        private void UpdateBaseLayout ()
        {
            currentBaseDescription.layout.Clear();
            foreach (var item in layoutObjects) {
                currentBaseDescription.AddToLayout(item);

                var additionalData = item.GetComponent<AdditionalDataProvider>();
                if (additionalData != null) {
                    currentBaseDescription.AddAdditionalData(additionalData);
                }
            }
        }
    }
}
