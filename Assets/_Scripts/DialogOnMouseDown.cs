using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogOnMouseDown : MonoBehaviour
{
    public DialogTesting dialog;
    public bool disabelCollWhenDone;
    private bool active = false;

    public void activateScreen()
    {
        active = true;
    }
    private void OnMouseDown()
    {
        if (!active)
        {

        }
        else
        {
            dialog.SetAndStart();
            if (disabelCollWhenDone)
                GetComponent<Collider>().enabled = false;
        }
    }
}
