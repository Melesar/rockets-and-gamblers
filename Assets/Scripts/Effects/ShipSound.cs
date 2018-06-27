using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RocketsAndGamblers.Effects
{
    public class ShipSound : MonoBehaviour,  IDeathListener
    {
        public AudioClip explosionClip;
        
        private AudioSource audioSource;
        

        public void OnDeath()
        {
            audioSource.clip = explosionClip;
            audioSource.loop = false;
            audioSource.Play();
        }

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }
    }
}

