using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public delegate void PreGame();
    public delegate void RoundStart();
    public delegate void GameOver();
    public delegate void PlayerScored();

    /// <summary>
    /// Called before our game starts might be good for set up stuff
    /// </summary>
    public static PreGame OnPreGameEvent;

    /// <summary>
    /// When the round starts we might reset a timer
    /// </summary>
    public static RoundStart OnRoundStartEvent;

    /// <summary>
    /// When the game has ended because the goal has not been reached
    /// </summary>
    public static GameOver OnGameOverEvent;

    /// <summary>
    /// When the player scores
    /// </summary>
    public static PlayerScored OnPlayerScoredEvent;
}
