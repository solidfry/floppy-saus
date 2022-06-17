using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PreGameState : IGameState
{
    GameManager gameManager;

    bool startRound = false;

    public IGameState DoState(GameManager gameManager)
    {

        if (gameManager.scoreText == null)
            gameManager.scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();

        if (startRound)
        {
            return gameManager.preRoundState;
        }

        startRound = false;
        return gameManager.preGameState;
    }

    public void SetStartRound()
    {
        startRound = true;
    }

}
