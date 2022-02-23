using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable1 : MonoBehaviour
{
    public CameraPositioner cameraManager;
    public Transform camPos;
    public bool active;
    private void OnMouseEnter()
    {
        transform.localScale += new Vector3(0.1F, 0, 0);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && cameraManager.done)
        {
            cameraManager.atObject = false;
            cameraManager.done = false;
            StartCoroutine(cameraManager.MoveCamToObject(cameraManager.currentWaypoint.waypointTransform));
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && cameraManager.done && !active)
        {
            cameraManager.atObject = true;
            cameraManager.done = false;
            StartCoroutine(cameraManager.MoveCamToObject(camPos));
        }
    }

    private void OnMouseExit()
    {
        transform.localScale -= new Vector3(0.1F, 0, 0);
    }
}
