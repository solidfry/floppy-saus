using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreRoundState : IGameState
{

    bool isPlaying = false;
    bool newRound = false;
    public IGameState DoState(GameManager gameManager)
    {

        if (newRound)
        {
            GameEvents.OnPreRoundEvent?.Invoke();
            Debug.Log("A new round has started");
            GameEvents.OnDestroyObstaclesEvent?.Invoke();
            Debug.Log("DestroyObstaclesEvent has been invoked");
            GameEvents.OnSpawnObstaclesEvent?.Invoke();
            Debug.Log("OnSpawnObstaclesEvent has been invoked");
            newRound = false;
            isPlaying = false;
            return gameManager.preRoundState;
        }

        if (isPlaying)
        {
            isPlaying = false;
            Debug.Log("Pre Round State is shifting to Playing state");
            return gameManager.playingState;
        }

        newRound = false;
        isPlaying = false;
        return gameManager.preRoundState;
    }

    public void SetPlaying()
    {
        isPlaying = true;
    }

    public void SetNewRound()
    {
        newRound = true;
    }
}
