using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public delegate void PreGame();
    public delegate void PreRound();
    public delegate void Playing();
    public delegate void GameOver();
    public delegate void PostRound();
    public delegate void PlayerScored();
    public delegate void SplatCollision();
    public delegate void TimerZero();
    public delegate void OutOfBounds();

    /// <summary>
    /// Called before our game starts might be good for set up stuff
    /// </summary>
    public static PreGame OnPreGameEvent;

    /// <summary>
    /// Preround state where the score is incremented if needed
    /// </summary>
    public static PreRound OnPreRoundEvent;

    /// <summary>
    /// When the round starts we might reset a timer
    /// </summary>
    public static Playing OnPlayingEvent;

    /// <summary>
    /// When the game has ended because the goal has not been reached
    /// </summary>
    public static GameOver OnGameOverEvent;

    /// <summary>
    /// When the player scores
    /// </summary>
    public static PlayerScored OnPlayerScoredEvent;

    /// <summary>
    /// Timer hit zero
    /// </summary>
    public static TimerZero OnTimerZeroEvent;

    /// <summary>
    /// When the sausage hits something that needs to splat.
    /// </summary>
    public static SplatCollision OnSplatCollisionEvent;

    // ! Delete this when we remake the level system maybe?
    /// <summary>
    /// When the sausage goes out of bounds.
    /// </summary>
    public static OutOfBounds OnOutOfBoundsEvent;
}
