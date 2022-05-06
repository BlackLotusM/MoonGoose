using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletHandler : MonoBehaviour
{
    public bool pickedUp = false;
    public GameObject canvasMap;
    public DialogManager dm;
    public DialogTesting closeTablet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M) && pickedUp)
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
