using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabletNotification : MonoBehaviour
{
    [Header("TabletButton")]
    public Image btnTarget;
    public Sprite notifi;
    public Sprite standard;
    public float waitTime;
    private IEnumerator cor;
    bool running;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            BtnState(true);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            BtnState(false);
        }
    }
    public void BtnState(bool state)
    {
        
        if (state && !running)
        {
            running = true;
            cor = BlinkButton();
            StartCoroutine(cor);
        }
        else if(!state)
        {
            StopCoroutine(cor);
            running = false;
            btnTarget.sprite = standard;
        }
    }

    private IEnumerator BlinkButton()
    {
        while (running)
        {
            yield return new WaitForSeconds(waitTime);
            btnTarget.sprite = notifi;
            yield return new WaitForSeconds(waitTime);
            btnTarget.sprite = standard;
        }
    }

    bool hasRun = false;
    public void StartOnce()
    {
        if (!hasRun)
        {
            hasRun = true;
            FindObjectOfType<TabletHandler>().PickedUpDialog();
        }
    }
}
