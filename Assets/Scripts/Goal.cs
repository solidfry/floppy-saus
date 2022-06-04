using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
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
        if (other.CompareTag("Dropper") || other.CompareTag("Player"))
        {
            Debug.Log("The Goal was hit");
            // ! BUG: This is invoked multiple times because there are multiple objects that have the tag dropper that could interact when a goal is scored
            GameEvents.OnPlayerScoredEvent?.Invoke();
        }
    }

    void SetPosition()
    {
        float pos = Random.Range(Boundaries.hBounds.x, Boundaries.hBounds.y);
        Vector3 newPos = new Vector3(pos, -4.7f, 0);
        goalPosition.position = newPos;
        Debug.Log("Set position of goal value: " + pos);
    }
}
