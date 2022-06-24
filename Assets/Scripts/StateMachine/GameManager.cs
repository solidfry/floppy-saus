using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

namespace StateMachine
{
    public class GameManager : MonoBehaviour
    {
        [Header("State Information")]
        public static GameManager Instance = null;
        private IGameState currentState;
        [ReadOnly]
        [SerializeField]
        private bool gameHasSetUp;
        [ReadOnly]
        [SerializeField]
        private string currentStateName;
        [Header("Scene Information")]
        [ReadOnly]
        [SerializeField]
        public int currentSceneID;

        [field: Header("Level Information")]
        [field: ReadOnly]
        [field: SerializeField]
        public LevelType CurrentLevelType { get; private set; }

        // todo Refactor this score to be not in the manager
        [SerializeField]
        private int score = 0;
        [SerializeField]
        public TMP_Text scoreText;
        [SerializeField]
        private float gameOverDelayTime;
        [SerializeField]
        private WorldManager worldManager;
        
       
        public List<Level> allLevels = new();
       
        
        public readonly MenuState MenuState = new();
        public readonly PreGameState PreGameState = new();
        public readonly PreRoundState PreRoundState = new();
        public readonly PlayingState PlayingState = new();
        public readonly PostRoundState PostRoundState = new();
        public readonly GameOverState GameOverState = new();

        private void Awake()
        {
            gameHasSetUp = false;
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
        }

        private void OnEnable()
        {
            CurrentLevelType = GetCurrentLevelType();
            currentState = MenuState;
            GameEvents.OnSetUpEvent += GetAllLevels;
            GameEvents.OnLeaveMenuStateEvent += MenuState.LeaveMenu;
            GameEvents.OnEnterMenuStateEvent += () => currentState = MenuState;
            GameEvents.OnEnterMenuStateEvent += MenuState.EnterMenu;
            GameEvents.OnPreGameEvent += GameOverState.NewGame;
            GameEvents.OnPreRoundEvent += PreGameState.EnableStartGame;
            GameEvents.OnPlayerScoredEvent += PreRoundState.SetNewRound;
            GameEvents.OnPlayerScoredEvent += PlayingState.SetPlayerScored;
            GameEvents.OnPlayingEvent += PreRoundState.EnablePlaying;
            GameEvents.OnTimerZeroEvent += PlayingState.SetTimerIsZero;
            GameEvents.OnPlayerScoredEvent += Scored;
            GameEvents.OnPreGameEvent += ResetScore;
            GameEvents.OnGameOverEvent += GameOver;
        }

        private void OnDisable()
        {
            GameEvents.OnSetUpEvent -= GetAllLevels;
            GameEvents.OnLeaveMenuStateEvent -= MenuState.LeaveMenu;
            GameEvents.OnEnterMenuStateEvent -= MenuState.EnterMenu;
            GameEvents.OnPreGameEvent -= GameOverState.NewGame;
            GameEvents.OnPreRoundEvent -= PreGameState.EnableStartGame;
            GameEvents.OnPlayerScoredEvent -= PreRoundState.SetNewRound;
            GameEvents.OnPlayerScoredEvent -= PlayingState.SetPlayerScored;
            GameEvents.OnPlayingEvent -= PreRoundState.EnablePlaying;
            GameEvents.OnTimerZeroEvent -= PlayingState.SetTimerIsZero;
            GameEvents.OnPlayerScoredEvent -= Scored;
            GameEvents.OnPreGameEvent -= ResetScore;
            GameEvents.OnGameOverEvent -= GameOver;
        }

        private void Update()
        {
            // We only want to run this once because we need to get all the levels only once.
            if (gameHasSetUp == false) 
            {
                GameEvents.OnSetUpEvent?.Invoke();
                gameHasSetUp = true;
            }
            currentState = currentState.DoState(this);
            currentStateName = currentState.ToString();
            currentSceneID = SceneManager.GetActiveScene().buildIndex;
            GetCurrentLevelType();
        }

        private void Scored()
        {
            score++;
            UpdateUI(score);
        }

        void ResetScore()
        {
            score = 0;
            UpdateUI(score);
        }

        void UpdateUI(int scoreToString)
        {
            scoreText.text = scoreToString.ToString();
        }

        /// <summary>
        /// Add a short delay before new scene when the game over state is activated
        /// </summary>
        void GameOver()
        {
            StartCoroutine(GameOverState.DelayGameOver(gameOverDelayTime));
        }

        /// <summary>
        /// Get all the levels + the endless level from the world manager and add them to the allLevels list
        /// </summary>
        void GetAllLevels()
        {
            if (worldManager == null)
            {
                Debug.Log("worldManager was null");
                return;
            }
            
            allLevels.Add(worldManager.endlessLevel);
            foreach (var level in worldManager.worlds.SelectMany(world => world.levels))
            {
                allLevels.Add(level);
                Debug.Log(level + " was added");
            }

            Debug.Log(allLevels.Count);
        }

        /// <summary>
        /// Look through all levels and find the level that matches the current sceneID
        /// </summary>
        /// <returns>LevelType</returns>
        LevelType GetCurrentLevelType()
        {
            Level levelIDToMatch = allLevels.Find(level => level.sceneID == currentSceneID);
            if (levelIDToMatch)
            {
                return CurrentLevelType = levelIDToMatch.levelType;
            }
            else
            {
                return CurrentLevelType = LevelType.None;
            }
        }

    }
}