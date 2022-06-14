using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splat : MonoBehaviour
{
    bool soundPlayed = false;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.parent != this.transform.parent && soundPlayed == false)
        {
            GameEvents.OnSplatCollisionEvent?.Invoke();
            soundPlayed = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        soundPlayed = false;
    }
}
