using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartGame : MonoBehaviour
{
    public void NewRound()
    {
        Debug.Log("New Round pressed");
        GameEvents.OnPreRoundEvent?.Invoke();
        this.gameObject.SetActive(false);
    }

    public void NewGame()
    {
        Debug.Log("New Game pressed");
        GameEvents.OnPreGameEvent?.Invoke();
    }

    public void LeaveMenu()
    {
        GameEvents.OnLeaveMenuStateEvent?.Invoke();
    }
    public void EnterMenu()
    {
        GameEvents.OnEnterMenuStateEvent?.Invoke();
    }
}
