using Framework.Events;
using Framework.References;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public IntReference availableAttempts;
    public IntReference attepmtsLeft;

    public GameEvent onAttackFailed;

    public void OnPlayerDeath ()
    {
        if (attepmtsLeft.Value > 0) {
            attepmtsLeft.Value -= 1;

            if (attepmtsLeft == 0) {
                onAttackFailed?.Raise();
            }
        }
    }

    private void Start ()
    {
        attepmtsLeft.Value = availableAttempts.Value;
    }
}
