using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingState : IGameState
{
    [SerializeField]
    private bool timerZero = false;
    private bool playerScored = false;
    public IGameState DoState(GameManager gameManager)
    {
        if (timerZero)
        {
            return gameManager.gameOverState;
        }

        if (playerScored)
        {
            GameEvents.OnPreRoundEvent?.Invoke();
            playerScored = false;
            return gameManager.preRoundState;
        }

        timerZero = false;
        return gameManager.playingState;
    }

    public void GameOver()
    {
        timerZero = true;
        Debug.Log("Timer Zero is true");
    }

    public void PreRound()
    {
        playerScored = true;
        Debug.Log("Player scored YAY");
    }
}
