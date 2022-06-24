using System.Collections;
using System.Collections.Generic;
using StateMachine;
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

        if (gameManager.CurrentLevelType == LevelType.Endless) {
            if (gameManager.scoreText == null)
                gameManager.scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
        }
        
        if (startGame)
        {
            DisableStartGame();
            return gameManager.PreRoundState;
        }

        DisableStartGame();
        return gameManager.PreGameState;
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
