using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Dropper"))
        {
            Debug.Log("The Goal was hit");
            GameEvents.OnPlayerScoredEvent?.Invoke();
        }
    }
}
