using UnityEngine;
using TMPro;

namespace StateMachine
{
    [System.Serializable]
    public class PreGameState : IGameState
    {
        #region Pre Game Fields
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
        #endregion
        public IGameState DoState(GameManager gameManager)
        {
            if (NewPreGameState)
            {
                DisableStartGame();
                DisableNewPreGameState();
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
                EnableNewPreGameState();
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

        public void EnableNewPreGameState()
        {
            NewPreGameState = true;
            Debug.Log("NewPreGameState is " + NewPreGameState);
        }

        void DisableNewPreGameState()
        {
            NewPreGameState = false;
            Debug.Log("NewPreGameState is " + NewPreGameState);
        }
    }
}