using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable1 : MonoBehaviour
{
    private void OnMouseEnter()
    {
        transform.localScale += new Vector3(0.1F, 0, 0);
    }
    private void OnMouseExit()
    {
        transform.localScale -= new Vector3(0.1F, 0, 0);
    }
}
