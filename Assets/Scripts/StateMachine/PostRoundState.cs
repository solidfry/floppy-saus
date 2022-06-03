using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostRoundState : IGameState
{
    public IGameState DoState(GameManager gameManager)
    {
        return gameManager.preRoundState;
    }
}
