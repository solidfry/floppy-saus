using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    public Inputs controls;

    public GameObject dropperPrefab;
    public GameObject dropper;
    [SerializeField]
    bool dropperVisible = false;
    [SerializeField]
    bool hasSpawned = false;
    [SerializeField]
    private int speed = 20;
    Vector2 moveInput;
    private static bool controlsActive = false;

    [SerializeField]
    private bool showControlsActive = false;

    Vector2 dropperStartLocation;
    Rigidbody2D rb;
    Transform tr;

    private void Awake()
    {
        controls = new Inputs();
        controls.PlayerControls.Drop.performed += context => Drop();
        controls.PlayerControls.Movement.performed += context => Aim();
        if (dropper != null)
        {
            rb = dropper.GetComponent<Rigidbody2D>();
            tr = dropper.GetComponent<Transform>();
            dropperStartLocation = tr.gameObject.transform.parent.position;
            rb.simulated = true;
            rb.isKinematic = true;
        }
        else
        {
            Debug.Log("Player RB is null");
        }
    }

    private void Start()
    {
        if (dropper == null)
            AssignPlayerObjects();
    }

    private void FixedUpdate()
    {
        if (controlsActive)
        {
            moveInput = controls.PlayerControls.Movement.ReadValue<Vector2>();
            moveInput.y = 0f;
            if (rb == null)
            {
                AssignPlayerObjects();
                rb.velocity = moveInput * speed;
            }
            else
            {
                rb.velocity = moveInput * speed;
            }
        }
    }

    private void Update()
    {
        showControlsActive = controlsActive;
        IsVisible();
    }

    private void OnEnable()
    {
        controls.Enable();

        GameEvents.OnPlayerScoredEvent += DisableControls;

        GameEvents.OnPlayerScoredEvent += Respawn;

        GameEvents.OnPreGameEvent += DisableControls;

        GameEvents.OnPreRoundEvent += EnableControls;

        GameEvents.OnPreRoundEvent += EnableHasSpawned;

        GameEvents.OnPlayingEvent += DisableControls;

        GameEvents.OnOutOfBoundsEvent += Respawn;

        GameEvents.OnOutOfBoundsEvent += EnableControls;

        GameEvents.OnGameOverEvent += DisableControls;

        GameEvents.OnGameOverEvent += DisableHasSpawned;
    }

    private void OnDisable()
    {
        controls.Disable();

        GameEvents.OnPlayerScoredEvent -= DisableControls;

        GameEvents.OnPlayerScoredEvent -= Respawn;

        GameEvents.OnPreGameEvent -= DisableControls;

        GameEvents.OnPreRoundEvent -= EnableControls;

        GameEvents.OnPreRoundEvent -= EnableHasSpawned;

        GameEvents.OnPlayingEvent -= DisableControls;

        GameEvents.OnOutOfBoundsEvent -= Respawn;

        GameEvents.OnOutOfBoundsEvent -= EnableControls;

        GameEvents.OnGameOverEvent -= DisableControls;

        GameEvents.OnGameOverEvent -= DisableHasSpawned;
    }

    void Drop()
    {
        if (controlsActive)
        {
            Debug.Log("Dropped");
            GameEvents.OnPlayingEvent?.Invoke();
            rb.isKinematic = false;
            DisableControls();
        }
    }

    void Aim()
    {
        if (controlsActive)
            Debug.Log("Aimed");
    }

    void Respawn()
    {
        if (dropper != null)
        {
            Destroy(dropper.transform.parent.gameObject);
            GameObject newDropper = Instantiate(dropperPrefab, dropperStartLocation, Quaternion.Euler(0, 0, -90));
            AssignPlayerObjects();
            ResetPosition();
        }
    }

    void ResetPosition()
    {
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
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

    void AssignPlayerObjects()
    {
        if (dropper == null)
        {
            dropper = GameObject.FindGameObjectWithTag("Player");
            dropper.GetComponent<Rigidbody2D>().isKinematic = true;
            rb = dropper.GetComponent<Rigidbody2D>();
            tr = dropper.GetComponent<Transform>();
        }
    }

    void EnableHasSpawned()
    {
        hasSpawned = true;
    }

    void DisableHasSpawned()
    {
        hasSpawned = false;
    }

    private void IsVisible()
    {
        if (dropper != null && dropper.GetComponent<Renderer>().isVisible)
        {
            dropperVisible = true;
            // Debug.Log("Dropper is visible");
        }
        else
        {
            dropperVisible = false;
            // Debug.Log("Dropper is invisible");
        }

        if (!dropperVisible && hasSpawned)
        {
            GameEvents.OnOutOfBoundsEvent?.Invoke();
        }
    }

}
