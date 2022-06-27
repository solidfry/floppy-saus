using UnityEngine;
using TMPro;

namespace StateMachine
{
    [System.Serializable]
    public class PreGameState : IGameState
    {
        [SerializeField] bool startGame = false;

        public bool StartGame
        {
            get => startGame;
            set => startGame = value;
        }

        [SerializeField] private bool newPreGameState;

        public bool NewPreGameState
        {
            get => newPreGameState;
            set => newPreGameState = value;
        }

        public IGameState DoState(GameManager gameManager)
        {
            if (NewPreGameState)
            {
                NewPreGameState = false;
                Debug.Log("OnPreGameEvent was run");
                GameEvents.OnPreGameEvent?.Invoke();
            }

            if (gameManager.CurrentLevelType == LevelType.Endless && gameManager.scoreText == null)
            {
                if (GameObject.Find("ScoreText"))
                {
                    gameManager.scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
                }
            }

            if (StartGame)
            {
                DisableStartGame();
                NewPreGameState = true;
                return gameManager.PreRoundState;
            }

            DisableStartGame();
            return gameManager.PreGameState;
        }

        public void EnableStartGame()
        {
            StartGame = true;
        }

        void DisableStartGame()
        {
            StartGame = false;
        }
    }
}