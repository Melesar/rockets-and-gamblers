using RocketsAndGamblers.Data;
using RocketsAndGamblers.Player;
using UnityEngine;

namespace RocketsAndGamblers
{
    public class BaseBuildingManager : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;
        [SerializeField] private BaseDescriptionProvider baseProvider;
        [SerializeField] private ObjectsSet layoutObjects;

        private BaseDescription currentBaseDescription;

        public void OnBaseBuilt (BaseDescription baseDescription)
        {
            currentBaseDescription = baseDescription;
        }

        [ContextMenu("Save base")]
        public void OnFinishedEditing ()
        {
            if (Tutorials.TutorialUtility.IsTutorialRunning() &&
                Tutorials.TutorialUtility.IsDebugMode) {
                return;
            }
            
            UpdateBaseLayout();

            baseProvider.UpdatePlayerBase(playerData.Id, currentBaseDescription);
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
