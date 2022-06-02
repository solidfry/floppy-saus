using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStates
{
    PreGame,
    PreRound,
    Playing,
    GameOver,
}

public class GameManager : MonoBehaviour
{
    public GameStates gameState = GameStates.PreGame;
    public Vector2 vBounds;
    public Vector2 hBounds;

    private void StateManager()
    {
        // TODO: State manager will go here. Need to brush up on that.
    }

}
