using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public delegate void SetUp();
    public delegate void MenuEnter();
    public delegate void MenuLeave();
    public delegate void PreGame();
    public delegate void PreRound();
    public delegate void SpawnObstacles();
    public delegate void DestroyObstacles();
    public delegate void Playing();
    public delegate void GameOver();
    public delegate void PostRound();
    public delegate void PlayerScored();
    public delegate void SplatCollision();
    public delegate void TimerZero();
    public delegate void OutOfBounds();

    ///<summary>
    /// Some basic set up for the game when the game is initialised
    ///</summary>
    public static SetUp OnSetUpEvent;
    
    /// <summary>
    /// User is in a menu
    /// </summary>
    public static MenuEnter OnEnterMenuStateEvent;
    public static MenuLeave OnLeaveMenuStateEvent;

    /// <summary>
    /// Called before our game starts might be good for set up stuff
    /// </summary>
    public static PreGame OnPreGameEvent;

    /// <summary>
    /// Preround state where the score is incremented if needed
    /// </summary>
    public static PreRound OnPreRoundEvent;

    /// <summary>
    /// Tell the game to spawn obstacles
    /// </summary>
    public static SpawnObstacles OnSpawnObstaclesEvent;

    /// <summary>
    /// Destroy obstacles
    /// </summary>
    public static DestroyObstacles OnDestroyObstaclesEvent;

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
    /// When a level ends we go to the post round state
    /// </summary>
    public static PostRound OnPostRoundEvent;

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
