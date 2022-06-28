using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StateMachine
{
    [Serializable] 
    public class PlayingState : IGameState
    {
        [SerializeField]
        private bool timerZero = false;
        public bool TimerZero
        {
            get => timerZero;
            set => timerZero = value;
        }
        [SerializeField]
        private bool playerScored = false;
        public bool PlayerScored
        {
            get => playerScored;
            set => playerScored = value;
        }

        public IGameState DoState(GameManager gameManager)
        {
            if (TimerZero)
            {
                TimerZero = false;
                gameManager.PreRoundState.IsPlaying = false;
                gameManager.PreGameState.StartGame = false;
//            GameEvents.OnGameOverEvent?.Invoke();
                /* todo based on the game mode we need to add a condition here where the game over state will go to a post round screen */
                return gameManager.GameOverState;
            }

            if (PlayerScored && gameManager.CurrentLevelType == LevelType.Endless)
            {
                // GameEvents.OnPreRoundEvent?.Invoke();
                PlayerScored = false;
                // todo: might wanna remove this later just cos it could break things.
                TimerZero = false;
                return gameManager.PreRoundState;
            }

            if (PlayerScored && gameManager.CurrentLevelType == LevelType.Level)
            {
                PlayerScored = false;
                // todo: might wanna remove this later just cos it could break things.
                TimerZero = false;
                SceneManager.LoadScene("PostRound");
                return gameManager.PostRoundState;
            }

            TimerZero = false;
            PlayerScored = false;
            return gameManager.PlayingState;
        }

        public void SetTimerIsZero()
        {
            TimerZero = true;
            Debug.Log("Timer Zero is true");
        }

        public void SetPlayerScored()
        {
            PlayerScored = true;
            Debug.Log("Player scored YAY");
        }
    }
}
