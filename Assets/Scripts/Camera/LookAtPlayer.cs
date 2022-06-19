using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class LookAtPlayer : MonoBehaviour
{
    CinemachineVirtualCamera virtualCam;
    Transform focusObjectTransform;
    private void Awake()
    {
        FindPlayer();
        virtualCam = gameObject.GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (focusObjectTransform != null)
            SetVirtualCameraToPlayer();
        else
            FindPlayer(); SetVirtualCameraToPlayer();

    }

    void FindPlayer()
    {
        focusObjectTransform = GameObject.FindWithTag("Player").transform;
    }

    void SetVirtualCameraToPlayer()
    {
        virtualCam.Follow = focusObjectTransform;
    }
}
