using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PreGameState : IGameState
{
    bool _startGame = false;
    public bool startGame
    {
        get => _startGame;
        set => _startGame = value;
    }

    public IGameState DoState(GameManager gameManager)
    {

        if (gameManager.scoreText == null)
            gameManager.scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();

        if (startGame)
        {
            DisableStartGame();
            return gameManager.preRoundState;
        }

        DisableStartGame();
        return gameManager.preGameState;
    }

    public void EnableStartGame()
    {
        startGame = true;
    }

    public void DisableStartGame()
    {
        startGame = false;
    }


}
