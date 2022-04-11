using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletMenu : MonoBehaviour
{
    public GameObject lastCheck;
    public void QuiteGame(bool mainMenu)
    {
        
        //Implement save behaviour
        if(mainMenu)
        Application.Quit();
    }

    public void OpenLastCheck()
    {
        lastCheck.SetActive(true);
    }
}
