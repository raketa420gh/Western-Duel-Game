using System;

public interface ICountdownService : IService
{
    bool IsActive { get; }
    event Action OnCountdownFinished;
    event Action<int> OnStepCompleted;
    void StartCountdown();
}