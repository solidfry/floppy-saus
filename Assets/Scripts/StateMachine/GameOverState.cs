using System.Collections;
using StateMachine;
using UnityEngine.SceneManagement;
using UnityEngine;

[System.Serializable]
public class GameOverState : IGameState
{
    [SerializeField]
    private bool isGameOver = false;
    public bool IsGameOver
    {
        get => isGameOver;
        set => isGameOver = value;
    }

    [SerializeField]
    private bool isNewGame = false;
    public bool IsNewGame
    {
        get => isNewGame;
        set => isNewGame = value;
    }

    public IGameState DoState(GameManager gameManager)
    {
        if (IsGameOver)
        {
            GameEvents.OnGameOverEvent?.Invoke();
            IsNewGame = false;
            IsGameOver = false;
            if(SceneManager.GetActiveScene().name != "GameOver") { 
                gameManager.StartCoroutine(DelayGameOver(gameManager.gameOverDelayTime));
                Debug.Log("Loading GAME OVER SCREEN");
                return gameManager.GameOverState;
            }
        }

        if (IsNewGame)
        {
            IsNewGame = false;
            IsGameOver = false;
            Debug.Log("newGame should be false and is " + IsNewGame);
            return gameManager.PreGameState;
        }
        IsNewGame = false;
        IsGameOver = true;
        return gameManager.GameOverState;
    }

    public IEnumerator DelayGameOver(float delayTime)
    {
        IsGameOver = false;
        //Debug.Log("isGameOver: " + IsGameOver);
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene("GameOver");
    }

    public void NewGame()
    {
        IsNewGame = true;
        Debug.Log("New Game is true");
    }

    public void SetIsGameOver()
    {
        IsGameOver = true;
        Debug.Log("IsGameOver is " + IsGameOver);
    }

}
