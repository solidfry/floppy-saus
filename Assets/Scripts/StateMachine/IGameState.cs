using System.Collections;
using System.Collections.Generic;
using StateMachine;
using UnityEngine;

public interface IGameState
{
    IGameState DoState(GameManager manager);
}
