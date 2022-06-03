using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreRoundState : IGameState
{

    bool isPlaying = false;
    public IGameState DoState(GameManager gameManager)
    {
        if (isPlaying)
        {
            isPlaying = false;
            return gameManager.playingState;
        }
        return gameManager.preRoundState;
    }

    public void Playing()
    {
        isPlaying = true;
    }
}
