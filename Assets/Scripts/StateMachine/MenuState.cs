using System.Collections;
using System.Collections.Generic;
using StateMachine;
using UnityEngine;

public class MenuState : IGameState
{
    bool leftMenu = false;

    public IGameState DoState(GameManager gameManager)
    {
        if (leftMenu == true)
        {
            return gameManager.PreGameState;
        }
        return gameManager.MenuState;
    }

    public void LeaveMenu()
    {
        leftMenu = true;
    }
    public void EnterMenu()
    {
        leftMenu = false;
    }
}
