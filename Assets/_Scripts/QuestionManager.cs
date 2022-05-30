using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    // Start is called before the first frame update
    public HoloActivate planetVraag;
    public StroomManager stroomVraag;
    public Vraag3 meerkeuzeVraag;
    int i = 0;
    public bool toetsActive;
    private void Start()
    {
        planetVraag = FindObjectOfType<HoloActivate>();
        stroomVraag = FindObjectOfType<StroomManager>();
        meerkeuzeVraag = FindObjectOfType<Vraag3>();
    }
    private void Update()
    {
        if(planetVraag.opdrachtCheck && stroomVraag.opdrachtCheck && meerkeuzeVraag.opdrachtCheck && i == 0)
        {
            i++;
            Debug.Log("Toets Active");
            toetsActive = true;
        }
    }

    public void EndGame()
    {
        FindObjectOfType<FadeToBlack>().StartCoroutine(FindObjectOfType<FadeToBlack>().FadeBlack(true, 2));
    }
}
