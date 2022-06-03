using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    public Inputs controls;
    public GameObject dropper;
    [SerializeField]
    private int speed = 20;
    Vector2 moveInput;
    private static bool controlsActive = false;

    [SerializeField]
    private bool showControlsActive;

    Vector2 dropperStartLocation;
    Rigidbody2D rb;
    Transform tr;

    private void Awake()
    {
        controls = new Inputs();
        controls.PlayerControls.Drop.performed += context => Drop();
        controls.PlayerControls.Movement.performed += context => Aim();

        rb = dropper.GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.Log("Player RB is null");
        }

        rb.simulated = false;
        tr = dropper.GetComponent<Transform>();
        dropperStartLocation = tr.position;
    }

    private void FixedUpdate()
    {
        if (controlsActive)
        {
            moveInput = controls.PlayerControls.Movement.ReadValue<Vector2>();
            moveInput.y = 0f;
            rb.velocity = moveInput * speed;
        }
    }

    private void Update()
    {
        showControlsActive = controlsActive;
    }

    private void OnEnable()
    {
        controls.Enable();
        GameEvents.OnPlayerScoredEvent += PlayerScored;
        GameEvents.OnPreRoundEvent += ResetPosition;
        GameEvents.OnPreRoundEvent += EnableControls;
        GameEvents.OnPreGameEvent += DisableControls;
        GameEvents.OnPlayingEvent += DisableControls;
    }

    private void OnDisable()
    {
        controls.Disable();
        GameEvents.OnPlayerScoredEvent -= PlayerScored;
        GameEvents.OnPreRoundEvent -= ResetPosition;
        GameEvents.OnPreRoundEvent -= EnableControls;
        GameEvents.OnPreGameEvent -= DisableControls;
        GameEvents.OnPlayingEvent -= DisableControls;
    }

    void Drop()
    {
        if (dropper != null && controlsActive)
        {
            Debug.Log("Dropped");
            GameEvents.OnPlayingEvent?.Invoke();
            rb.isKinematic = false;

        }
    }

    void Aim()
    {
        if (controlsActive)
            Debug.Log("Aimed");
    }

    void PlayerScored()
    {
        DisableControls();
    }

    void ResetPosition()
    {
        rb.velocity = Vector2.zero;
        rb.simulated = true;
        rb.isKinematic = true;
        tr.position = dropperStartLocation;
        Debug.Log("Position should be reset");
    }

    void DisableControls()
    {
        controlsActive = false;
    }

    void EnableControls()
    {
        controlsActive = true;
    }
}
