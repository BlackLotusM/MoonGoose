using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Camera cam;
    private void Start()
    {
        cam = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cam.transform);
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
    }
}
