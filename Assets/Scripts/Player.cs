using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Inputs controls;
    private void Awake()
    {
        controls.PlayerControls.Movement.performed += _ => Drop();
    }
    
    void Drop() 
    {
        Debug.Log("Dropped");
    }

    void OnEnable()
    {
        controls.Enable();
    }
    
    void OnDisable()
    {
        controls.Disable();
    }

}
