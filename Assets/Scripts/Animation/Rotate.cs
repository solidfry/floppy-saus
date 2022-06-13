using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script rotates stuff
public class Rotate : MonoBehaviour
{
    [SerializeField]
    int rotateSpeed = 5;

    [SerializeField]
    int maxRotateSpeed = 10;

    public enum Direction
    {
        Forward, Backward, Random
    }

    public enum Speed
    {
        Static, Random
    }

    [SerializeField]
    Direction rotationDirection = Direction.Random;

    [SerializeField]
    Speed speedType = Speed.Static;

    System.Random rand;
    float randomValue;

    private void Start()
    {
        rand = new System.Random(GetInstanceID());
        randomValue = rand.Next(0, 101);

        if (speedType == Speed.Random)
        {
            int randomSpeed = rand.Next(rotateSpeed, maxRotateSpeed);
            rotateSpeed = randomSpeed;
        }
    }
    private void FixedUpdate()
    {
        DoRotate(rotationDirection, randomValue);
    }

    void DoRotate(Direction direction, float randomValue)
    {
        switch (direction)
        {
            case Direction.Forward:
                transform.Rotate(Vector3.forward, Time.deltaTime * rotateSpeed, Space.World);
                break;
            case Direction.Backward:
                transform.Rotate(Vector3.back, Time.deltaTime * rotateSpeed, Space.World);
                break;
            case Direction.Random:
                // Debug.Log("the random direction is " + randomValue);
                Vector3 value = randomValue <= 50 ? Vector3.forward : Vector3.back;
                transform.Rotate(value, Time.deltaTime * rotateSpeed, Space.World);
                break;
        }
    }
}