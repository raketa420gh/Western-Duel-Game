using System.Linq;
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
    private SceneLoader sceneLoader;
    private EnemyCounter enemyCounter;
    
    private bool IsAllowedToShoot => !countdown.IsActive;

    [Inject]
    public void Construct(IInputService inputService, IGameFactory gameFactory, ICountdownService countdown,
        Canvas canvas, Player player, Crosshair crosshair, SceneLoader sceneLoader, EnemyCounter enemyCounter)
    {
        this.sceneLoader = sceneLoader;
        this.canvas = canvas;
        this.inputService = inputService;
        this.gameFactory = gameFactory;
        this.countdown = countdown;
        this.player = player;
        this.crosshair = crosshair;
        this.enemyCounter = enemyCounter;
        
        SubscribeEvents();
    }

    private void OnDisable()
    {
        countdown.OnStepCompleted -= OnCountdownStepCompleted;
        countdown.OnCountdownFinished -= OnCountdownFinished;
        enemyCounter.OnAllEnemiesDied -= OnAllEnemiesDied;
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
    }

    private void ReloadScene()
    {
        sceneLoader.ReloadScene();
    }

    private void OnCountdownFinished()
    {
        inputService.Enable();
    }

    private void SubscribeEvents()
    {
        countdown.OnStepCompleted += OnCountdownStepCompleted;
        countdown.OnCountdownFinished += OnCountdownFinished;
        enemyCounter.OnAllEnemiesDied += OnAllEnemiesDied;
    }

    private void OnCountdownStepCompleted(int step)
    {
        FloatingText floatingText = gameFactory.CreateFloatingText(canvas).GetComponent<FloatingText>();

        switch (step)
        {
            case 1:
                floatingText.SetText($"Ready");
                break;
            case 2:
                floatingText.SetText($"Steady");
                break;
            case 3:
                floatingText.SetText($"GO!");
                break;
        }

        Destroy(floatingText.gameObject, 2f);
    }

    private void OnAllEnemiesDied()
    {
        Invoke(nameof(ReloadScene), 1f);
    }
}