using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class btnQuestion : MonoBehaviour
{
    public UnityEvent yourCustomEvent;

    private void OnMouseDown()
    {
        yourCustomEvent.Invoke();
    }
}
