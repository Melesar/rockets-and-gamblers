using UnityEngine;
using Framework.UI.Interfaces;
using System;

namespace RocketsAndGamblers.UI
{
    public class TimeStopper : MonoBehaviour, IWindowCloseListener, IWindowOpenListener
    {
        public void OnWindowClosed ()
        {
            Time.timeScale = 1f;
        }

        public void OnWindowOpened ()
        {
            Time.timeScale = 0f;
        }
    }
}
