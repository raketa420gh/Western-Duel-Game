using UnityEngine;

namespace Raketa420
{
    [RequireComponent(typeof(LevelSessionManager))]
    [RequireComponent(typeof(UserInput))]
    [RequireComponent(typeof(UIManager))]

    public class Game : MonoBehaviour
    {
        public GameStateMachine stateMachine;
        public GameplayState gameplayState;

        [SerializeField] private UserInput input;
        [SerializeField] private LevelSessionManager levelSessionManager;
        [SerializeField] private UIManager uiManager;

        private void Awake()
        {
            input = GetComponent<UserInput>();
            levelSessionManager = GetComponent<LevelSessionManager>();
            uiManager = GetComponent<UIManager>();
        }

        private void Start()
        {
            Initialize();
        }

        private void Update()
        {
            stateMachine.CurrentState.LogicUpdate();
        }

        private void Initialize()
        {
            InitializeStateMachine();

            input.Initialize();
            levelSessionManager.Initialize();
            uiManager.Initialize();
        }

        private void InitializeStateMachine()
        {
            stateMachine = GetComponent<GameStateMachine>();
            gameplayState = new GameplayState(this, stateMachine);

            stateMachine.Initialize(gameplayState);
        }
    }
}
