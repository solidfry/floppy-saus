using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public enum Movement
{
    Random,
    PingPong,
    Static
}
public class Goal : MonoBehaviour
{
    [FormerlySerializedAs("movement")] [SerializeField]
    private Movement movementType;
    bool collidedWithGoal = false;
    Transform goalPosition;

    [Header("PingPong Settings")] 
    [SerializeField]
    private float speed = 5f;

    Vector2 pos1;
    Vector2 pos2;
    
    [SerializeField]
    private Transform position1;
    [SerializeField]
    private Transform position2;
    
    private void Awake()
    {
        pos1 = position1.position;
        pos2 = position2.position;
        
        goalPosition = this.gameObject.transform;
        Debug.Log("The goal position:" + goalPosition.position);
    }

    private void Update()
    {
        SetMovement(movementType);
    }

    private void OnEnable()
    {
        if (movementType == Movement.Random) 
            GameEvents.OnPreRoundEvent += SetPosition;
    }

    private void OnDisable()
    {
        if (movementType == Movement.Random) 
            GameEvents.OnPreRoundEvent -= SetPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.CompareTag("Dropper") || other.CompareTag("Player")) && collidedWithGoal == false)
        {
            Debug.Log("The Goal was hit");
            collidedWithGoal = true;
            GameEvents.OnPlayerScoredEvent?.Invoke();
        }
    }

    private void PingPong()
    {
        goalPosition.position = Vector2.Lerp(pos1, pos2, Mathf.PingPong(speed * Time.time, 1f));
    }

    void SetPosition()
    {
        float pos = Random.Range(Boundaries.hBounds.x, Boundaries.hBounds.y);
        Vector3 newPos = new Vector3(pos, goalPosition.position.y, 0);
        goalPosition.position = newPos;
        collidedWithGoal = false;
        Debug.Log("Set position of goal value: " + pos);
    }
    
    public void SetMovement(Movement movementType)
    {
        switch (movementType)
        {
            case Movement.Random:
                goalPosition = this.gameObject.transform;
                break;
            case Movement.PingPong:
                PingPong();
                break;
            case Movement.Static:
                goalPosition = this.gameObject.transform;
                break;
            default: throw new ArgumentException("Movement enum set incorrectly");
        }
    }
}
