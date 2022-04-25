using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabletMenu : MonoBehaviour
{
    public GameObject lastCheck;
    public Image[] btnImages;
    public GameObject[] targets;

    private void Start()
    {
        for (int i = 0; i < btnImages.Length; i++)
        {
            if (targets[i].activeSelf)
            {
                var col = btnImages[i].color;
                col.a = 1;
                btnImages[i].color = col;
            }
            else
            {
                var col = btnImages[i].color;
                col.a = 0;
                btnImages[i].color = col;
            }
        }
    }

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

    public void UpdateBtn()
    {
        for (int i = 0; i < btnImages.Length; i++)
        {
            if (targets[i].activeSelf)
            {
                var col = btnImages[i].color;
                col.a = 1;
                btnImages[i].color = col;
            }
            else
            {
                var col = btnImages[i].color;
                col.a = 0;
                btnImages[i].color = col;
            }
        }
    }
}
