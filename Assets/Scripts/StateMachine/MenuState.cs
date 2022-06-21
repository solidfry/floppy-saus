using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : IGameState
{
    bool leftMenu = false;

    public IGameState DoState(GameManager gameManager)
    {
        if (leftMenu == true)
        {
            return gameManager.preGameState;
        }
        return gameManager.menuState;
    }

    public void LeaveMenu()
    {
        leftMenu = true;
    }
}
