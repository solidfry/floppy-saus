using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartGame : MonoBehaviour
{
    public void Pressed()
    {
        Debug.Log("Button pressed");
        GameEvents.OnPreRoundEvent?.Invoke();
        this.gameObject.SetActive(false);
    }
}
