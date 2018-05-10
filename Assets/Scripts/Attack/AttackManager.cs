using System.Collections.Generic;
using System.Linq;
using Framework.Data;
using Framework.References;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    [SerializeField] private IntVariable currentAttempts;
    [SerializeField] private IntVariable currentStars;

    [SerializeField] private IntReference[] starsAttempts;

    private List<int> sortedStarsAttempts;

    public void OnPlayerDeath ()
    {
        currentAttempts.Value += 1;
        
        UpdateCurrentStarsValue();
    }

    private void UpdateCurrentStarsValue()
    {
        var maxStars = sortedStarsAttempts.Count;
        
        for (var index = 0; index < sortedStarsAttempts.Count; index++) {
            var starAttemptsValue = sortedStarsAttempts[index];
            
            if (starAttemptsValue <= currentAttempts) {
                currentStars.Value = maxStars - index;
                return;
            }
        }

        currentStars.Value = 0;
    }

    private void SortStarsAttempts()
    {
        sortedStarsAttempts = new List<int>(starsAttempts.Select(r => r.Value));
        sortedStarsAttempts.Sort();
    }
    
    private void Awake()
    {
        SortStarsAttempts();
    }
}
