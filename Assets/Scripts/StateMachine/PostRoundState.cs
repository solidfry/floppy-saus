using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PostRoundState : IGameState
{
    public IGameState DoState(GameManager gameManager)
    {
        return gameManager.postRoundState;
    }
}
