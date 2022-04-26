using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI year;
    public bool startFirstBlack;
    public bool startSecondBlack;
    public bool showYear;
    private IEnumerator running1;
    private IEnumerator running2;
    public DialogManager DM;

    public GameObject manager;
    public DialogTesting introDialog;

    private void Start()
    {
        DM = FindObjectOfType<DialogManager>();
    }
    private void Update()
    {
        if (showYear && running1 == null)
        {
            showYear = false;
            running1 = FadeBlackText(true, 0.6f);
            StartCoroutine(running1);
        }

        if (startFirstBlack && running2 == null)
        {
            StopCoroutine(running1);
            running1 = FadeBlackText(false, 0.8f);
            StartCoroutine(running1);
            running2 = FadeBlack(true, 0.3f);
            StartCoroutine(running2);
        }
    }
    public void startFade(bool fadeToBlack, float speed)
    {
        StartCoroutine(FadeBlack(fadeToBlack, speed));
    }

    public IEnumerator FadeBlack(bool fadeToBlack, float speed)
    {
        Color objectColor1 = image.color;
        float fadeAmount1;

        if (fadeToBlack)
        {
            while(image.color.a < 1)
            {
                fadeAmount1 = image.color.a + (speed * Time.deltaTime);
                objectColor1 = new Color(image.color.r, image.color.g, image.color.b, fadeAmount1);
                image.color = objectColor1;
                if (image.color.a >= 1 && manager.activeSelf == false)
                {
                    GetComponent<Animator>().enabled = false;
                    manager.SetActive(true);
                    StopAllCoroutines();
                    StartCoroutine(FadeBlack(false, 1));
                    StartCoroutine(StartIntro(1.3f));
                    //startFade(false, 0.3f);
                }
                yield return null; 
            }
        }
        else
        {
            while (image.color.a > 0)
            {
                fadeAmount1 = image.color.a - (speed * Time.deltaTime);
                objectColor1 = new Color(image.color.r, image.color.g, image.color.b, fadeAmount1);
                image.color = objectColor1;
                yield return null;
            }
        }
    }

    public IEnumerator StartIntro(float second)
    {
        yield return new WaitForSeconds(second);
        DM.currentDialog = introDialog;
        DM.startSentence();

    }

    public IEnumerator FadeBlackText(bool fadeToBlack, float speed)
    {
        Color objectColor2 = year.color;
        float fadeAmount2 = 0;

        if (fadeToBlack)
        {
            while (year.color.a < 1)
            {
                fadeAmount2 = year.color.a + (speed * Time.deltaTime);
                objectColor2 = new Color(year.color.r, year.color.g, year.color.b, fadeAmount2);
                year.color = objectColor2;
                yield return null;
            }
        }
        else
        {
            while (year.color.a > 0)
            {
                fadeAmount2 = year.color.a - (speed * Time.deltaTime);
                objectColor2 = new Color(year.color.r, year.color.g, year.color.b, fadeAmount2);
                year.color = objectColor2;
                yield return null;
            }
        }
    }
}
