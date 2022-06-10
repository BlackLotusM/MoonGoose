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
    int i = 0;
    public AudioSource source;

    public void BtnState(bool state)
    {
        if(i == 0)
        {
            i++;
            GetComponent<Animator>().SetTrigger("PlayAnim");
        }
        
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
        source.Play();
        while (running)
        {
            yield return new WaitForSeconds(waitTime);
            btnTarget.sprite = notifi;
            yield return new WaitForSeconds(waitTime);
            btnTarget.sprite = standard;
        }
    }

    bool hasRun = false;
    int it = 0;
    public void StartOnce()
    {
        it++;
        if (!hasRun && it > 1)
        {
            hasRun = true;
            FindObjectOfType<TabletHandler>().PickedUpDialog();
        }
    }
}
