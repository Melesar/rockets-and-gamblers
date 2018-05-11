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

        public string Text
        {
            set
            {
                text.text = !string.IsNullOrEmpty(format) 
                    ? string.Format(format, value) 
                    : value;
            }
        }

        private void OnStringUpdated(string oldValue, string newValue)
        {
            Text = newValue;
        }

        private void Start()
        {
            Text = trackedString;
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