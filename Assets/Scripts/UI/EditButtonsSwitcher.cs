using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RocketsAndGamblers.UI
{
    public class EditButtonsSwitcher : MonoBehaviour
    {
        public GameObject activeDuringEdit;
        public GameObject inactiveDuringEdit;

        public void OnEditStateChanged (bool newState)
        {
            activeDuringEdit.SetActive(newState);
            inactiveDuringEdit.SetActive(!newState);
        }
    }
}
