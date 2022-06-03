using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreGameState : IGameState
{

    bool roundStarted = false;

    public IGameState DoState(GameManager gameManager)
    {
        if (roundStarted)
        {
            return gameManager.preRoundState;
        }

        roundStarted = false;
        return gameManager.preGameState;
    }

    public void RoundStart()
    {
        roundStarted = true;
    }

}
