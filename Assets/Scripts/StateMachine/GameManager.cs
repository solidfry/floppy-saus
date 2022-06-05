using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private IGameState currentState;
    [SerializeField]
    private string currentStateName;
    [SerializeField]
    private int score = 0;
    [SerializeField]
    private TMP_Text scoreText;

    public PreGameState preGameState = new PreGameState();
    public PreRoundState preRoundState = new PreRoundState();
    public PlayingState playingState = new PlayingState();
    public PostRoundState postRoundState = new PostRoundState();
    public GameOverState gameOverState = new GameOverState();

    private void OnEnable()
    {
        currentState = preGameState;
        GameEvents.OnPreRoundEvent += preGameState.RoundStart;
        GameEvents.OnPlayerScoredEvent += playingState.PreRound;
        GameEvents.OnPlayingEvent += preRoundState.Playing;
        GameEvents.OnTimerZeroEvent += playingState.GameOver;
        GameEvents.OnPlayerScoredEvent += Scored;
        GameEvents.OnPreGameEvent += ResetScore;
        GameEvents.OnGameOverEvent += GameOver;
    }

    private void OnDisable()
    {
        GameEvents.OnPreRoundEvent -= preGameState.RoundStart;
        GameEvents.OnPlayerScoredEvent -= playingState.PreRound;
        GameEvents.OnPlayingEvent -= preRoundState.Playing;
        GameEvents.OnTimerZeroEvent -= playingState.GameOver;
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
        StartCoroutine(gameOverState.DelayGameOver());
    }

}
