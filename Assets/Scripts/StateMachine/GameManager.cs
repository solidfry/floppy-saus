using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private IGameState currentState;
    [SerializeField]
    private string currentStateName;
    [SerializeField]
    private int score = 0;
    [SerializeField]
    public TMP_Text scoreText;
    [SerializeField]
    private float gameOverDelayTime;

    public PreGameState preGameState = new PreGameState();
    public PreRoundState preRoundState = new PreRoundState();
    public PlayingState playingState = new PlayingState();
    public PostRoundState postRoundState = new PostRoundState();
    public GameOverState gameOverState = new GameOverState();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    private void OnEnable()
    {
        currentState = preGameState;
        GameEvents.OnPreGameEvent += gameOverState.NewGame;
        GameEvents.OnPreRoundEvent += preGameState.EnableStartGame;
        GameEvents.OnPlayerScoredEvent += preRoundState.SetNewRound;
        GameEvents.OnPlayerScoredEvent += playingState.SetPlayerScored;
        GameEvents.OnPlayingEvent += preRoundState.SetPlaying;
        GameEvents.OnTimerZeroEvent += playingState.SetTimerIsZero;
        GameEvents.OnPlayerScoredEvent += Scored;
        GameEvents.OnPreGameEvent += ResetScore;
        GameEvents.OnGameOverEvent += GameOver;
    }

    private void OnDisable()
    {
        GameEvents.OnPreGameEvent -= gameOverState.NewGame;
        GameEvents.OnPreRoundEvent -= preGameState.EnableStartGame;
        GameEvents.OnPlayerScoredEvent -= preRoundState.SetNewRound;
        GameEvents.OnPlayerScoredEvent -= playingState.SetPlayerScored;
        GameEvents.OnPlayingEvent -= preRoundState.SetPlaying;
        GameEvents.OnTimerZeroEvent -= playingState.SetTimerIsZero;
        GameEvents.OnPlayerScoredEvent -= Scored;
        GameEvents.OnPreGameEvent -= ResetScore;
        GameEvents.OnGameOverEvent -= GameOver;
    }

    private void Update()
    {
        currentState = currentState.DoState(this);
        currentStateName = currentState.ToString();
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

    void UpdateUI(int score)
    {
        scoreText.text = score.ToString();
    }

    void GameOver()
    {
        StartCoroutine(gameOverState.DelayGameOver(gameOverDelayTime));
    }

}
