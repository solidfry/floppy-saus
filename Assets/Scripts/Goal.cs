using System;
using UnityEngine;

using Random = UnityEngine.Random;

public class Goal : MonoBehaviour
{
    [SerializeField]
    private Movement movementType;
    bool collidedWithGoal = false;
    Transform goalPosition;

    [Header("Movement Settings")] 
    [SerializeField]
    private float speed = 5f;
    [Header("Movement Waypoints")]
    [SerializeField] private Transform[] waypoints;
    [ReadOnly]
    [SerializeField]
    private int listIndex;
    
    private void Awake()
    {
        goalPosition = this.gameObject.transform;
        Debug.Log("The goal position:" + goalPosition.position);
    }

    private void Update()
    {
        DoMovement(movementType);
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
        if (Vector3.Distance(goalPosition.position, waypoints[listIndex].position) < 0.1f)
        {
            listIndex++;
        }

        if (listIndex >= waypoints.Length)
        {
            listIndex = 0;
        }
        goalPosition.position = Vector3.MoveTowards(goalPosition.position, waypoints[listIndex].position,
            Time.deltaTime * speed);
    }

    void SetPosition()
    {
        float pos = Random.Range(Boundaries.hBounds.x, Boundaries.hBounds.y);
        Vector3 newPos = new Vector3(pos, goalPosition.position.y, 0);
        goalPosition.position = newPos;
        collidedWithGoal = false;
        Debug.Log("Set position of goal value: " + pos);
    }

    private void OnDrawGizmos()
    {
        GenerateWayPoints();
    }

    void GenerateWayPoints()
    {
        float colourShift = 0f; 
        foreach (Transform wayPoint in waypoints)
        {
            colourShift += .1f;
            Gizmos.color = Color.HSVToRGB(colourShift, 1, 1);
            Gizmos.DrawWireSphere(wayPoint.position,1f);
        }
    }
    
    private void DoMovement(Movement movementType)
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
