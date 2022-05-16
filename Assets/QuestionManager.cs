using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    // Start is called before the first frame update
    public HoloActivate planetVraag;
    public StroomManager stroomVraag;
    public Vraag3 meerkeuzeVraag;

    private void Start()
    {
        planetVraag = FindObjectOfType<HoloActivate>();
        stroomVraag = FindObjectOfType<StroomManager>();
        meerkeuzeVraag = FindObjectOfType<Vraag3>();
    }
    private void Update()
    {
        if(planetVraag.opdrachtCheck && stroomVraag.opdrachtCheck && meerkeuzeVraag.opdrachtCheck)
        {
            Debug.Log("Toets Active");
        }
    }
}
