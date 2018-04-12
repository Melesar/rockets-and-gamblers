using Framework.References;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public IntReference availableAttempts;
    public IntReference attepmtsLeft;

    public void OnPlayerDeath ()
    {
        if (attepmtsLeft.Value > 0) {
            attepmtsLeft.Value -= 1;
        }
    }

    private void Start ()
    {
        attepmtsLeft.Value = availableAttempts.Value;
    }
}
