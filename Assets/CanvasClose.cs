using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasClose : MonoBehaviour
{
    CanvasGroup group;
    public float range = 4f;
    // Start is called before the first frame update
    void Start()
    {
        group = GetComponent<CanvasGroup>();
        group.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(Camera.main.transform.position, this.gameObject.transform.position) < range)
        {
            if (group.alpha < 1)
            {
                group.alpha += 0.02f;
            }
        }
        else
        {
            if (group.alpha > 0)
            {
                group.alpha -= 0.02f;
            }
        }
    }
}
