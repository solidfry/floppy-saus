using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverState : IGameState
{
    [SerializeField]
    private bool _isGameOver = false;
    public bool isGameOver
    {
        get => _isGameOver;
        set => _isGameOver = value;
    }

    [SerializeField]
    private bool _newGame = false;
    public bool newGame
    {
        get => _newGame;
        set => _newGame = value;
    }

    public IGameState DoState(GameManager gameManager)
    {
        if (isGameOver)
        {
            isGameOver = false;
            Debug.Log("isGameOver was equal to true and is now equal to " + isGameOver);
            return gameManager.gameOverState;
        }

        if (newGame)
        {
            newGame = false;
            Debug.Log("newGame should be false and is " + newGame);
            return gameManager.preGameState;
        }
        newGame = false;
        return gameManager.gameOverState;
    }

    public IEnumerator DelayGameOver(float delayTime)
    {
        isGameOver = true;
        Debug.Log("isGameOver: " + isGameOver);
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene("GameOver");
    }

    public void NewGame()
    {
        newGame = true;
        Debug.Log("New Game is true");
    }

}
