using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverState : IGameState
{

    public IGameState DoState(GameManager gameManager)
    {
        GameEvents.OnGameOverEvent?.Invoke();
        return gameManager.gameOverState;
    }

    public IEnumerator DelayGameOver()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("GameOver");
    }

}
