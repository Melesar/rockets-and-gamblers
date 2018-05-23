using UnityEngine;

namespace RocketsAndGamblers.Tutorials
{
    public static class TutorialUtility
    {
        private const string TutorialPrefsKey = "TutorialRunning";
        
        public static bool IsTutorialRunning()
        {
            return PlayerPrefs.HasKey(TutorialPrefsKey);
        }

        public static void SetTutorialRunning(bool isRunning)
        {
            if (isRunning) {
                PlayerPrefs.SetFloat(TutorialPrefsKey, 1f);
            } else {
                PlayerPrefs.DeleteKey(TutorialPrefsKey);
            }
        }

        private static bool isDebugMode;
        
        public static bool IsDebugMode
        {
            get
            {
                #if !UNITY_EDITOR
                return false;
                #else
                return isDebugMode;
                #endif
            }

            set
            {
                #if UNITY_EDITOR
                isDebugMode = value;
                #endif
            }
        }
    }
}