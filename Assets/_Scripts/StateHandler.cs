using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateHandler : MonoBehaviour
{
    public Sprite active, inactive;
    // Start is called before the first frame update

    public void setState(bool activeBtn)
    {
        if (activeBtn)
            GetComponent<Image>().sprite = active;
        else
            GetComponent<Image>().sprite = inactive;
    }
}
