using System.Collections;
using System.Collections.Generic;
using StateMachine;
using UnityEngine;

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
            gameManager.PreRoundState.isPlaying = false;
            gameManager.PreGameState.startGame = false;
            GameEvents.OnGameOverEvent?.Invoke();
            /* todo based on the game mode we need to add a condition here where the game over state will go to a post round screen */
            return gameManager.GameOverState;
        }

        if (PlayerScored)
        {
            // GameEvents.OnPreRoundEvent?.Invoke();
            PlayerScored = false;
            return gameManager.PreRoundState;
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
