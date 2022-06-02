using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    public Inputs controls;
    public GameObject dropper;
    private bool isDropped = false;

    private void Awake()
    {
        controls = new Inputs();
        controls.PlayerControls.Drop.performed += context => Drop();
        controls.PlayerControls.Movement.performed += context => Aim();
    }

    void Drop()
    {
        Debug.Log("Dropped");
        if (dropper != null && isDropped == false)
            dropper.GetComponent<Rigidbody2D>().simulated = true;
    }

    void Aim()
    {
        if (isDropped == false)
            Debug.Log("Aimed");
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

}
