using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingState : IGameState
{
    [SerializeField]
    private bool timerZero = false;
    [SerializeField]
    private bool playerScored = false;
    public IGameState DoState(GameManager gameManager)
    {
        if (timerZero)
        {
            timerZero = false;
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
