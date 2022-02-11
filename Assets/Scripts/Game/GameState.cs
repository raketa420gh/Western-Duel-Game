using UnityEngine;

namespace Raketa420
{
    public abstract class GameState
    {
        protected Game game;
        protected GameStateMachine stateMachine;
        
        protected GameState(Game game, GameStateMachine stateMachine)
        {
            this.game = game;
            this.stateMachine = stateMachine;
        }

        public virtual void Enter()
        {
            Debug.Log($"Game {stateMachine.CurrentState} state entered");
        }

        public virtual void HandleInput()
        {
        }

        public virtual void LogicUpdate()
        {
        }

        public virtual void Exit()
        {
        }
    }
}