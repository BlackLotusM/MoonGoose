using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Moveplanet : MonoBehaviour
{
    [Header("PlanetInfo")]
    public string naam;
    public double zwaartekracht = 0;
    public double correcteAntwoord;
    [SerializeField]
    private Transform targetActive;
    [SerializeField]
    private Transform targetInactive;

    [Header("PlanetTextMap")]
    public GameObject mapInfoCanvas;
    public TextMeshProUGUI txtNaamMap;
    public TextMeshProUGUI txtZwaarteKrachtMap;

    [Header("PlanetMapDone")]
    public GameObject mapInfoCanvasDone;
    public TextMeshProUGUI txtNaamMapDone;
    public TextMeshProUGUI txtZwaarteKrachtMapDone;
    public TextMeshProUGUI txtAnswerMapDone;

    [Header("PlanetTextQuestion")]
    public TextMeshProUGUI txtNaam;
    public TextMeshProUGUI txtZwaarteKracht;
    public bool isAnswer;

    [Header("QuestioCanvas")]
    public GameObject questionCanvas;
    public bool questionDone;

    public bool planetActive = false;

    private Vector3 startPosition;
    private Vector3 startScale;
    private Vector3 initialScale;

    public Transform targetCam;
    public Transform parent;

    private IEnumerator co1;
    public GameObject hover1;
    public GameObject hover2;
    private float timeElapsed;
    [SerializeField]
    private float lerpDuration = 3;

    public CameraManager camMan;

    public HoloActivate holoManager;

    public Camera cam;

    public bool navDisabled;
    public GameObject navi;
    public GameObject escape;

    private void Start()
    {
        holoManager = FindObjectOfType<HoloActivate>();
        initialScale = transform.localScale;
        mapInfoCanvasDone.SetActive(false);
        SetText();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!navDisabled)
                navi.SetActive(true);
            escape.SetActive(false);
            camMan.moveToIndex(camMan.currentIndex);
            QuestionCanvasState(false);
        }
    }

    public void Escape()
    {
        if (!navDisabled)
            navi.SetActive(true);
        escape.SetActive(false);
        camMan.moveToIndex(camMan.currentIndex);
        QuestionCanvasState(false);
    }

    private void OnMouseEnter()
    {
        hover1.SetActive(true);
        hover2.SetActive(true);
        transform.localScale += new Vector3(0.01F, 0.01F, 0.01F);
    }
    private void OnMouseExit()
    {
        hover1.SetActive(false);
        hover2.SetActive(false);
        transform.localScale -= new Vector3(0.01F, 0.01F, 0.01F);
    }

    private void OnMouseDown()
    {
        if (!navDisabled)
            navi.SetActive(false);
        escape.SetActive(true);
        QuestionCanvasState(true);
        cam.transform.position = targetCam.position;
        cam.transform.rotation = targetCam.rotation;
    }

    private void SetText()
    {
        txtNaamMap.text = naam;
        txtNaam.text = naam;
        txtZwaarteKracht.text = zwaartekracht + "m/s2";
        txtZwaarteKrachtMap.text = zwaartekracht + "m/s2";
        correcteAntwoord = holoManager.gewicht * zwaartekracht * holoManager.meters;
        transform.localScale = new Vector3(0, 0, 0);
        questionDone = false;
        QuestionCanvasState(false);
    }

    public void SetNewValues(double newZwaarte)
    {
        zwaartekracht = newZwaarte;
        SetText();
    }

    public void Done(string answer)
    {
        txtNaamMapDone.text = naam;
        txtZwaarteKrachtMapDone.text = zwaartekracht.ToString();
        txtAnswerMapDone.text = answer;
        questionDone = true;

        string temp = answer.Remove(0, 14);
        temp = temp.Remove(temp.Length - 1, 1);
        double filled = double.Parse(temp);

        double difference = Math.Abs(correcteAntwoord * .00001);

        Debug.Log(filled + " + " + correcteAntwoord);
        
        if ((decimal)correcteAntwoord == (decimal)filled)
        {
            Debug.Log("Antwoord is correct");
        }
        else
        {
            Debug.Log("Antwoord opgeslagen maar incorrect");
        }
    }
    public void QuestionCanvasState(bool state)
    {
        questionCanvas.SetActive(state);
        if (questionDone)
        {
            mapInfoCanvas.SetActive(false);
            mapInfoCanvasDone.SetActive(!state);
        }
        else
        {
            mapInfoCanvas.SetActive(!state);
        }
        
    }

    /// <summary>
    /// Changes position and scale of planet based on parameters
    /// </summary>
    IEnumerator MoveObject(Transform target, Vector3 targetScale, float duration = 0)
    {
        //Resets time elapsed on start
        timeElapsed = 0;

        while (timeElapsed < lerpDuration)
        {
            //Calculates time based on duration
            float time = timeElapsed / (lerpDuration - duration);
            parent.position = Vector3.Lerp(startPosition, target.position, time);
            transform.localScale = Vector3.Lerp(startScale, targetScale, time);

            timeElapsed += Time.deltaTime;

            yield return null;
        }
        parent.position = target.position;
    }

    public void updateState()
    {
        //Set start settings for ieunumerator
        startScale = transform.localScale;
        startPosition = parent.position;

        //toggle state
        planetActive = !planetActive;

        //if youstop mid animation this makes sure it reducts the time if animation was done it sets the time at 0
        float timeBetween = timeElapsed;
        if(timeElapsed >= lerpDuration)
        {
            timeBetween = 0;
        }

        //Checks of coroutine was still running
        if (co1 != null)
            StopCoroutine(co1);
            
        //Sets correct settings based on state
        if (planetActive)
            co1 = MoveObject(targetActive, initialScale, timeBetween);            
        else
            co1 = MoveObject(targetInactive, new Vector3(0,0,0), timeBetween);

        //Starts coroutine
        StartCoroutine(co1);
    }
}
