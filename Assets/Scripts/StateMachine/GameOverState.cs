using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : IGameState
{
    public IGameState DoState(GameManager gameManager)
    {
        GameEvents.OnGameOverEvent?.Invoke();
        return gameManager.gameOverState;
    }
}
