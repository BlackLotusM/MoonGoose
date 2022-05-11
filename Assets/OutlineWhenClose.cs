using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineWhenClose : MonoBehaviour
{
    Outline outline;
    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(Camera.main.transform.position, this.transform.position) < 2.5f)
        {
            outline.enabled = true;
        }else if(outline.enabled == true)
        {
            outline.enabled = false;
        }
    }
}
