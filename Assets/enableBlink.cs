using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableBlink : MonoBehaviour
{
    public Outline outline;
    public bool isActive;

    float duration = 1; // In seconds
    float maxValue = 3;
    public bool started;
    public bool blink;

    public IEnumerator BlinkObject()
    {
        while (isActive)
        {
            if (blink)
            {
                outline.OutlineWidth = 5;
                yield return new WaitForSeconds(1f);
                outline.OutlineWidth = 0;
                yield return new WaitForSeconds(1f);
            }
            else
            {
                float elapsedTime = Time.time; // startTime can be equal to 0
                float output = elapsedTime * Mathf.PI / duration;
                output = Mathf.Cos(output + Mathf.PI) + 1;
                output *= maxValue / 2;

                outline.OutlineWidth = output;
                yield return null;
            }
        }
    }

    private void Update()
    {
        if(!started && isActive)
        {
            started = true;
            StartCoroutine("BlinkObject");
        }
    }

    public void StartBlink()
    {
        outline.enabled = true;
        isActive = true;
        StartCoroutine("BlinkObject");
    }

    //Add system
    private void OnMouseDown()
    {
        outline.gameObject.SetActive(false);
    }
}
