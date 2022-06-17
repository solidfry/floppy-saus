using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

[System.Serializable]
public class GameOverState : IGameState
{
    [SerializeField]
    private bool isGameOver = false;
    [SerializeField]
    private bool newGame = false;

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
