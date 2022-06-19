using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreRoundState : IGameState
{
    bool _isPlaying = false;

    public bool isPlaying
    {
        get => _isPlaying;
        set => _isPlaying = value;
    }

    bool _newRound = false;

    public bool newRound
    {
        get => _newRound;
        set => _newRound = value;
    }
    public IGameState DoState(GameManager gameManager)
    {
        Debug.Log("IsPlaying is " + isPlaying);
        if (newRound)
        {
            newRound = false;
            DisablePlaying();
            GameEvents.OnPreRoundEvent?.Invoke();
            Debug.Log("A new round has started");
            GameEvents.OnDestroyObstaclesEvent?.Invoke();
            Debug.Log("DestroyObstaclesEvent has been invoked");
            GameEvents.OnSpawnObstaclesEvent?.Invoke();
            Debug.Log("OnSpawnObstaclesEvent has been invoked");

            return gameManager.preRoundState;
        }

        if (isPlaying)
        {
            DisablePlaying();
            Debug.Log("Pre Round State is shifting to Playing state");
            return gameManager.playingState;
        }

        newRound = false;
        return gameManager.preRoundState;
    }

    public void EnablePlaying()
    {
        isPlaying = true;
        // Debug.Log("EnablePlaying was done and isPlaying is " + isPlaying);
    }

    public void DisablePlaying()
    {
        isPlaying = false;
        // Debug.Log("DisablePlaying was done and isPlaying is " + isPlaying);
    }

    public void SetNewRound()
    {
        newRound = true;
        Debug.Log("SetNewRound was done");
    }
}
