using Raketa420;
using UnityEngine;
using Zenject;

public class GameLoop : MonoBehaviour
{
    private IInputService inputService;
    private IGameFactory gameFactory;
    private ICountdownService countdown;
    private Canvas canvas;
    private Player player;
    private Crosshair crosshair;
    private EnemyCounter enemyCounter;
    private UIPanelsView uiPanelsView;
    
    private bool IsAllowedToShoot => !countdown.IsActive;

    [Inject]
    public void Construct(IInputService inputService, IGameFactory gameFactory, ICountdownService countdown,
        Canvas canvas, Player player, Crosshair crosshair, EnemyCounter enemyCounter)
    {
        this.canvas = canvas;
        this.inputService = inputService;
        this.gameFactory = gameFactory;
        this.countdown = countdown;
        this.player = player;
        this.crosshair = crosshair;
        this.enemyCounter = enemyCounter;

        uiPanelsView = canvas.GetComponentInChildren<UIPanelsView>();
        
        SubscribeEvents();
    }

    private void Start()
    {
        inputService.Enable();
        crosshair.Disable();
        countdown.StartCountdown();
    }

    private void Update()
    {
        if (!inputService.IsEnabled) 
            return;
        
        if (inputService.IsAxisDragged())
        {
            crosshair.Move(inputService.Axis);
        }
        
        if (inputService.IsShootButtonUp())
        {
            if (!player.IsAlive)
            {
                return;
            }

            PlayerShoot();
        }

        if (inputService.IsShootButtonDown())
        {
            if (IsAllowedToShoot)
            {
                StartPlayerAiming();
            }
            else
            {
                LoseLevel();
            }
        }
    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    private void SubscribeEvents()
    {
        countdown.OnStepCompleted += OnCountdownStepCompleted;
        countdown.OnCountdownFinished += OnCountdownFinished;
        enemyCounter.OnAllEnemiesDied += OnAllEnemiesDied;
        player.OnKilled += OnPlayerKilled;
    }

    private void UnsubscribeEvents()
    {
        countdown.OnStepCompleted -= OnCountdownStepCompleted;
        countdown.OnCountdownFinished -= OnCountdownFinished;
        enemyCounter.OnAllEnemiesDied -= OnAllEnemiesDied;
        player.OnKilled -= OnPlayerKilled;
    }

    private void StartPlayerAiming()
    {
        crosshair.Enable();
        crosshair.ResetPosition();
        player.Gun.DirectBarrel();
        player.Animation.PlayPistolIdle();
    }

    private void PlayerShoot()
    {
        player.Gun.Shoot();
        player.Gun.UndirectBarrel();
        crosshair.Disable();
        player.Animation.PlayIdle();
    }

    private void LoseLevel()
    {
        Debug.Log("LOSE LEVEL");
        inputService.Disable();
        countdown.StopCountdown();
        uiPanelsView.ShowLosePanel();
    }

    private void ShowWinPanel()
    {
        uiPanelsView.ShowWinPanel();
    }

    private void OnCountdownFinished()
    {
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

    private void OnAllEnemiesDied()
    {
        inputService.Disable();
        Invoke(nameof(ShowWinPanel), 2f);
    }

    private void OnPlayerKilled(Player player)
    {
        LoseLevel();
    }
}