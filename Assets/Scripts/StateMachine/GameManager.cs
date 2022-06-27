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
        [field: ReadOnly]
        [field: SerializeField]
        public Level CurrentLevel { get; private set; }
        [field: ReadOnly]
        [field: SerializeField]
        public Level PreviousLevel { get; private set; }
        // todo Refactor this score to be not in the manager
        [SerializeField]
        private int score = 0;
        [SerializeField]
        public TMP_Text scoreText;
        [SerializeField]
        public float gameOverDelayTime { get; private set; }
        [SerializeField]
        private WorldManager worldManager;
        
       
        public List<Level> allLevels = new();
       
        [SerializeField] public MenuState MenuState = new();
        [SerializeField] public PreGameState PreGameState = new();
        [SerializeField] public PreRoundState PreRoundState = new();
        [SerializeField] public PlayingState PlayingState = new();
        [SerializeField] public PostRoundState PostRoundState = new();
        [SerializeField] public GameOverState GameOverState = new();

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
            GameEvents.OnEnterMenuStateEvent += () => currentState = MenuState;
            GameEvents.OnPreGameEvent += GameOverState.NewGame;
            GameEvents.OnPreRoundEvent += PreGameState.EnableStartGame;
            GameEvents.OnPlayerScoredEvent += PreRoundState.SetNewRound;
            GameEvents.OnPlayerScoredEvent += PlayingState.SetPlayerScored;
            GameEvents.OnPlayingEvent += PreRoundState.EnablePlaying;
            GameEvents.OnTimerZeroEvent += PlayingState.SetTimerIsZero;
            GameEvents.OnPlayerScoredEvent += Scored;
            GameEvents.OnPreGameEvent += ResetScore;
            GameEvents.OnTimerZeroEvent += GameOverState.SetIsGameOver;
        }

        private void OnDisable()
        {
            GameEvents.OnSetUpEvent -= GetAllLevels;
            GameEvents.OnPreGameEvent -= GameOverState.NewGame;
            GameEvents.OnPreRoundEvent -= PreGameState.EnableStartGame;
            GameEvents.OnPlayerScoredEvent -= PreRoundState.SetNewRound;
            GameEvents.OnPlayerScoredEvent -= PlayingState.SetPlayerScored;
            GameEvents.OnPlayingEvent -= PreRoundState.EnablePlaying;
            GameEvents.OnTimerZeroEvent -= PlayingState.SetTimerIsZero;
            GameEvents.OnPlayerScoredEvent -= Scored;
            GameEvents.OnPreGameEvent -= ResetScore;
            GameEvents.OnTimerZeroEvent -= GameOverState.SetIsGameOver;
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
            if (CurrentLevelType == LevelType.Level)
            {
                CurrentLevel = GetCurrentLevel();
            }
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
            if (scoreText != null)
                scoreText.text = scoreToString.ToString();
        }
        
        /// <summary>
        /// Get all the levels + the endless level from the world manager and add them to the allLevels list
        /// </summary>
        void GetAllLevels()
        {
            if (worldManager == null)
            {
                Debug.LogError("worldManager was null");
                return;
            }
            
            allLevels.Add(worldManager.endlessLevel);
            foreach (var level in worldManager.worlds.SelectMany(world => world.levels))
            {
                allLevels.Add(level);
//                Debug.Log(level + " was added");
            }

//            Debug.Log(allLevels.Count);
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

            return CurrentLevelType = LevelType.None;
        }

        Level GetCurrentLevel()
        {
            Level currentLevel = allLevels.Find(level => level.sceneID == currentSceneID);
            return currentLevel;
        }

    }
}