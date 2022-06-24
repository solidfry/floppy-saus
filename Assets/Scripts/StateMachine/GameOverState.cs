using System.Collections;
using System.Collections.Generic;
using StateMachine;
using UnityEngine.SceneManagement;
using UnityEngine;

// ReSharper disable once CheckNamespace
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
            IsGameOver = false;
            //Debug.Log("isGameOver was equal to true and is now equal to " + IsGameOver);
            return gameManager.GameOverState;
        }

        if (IsNewGame)
        {
            IsNewGame = false;
            //Debug.Log("newGame should be false and is " + newGame);
            return gameManager.PreGameState;
        }
        IsNewGame = false;
        return gameManager.GameOverState;
    }

    public IEnumerator DelayGameOver(float delayTime)
    {
        IsGameOver = true;
        //Debug.Log("isGameOver: " + IsGameOver);
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene("GameOver");
    }

    public void NewGame()
    {
        IsNewGame = true;
        Debug.Log("New Game is true");
    }

}
