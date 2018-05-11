using Framework.References;
using Framework.UI.Interfaces;
using UnityEngine;

namespace RocketsAndGamblers.UI
{
    public class SuccessfullAttackWindow : MonoBehaviour, IWindowOpenListener
    {
        [SerializeField] private IntReference starsAcheived;

        [Space] 
        
        [SerializeField] private GameObject[] stars;
        
        public void OnWindowOpened()
        {
            for (int i = stars.Length - 1; i >= 0; i--) {
                stars[i].SetActive(i + 1 <= starsAcheived);
            }        
        }
    }
}