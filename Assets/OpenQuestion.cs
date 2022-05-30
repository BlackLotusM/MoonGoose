using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenQuestion : MonoBehaviour
{
    public bool state;
    public Animator anim;
    IEnumerator current;
    public GameObject vraag;
    public bool active;
    public GameObject theBtn;

    private void Start()
    {
        anim.SetFloat("Blend", 0);
    }
    public void SetActive()
    {
        active = true;
    }

    public void EnableBTN(bool state)
    {
        if (active)
        {
            theBtn.SetActive(state);
        }
        else
        {
            ForceClose();
        }
    }

    public void ChangeQuestion()
    {

        Debug.Log("run?");
        if (!active)
            return;
        gameObject.SetActive(true);
        state = !state;
        done = false;
        if(current != null)
            StopCoroutine(current);
        current = changeVal(state);
        if (current != null)
            StartCoroutine(current);
    }

    bool done = false;
    public float val;

    public void CloseBtn(bool state)
    {
        done = false;
        if (current != null)
            StopCoroutine(current);
        current = changeVal(state);
        if (current != null)
            StartCoroutine(current);
    }
    public IEnumerator changeVal(bool state)
    {
        val = anim.GetFloat("Blend");
        while (!done)
        {
            if (state)
            {
                if (anim.GetFloat("Blend") < 1)
                {
                    anim.SetFloat("Blend", val += 3f * Time.deltaTime);
                }
                else
                {
                    vraag.SetActive(true);
                    done = true;
                }
            }
            else
            {
                vraag.SetActive(false);
                if (anim.GetFloat("Blend") > 0)
                {
                    anim.SetFloat("Blend", val -= 3f * Time.deltaTime);
                }
                else
                {
                    done = true;
                }
            }
            yield return null;
        }
    }
    public void ForceClose()
    {
        if (current != null)
            StopCoroutine(current);
        state = false;
        done = false;
        anim.SetFloat("Blend", 0);
        theBtn.gameObject.SetActive(false);
        vraag.SetActive(false);
    }
}
