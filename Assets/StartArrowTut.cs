using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartArrowTut : MonoBehaviour
{
    public Image[] disabledArrows;
    public Image enabledArrow;
    public bool isActive;
    float maxValue = 1f;
    float duration = 1f;

    private void Start()
    {
        enabledArrow.GetComponent<Button>().onClick.AddListener(disableBlink);
    }

    private void disableBlink()
    {
        isActive = false;
        Color temp = enabledArrow.color;
        temp.a = 1;
        enabledArrow.color = temp;
    }

    public void StartBlink()
    {
        foreach (var item in disabledArrows)
        {
            item.gameObject.SetActive(false);
        }
        isActive = true;
        StartCoroutine("BlinkObject");
    }

    public IEnumerator BlinkObject()
    {
        while (isActive)
        {
            float elapsedTime = Time.time; // startTime can be equal to 0
            float output = elapsedTime * Mathf.PI / duration;
            output = Mathf.Cos(output + Mathf.PI) + 1;
            output *= maxValue / 2;

            Color temp = enabledArrow.color;
            temp.a = output;
            enabledArrow.color = temp;

            yield return null;
        }
    }
}
