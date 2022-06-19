using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingState : IGameState
{
    [SerializeField]
    private bool _timerZero = false;
    public bool timerZero
    {
        get => _timerZero;
        set => _timerZero = value;
    }

    [SerializeField]
    private bool _playerScored = false;
    public bool playerScored
    {
        get => _playerScored;
        set => _playerScored = value;
    }

    public IGameState DoState(GameManager gameManager)
    {
        if (timerZero)
        {
            timerZero = false;
            gameManager.preRoundState.isPlaying = false;
            gameManager.preGameState.startGame = false;
            GameEvents.OnGameOverEvent?.Invoke();
            return gameManager.gameOverState;
        }

        if (playerScored)
        {
            // GameEvents.OnPreRoundEvent?.Invoke();
            playerScored = false;
            return gameManager.preRoundState;
        }

        timerZero = false;
        playerScored = false;
        return gameManager.playingState;
    }

    public void SetTimerIsZero()
    {
        timerZero = true;
        Debug.Log("Timer Zero is true");
    }

    public void SetPlayerScored()
    {
        playerScored = true;
        Debug.Log("Player scored YAY");
    }
}
