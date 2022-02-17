using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable1 : MonoBehaviour
{
    public PlayerManager pm;
    public Transform camPos;
    public bool active;
    private void OnMouseEnter()
    {
        transform.localScale += new Vector3(0.1F, 0, 0);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && pm.cameraPositioner.done)
        {
            pm.cameraPositioner.atObject = false;
            pm.cameraPositioner.done = false;
            StartCoroutine(pm.cameraPositioner.MoveCamTo());
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && pm.cameraPositioner.done && !active)
        {
            pm.cameraPositioner.atObject = true;
            pm.cameraPositioner.done = false;
            StartCoroutine(pm.cameraPositioner.MoveCamToObject(camPos));
        }
    }

    private void OnMouseExit()
    {
        transform.localScale -= new Vector3(0.1F, 0, 0);
    }
}
