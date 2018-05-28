using Framework.References;
using UnityEngine;

namespace RocketsAndGamblers.UI
{
    public class DefaultUIGroup : UIGroup
    {
        [SerializeField] private BoolReference isEditingBase;
        [SerializeField] private BoolReference isTryingToSaveBase;
        [SerializeField] private BoolReference isWatchingReplay;

        private void OnStateChanged (bool oldState, bool newState)
        {
            SetActive(!isEditingBase && !isTryingToSaveBase && !isWatchingReplay);
        }

        private void Awake ()
        {
            isEditingBase.valueChanged += OnStateChanged;
            isTryingToSaveBase.valueChanged += OnStateChanged;
            isWatchingReplay.valueChanged += OnStateChanged;
        }

        private void OnDestroy ()
        {
            isEditingBase.valueChanged -= OnStateChanged;
            isTryingToSaveBase.valueChanged -= OnStateChanged;
            isWatchingReplay.valueChanged -= OnStateChanged;
        }
    }
}