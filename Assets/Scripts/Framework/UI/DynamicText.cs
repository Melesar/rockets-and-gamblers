using Framework.References;
using UnityEngine;
using UnityEngine.UI;

namespace Framework.UI
{
    [RequireComponent(typeof(Text))]
    public class DynamicText : MonoBehaviour
    {
        [SerializeField] private StringReference format;
        [SerializeField] private StringReference trackedString;
        
        private Text text;

        private void OnStringUpdated(string oldValue, string newValue)
        {
            text.text = !string.IsNullOrEmpty(format) 
                ? string.Format(format, newValue) 
                : newValue;
        }

        private void Start()
        {
            OnStringUpdated(string.Empty, trackedString);
        }

        private void Awake()
        {
            text = GetComponent<Text>();
            trackedString.valueChanged += OnStringUpdated;
        }

        private void OnDestroy()
        {
            trackedString.valueChanged -= OnStringUpdated;
        }
    }
}