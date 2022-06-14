using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    bool collidedWithGoal = false;
    Transform goalPosition;

    private void Awake()
    {
        goalPosition = this.gameObject.transform;
        Debug.Log("The goal position:" + goalPosition.position);
    }

    private void OnEnable()
    {
        GameEvents.OnPreRoundEvent += SetPosition;
    }

    private void OnDisable()
    {
        GameEvents.OnPreRoundEvent -= SetPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.CompareTag("Dropper") || other.CompareTag("Player")) && collidedWithGoal == false)
        {
            Debug.Log("The Goal was hit");
            GameEvents.OnPlayerScoredEvent?.Invoke();
            collidedWithGoal = true;
        }
    }

    void SetPosition()
    {
        float pos = Random.Range(Boundaries.hBounds.x, Boundaries.hBounds.y);
        Vector3 newPos = new Vector3(pos, goalPosition.position.y, 0);
        goalPosition.position = newPos;
        collidedWithGoal = false;
        Debug.Log("Set position of goal value: " + pos);
    }
}
