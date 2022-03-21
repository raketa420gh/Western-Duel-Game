using Raketa420;
using UnityEngine;

public class DuelModeGameLoop : GameLoopBase
{
    private IInputService inputService;
    private IGameFactory gameFactory;
    private ICountdownService countdown;
    private Canvas canvas;
    private Player player;
    private Crosshair crosshair;
    private EnemyCounter enemyCounter;
    private UIPanelsView uiPanelsView;
    private CameraMotion cameraMotion;

    protected override void StartGameLoop()
    {
        base.StartGameLoop();
        Invoke(nameof(StartCountdown), 1f);
    }

    protected override void SubscribeEvents()
    {
        base.SubscribeEvents();
        countdown.OnStepCompleted += OnCountdownStepCompleted;
        countdown.OnCountdownFinished += OnCountdownFinished;
        player.OnKilled += OnPlayerKilled;
    }

    protected override void UnsubscribeEvents()
    {
        base.UnsubscribeEvents();
        countdown.OnStepCompleted -= OnCountdownStepCompleted;
        countdown.OnCountdownFinished -= OnCountdownFinished;
        player.OnKilled -= OnPlayerKilled;
    }

    protected override void LoseLevel()
    {
        base.LoseLevel();
        countdown.StopCountdown();
    }

    private void StartCountdown()
    {
        countdown.StartCountdown();
    }

    private void OnCountdownFinished()
    {
        IsAllowedToShoot = true;
        inputService.Enable();

        foreach (Enemy enemy in enemyCounter.Enemies)
        {
            enemy.AI.StartShootingRoutine();
        }
    }

    private void OnCountdownStepCompleted(int step)
    {
        FloatingText floatingText = gameFactory.CreateFloatingText(canvas).GetComponent<FloatingText>();

        switch (step)
        {
            case 1:
                floatingText.SetText($"Ready");
                floatingText.SetBackgroundImageColor(Color.black);
                break;
            case 2:
                floatingText.SetText($"Steady");
                floatingText.SetBackgroundImageColor(Color.black);
                break;
            case 3:
                floatingText.SetText($"GO!");
                floatingText.SetBackgroundImageColor(Color.green);
                break;
        }

        Destroy(floatingText.gameObject, 2f);
    }

    private void OnPlayerKilled(Player player)
    {
        LoseLevel();
    }
}