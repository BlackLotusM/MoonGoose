using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletHandler : MonoBehaviour
{
    public bool pickedUp = false;
    public GameObject canvasMap;
    public DialogManager dm;
    public DialogTesting closeTablet;

    public void TabletState()
    {
        if (pickedUp)
        {
            canvasMap.SetActive(!canvasMap.activeSelf);
        }
    }

    public void PickUpTablet()
    {
        pickedUp = true;
        //TO-DO Start Tablet Interaction

        //For now start dialogue after
        dm.currentDialog = closeTablet;
        dm.startSentence();
    }
}
