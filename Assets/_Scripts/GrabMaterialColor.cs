using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabMaterialColor : MonoBehaviour
{
    Light lamp;
    Color mat;
    // Start is called before the first frame update
    void Start()
    {
        lamp = GetComponent<Light>();
        mat = transform.parent.GetComponent<MeshRenderer>().material.GetColor("_EmissionColor");
    }

    // Update is called once per frame
    void Update()
    {
        lamp = GetComponent<Light>();
        mat = transform.parent.GetComponent<MeshRenderer>().material.GetColor("_EmissionColor");
        lamp.color = mat;
    }
}
