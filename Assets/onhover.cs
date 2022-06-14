using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onhover : MonoBehaviour
{
    public Sprite stadard;
    public Sprite hover;

    private void OnMouseEnter()
    {
        this.GetComponent<Image>().sprite = hover;
    }

    private void OnMouseExit()
    {
        this.GetComponent<Image>().sprite = stadard;
    }
}
