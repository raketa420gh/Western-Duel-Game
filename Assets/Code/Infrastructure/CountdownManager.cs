using UnityEngine;
using System.Collections;
using System;

namespace Raketa420
{
    public class CountdownManager : MonoBehaviour
    {
        private int currentStage = 0;
        private float stepTime = 1f;
        private bool isActive = false;

        public event Action OnCountdownFinished;
        public event Action<int> OnStepCompleted;

        public bool IsActive => isActive;

        public void StartCountdown()
        {
            StartCoroutine(nameof(CountdownRoutine));
        }

        private IEnumerator CountdownRoutine()
        {
            isActive = true;
            yield return new WaitForSeconds(stepTime);
            currentStage ++;

            OnStepCompleted?.Invoke(currentStage);

            if (currentStage == 2)
            {
                stepTime = UnityEngine.Random.Range(0.25f, 3f);
                OnStepCompleted?.Invoke(currentStage);
            }

            if (currentStage == 3)
            {
                isActive = false;
                OnStepCompleted?.Invoke(currentStage);
                OnCountdownFinished?.Invoke();
                yield break;
            }

            StartCountdown();
        }
    }
}