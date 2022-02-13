using System;
using UnityEngine;

public class ScreenTransition : MonoBehaviour
{
    public Vector2 cameraTransitionTo;
    private Camera mainCam;

    private void Start()
    {
        mainCam = Camera.main;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Player")) return;
        Transform mainCamTransform = mainCam.transform;
        mainCamTransform.position =
            new Vector3(cameraTransitionTo.x, cameraTransitionTo.y, mainCamTransform.position.z);
    }
}
