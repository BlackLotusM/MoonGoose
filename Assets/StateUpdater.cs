using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateUpdater : MonoBehaviour
{
    public Sprite standard;
    public Sprite selected;
    public bool inActive;
    public Image target;

    private void Start()
    {
        target = GetComponent<Image>();
        target.alphaHitTestMinimumThreshold = 0.1f;
    }

    public void Select()
    {
        if (!inActive)
        {
            target.sprite = selected;
        }
    }

    public void DeSelect()
    {
        target.sprite = standard;
    }

    private void Update()
    {
        if (inActive)
        {
            Color temp = target.color;
            temp.a = 0.3f;
            target.color = temp;
        }
        else
        {
            Color temp = target.color;
            temp.a = 1;
            target.color = temp;
        }
    }
}
