using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineWhenClose : MonoBehaviour
{
    Outline outline;
    public float distance = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(Camera.main.transform.position, this.transform.position) < distance)
        {
            outline.enabled = true;
        }else if(outline.enabled == true)
        {
            outline.enabled = false;
        }
    }
}
