using UnityEngine;

namespace RocketsAndGamblers.Tutorials
{
    /// <summary>
    /// Needs to be on the same object as the animator to disable it when nesessary
    /// </summary>
    [RequireComponent(typeof(Animator))]
    public class TutorialController : MonoBehaviour
    {
        private void Awake()
        {
            if (!TutorialUtility.IsTutorialRunning()) {
                Destroy(gameObject);
            }
        }
    }
}