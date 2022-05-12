using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogOnMouseDown : MonoBehaviour
{
    public DialogTesting dialog;
    public bool disabelCollWhenDone;

    private void OnMouseDown()
    {
        dialog.SetAndStart();
        if (disabelCollWhenDone)
            GetComponent<Collider>().enabled = false;
    }
}
