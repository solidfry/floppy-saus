
using System;
using StateMachine;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable] 
public class MenuState : IGameState
{
    public IGameState DoState(GameManager gameManager)
    {
        if (gameManager.CurrentLevelType == LevelType.None)
        {
            return gameManager.MenuState;
        }

        if (gameManager.CurrentLevelType != LevelType.None )
        {
            Debug.Log("CurrentLevelType was not None so we went to PreGame");
            return gameManager.PreGameState;
        }
        
        return gameManager.MenuState;
    }
}
