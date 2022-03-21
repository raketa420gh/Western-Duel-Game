using Raketa420;
using UnityEngine;
using Zenject;

public abstract class GameLoopBase : MonoBehaviour
{
    private IInputService inputService;
    private ICountdownService countdown;
    private IGameFactory gameFactory;
    private Canvas canvas;
    private Player player;
    private EnemyCounter enemyCounter;
    private Crosshair crosshair;
    private UIPanelsView uiPanelsView;
    private CameraMotion cameraMotion;

    protected bool IsAllowedToShoot; //=> !countdown.IsActive;

    [Inject]
    public void Construct(IInputService inputService, IGameFactory gameFactory, ICountdownService countdown,
        Canvas canvas, Player player, Crosshair crosshair, EnemyCounter enemyCounter, CameraMotion cameraMotion)
    {
        this.canvas = canvas;
        this.inputService = inputService;
        this.gameFactory = gameFactory;
        this.countdown = countdown;
        this.player = player;
        this.crosshair = crosshair;
        this.enemyCounter = enemyCounter;
        this.cameraMotion = cameraMotion;

        uiPanelsView = canvas.GetComponentInChildren<UIPanelsView>();

        SubscribeEvents();
    }

    private void Start()
    {
        StartGameLoop();
    }

    protected void Update()
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

    protected virtual void StartGameLoop()
    {
        cameraMotion.StartMotion();
        inputService.Enable();
        crosshair.Disable();
        //Invoke(nameof(StartCountdown), 1f);
    }

    protected virtual void SubscribeEvents()
    {
        enemyCounter.OnAllEnemiesDied += OnAllEnemiesDied;
        //countdown.OnStepCompleted += OnCountdownStepCompleted;
        //countdown.OnCountdownFinished += OnCountdownFinished;
        //player.OnKilled += OnPlayerKilled;
    }

    protected virtual void UnsubscribeEvents()
    {
        enemyCounter.OnAllEnemiesDied -= OnAllEnemiesDied;
        //countdown.OnStepCompleted -= OnCountdownStepCompleted;
        //countdown.OnCountdownFinished -= OnCountdownFinished;
        //player.OnKilled -= OnPlayerKilled;
    }

    protected  virtual void LoseLevel()
    {
        inputService.Disable();
        uiPanelsView.ShowLosePanel();
        //countdown.StopCountdown();
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

    private void ShowWinPanel()
    {
        uiPanelsView.ShowWinPanel();
    }

    private void OnAllEnemiesDied()
    {
        inputService.Disable();
        Invoke(nameof(ShowWinPanel), 2f);
    }
}