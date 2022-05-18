using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnmouseDownAction : MonoBehaviour
{

    public UnityEvent eventje;
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        eventje.Invoke();
    }
}
