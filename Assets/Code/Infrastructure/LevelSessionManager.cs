using UnityEngine;
using System.Collections;

namespace Raketa420
{
    public class LevelSessionManager : MonoBehaviour
    {
        [SerializeField] private SceneLoader sceneLoader;
        [SerializeField] private UserInput input;
        [SerializeField] private UIManager uiManager;
        [SerializeField] private CountdownManager countdown;
        [SerializeField] private EnemyCounter enemyCounter;
        [SerializeField] private Crosshair crosshair;
        [SerializeField] private GameObject floatingTextPrefab;
        [SerializeField] private Canvas canvas;
        [SerializeField] private Enemy[] enemies;
        [SerializeField] private Player player;

        private bool IsAllowedToShoot => !countdown.IsActive;

        private void OnEnable()
        {
            countdown.OnCountdownFinished += OnCountdownFinished;
            countdown.OnStepCompleted += OnCountdownStepCompleted;
            enemyCounter.OnAllEnemiesDied += OnAllEnemiesDied;
            player.OnKilled += OnPlayerKilled;
        }

        private void OnDisable()
        {
            countdown.OnCountdownFinished -= OnCountdownFinished;
            countdown.OnStepCompleted -= OnCountdownStepCompleted;
            enemyCounter.OnAllEnemiesDied -= OnAllEnemiesDied;
            player.OnKilled -= OnPlayerKilled;
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                if (!player.IsAlive)
                {
                    return;
                }

                PlayerShoot();
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
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

        public void Initialize()
        {
            StartLevel();
        }

        private void StartLevel()
        {
            input.Enable(true);
            crosshair.Disable();
            countdown.StartCountdown();
            player.Gun.Initialize();
        }

        public void FinishLevel()
        {
            RestartLevel();
        }

        private void RestartLevel()
        {
            sceneLoader.ReloadScene();
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
            input.Enable(false);
            uiManager.ShowLosePanel();
        }

        private void WinLevel()
        {
            input.Enable(false);
            uiManager.ShowWinPanel();
        }

        private IEnumerator ActivateEnemiesShootRoutine()
        {
            yield return new WaitForSeconds(0.5f);

            foreach (var enemy in enemies)
            {
                enemy.AI.StartShootingRoutine();
            }
        }

        private void OnPlayerKilled(Player player)
        {
            Invoke(nameof(LoseLevel), 1f);
        }

        private void OnAllEnemiesDied()
        {
            Invoke(nameof(WinLevel), 2.5f);
        }

        private void OnCountdownFinished()
        {
            StartCoroutine(nameof(ActivateEnemiesShootRoutine));
        }

        private void OnCountdownStepCompleted(int step)
        {
            var floatingTextObject = Instantiate(floatingTextPrefab, canvas.transform.position, Quaternion.identity);
            floatingTextObject.transform.SetParent(canvas.transform);
            floatingTextObject.transform.SetSiblingIndex(0);

            var floatingText = floatingTextObject.GetComponent<FloatingText>();
            if (step == 1)
                floatingText.SetText($"Ready");
            if (step == 2)
                floatingText.SetText($"Steady");
            if (step == 3)
                floatingText.SetText($"GO!");

            Destroy(floatingTextObject, 2f);
        }
    }
}

