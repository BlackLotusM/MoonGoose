using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HoloActivate : MonoBehaviour
{
    public bool isActive;
    public bool enableClick = false;

    public Moveplanet[] planets;
    public ParticleSystem particle;
    public ParticleSystem particle2;
    
    public int activeButton = -1;
    public DialogTesting correct;
    public DialogTesting inCorrect;
    public DialogManager manager;
    public GameObject[] buttons;

    public DialogTesting uitlegDialog;

    public double gewicht;
    public double meters;
    public double correcteAntwoord;

    public bool opdrachtCheck;

    public CameraManager cam;
    public int wayPointIndex;
    private QuestionShow showQuestion;

    public bool toetsActive;
    public GameObject questLeer;
    public GameObject questToets;
    public GameObject parent;

    public void SetAcitve()
    {
        isActive = true;
    }

    private void Start()
    {
        showQuestion = FindObjectOfType<QuestionShow>();
        manager = FindObjectOfType<DialogManager>();
        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }

        ResetPlanets();
    }
    public void EnableClick()
    {
        enableClick = true;
    }

    private void OnMouseDown()
    {
        if (!isActive || !enableClick)
            return;
        uitlegDialog.SetAndStart();
        manager.activateObject();
        showQuestion.StateText(true);

        foreach (Moveplanet planet in planets)
        {
            planet.updateState();
        }
    }
    private void Update()
    {
        if(cam.currentIndex != wayPointIndex)
        {
            foreach (Moveplanet planet in planets)
            {
                if(planet.planetActive == true)
                    planet.updateState();
            }
            showQuestion.StateText(false);
        }

        if (planets[0].planetActive)
        {
            if (particle.gameObject.transform.localScale.x < 1f)
            {
                var vec = particle.gameObject.transform.localScale;
                vec.x += 1.36f * Time.deltaTime;
                vec.z = vec.x;
                vec.y = vec.x;
                particle.gameObject.transform.localScale = vec;
                particle2.gameObject.transform.localScale = vec;
            }
        }
        else
        {
            if (particle.gameObject.transform.localScale.x > 0)
            {
                var vec = particle.gameObject.transform.localScale;
                vec.x -= 1.36f * Time.deltaTime;
                vec.z = vec.x;
                vec.y = vec.x;
                particle.gameObject.transform.localScale = vec;
                particle2.gameObject.transform.localScale = vec;
            }
        }

        if (planets.All(x => x.questionDone == true))
        {
            foreach (GameObject button in buttons)
            {
                button.SetActive(true);
            }
        }

        for (int i = 0; i < buttons.Length; i++)
        {
            Image img = buttons[i].GetComponent<Image>();
            if (i == activeButton)
            {
                var col = img.color;
                col.a = 1;
                img.color = col;
            }
            else
            {
                var col = img.color;
                col.a = 0.3f;
                img.color = col;
            }
        }
    }

    public void ResetPlanets()
    {

        gewicht = Math.Round(UnityEngine.Random.Range(2f, 12.5f), 2);
        gewicht = double.Parse(String.Format("{0:0.0}", gewicht));
        meters = UnityEngine.Random.Range(1, 8);
        manager.gewicht = gewicht;
        manager.meter = meters;

        double zwaarteKracht1 = (double)Math.Round(UnityEngine.Random.Range(9.00f, 12.00f) * 100f) / 100f;
        float minAnswer = (float)zwaarteKracht1 - 3;
        float maxAnswer = (float)zwaarteKracht1 + 2;

        double zwaarteKracht2 = (double)Math.Round(UnityEngine.Random.Range(minAnswer - 2.9f, minAnswer) * 100) / 100;
        double zwaarteKracht3 = (double)Math.Round(UnityEngine.Random.Range(maxAnswer, maxAnswer + 5.5f) * 100f) / 100f;

        planets[0].SetNewValues(zwaarteKracht2);
        planets[1].SetNewValues(zwaarteKracht1);
        planets[2].SetNewValues(zwaarteKracht3);

        foreach(Moveplanet planet in planets)
        {
            planet.isAnswer = false;
        }

        int correctPlanet = UnityEngine.Random.Range(0, planets.Length);

        double correctJ = gewicht * meters * planets[correctPlanet].zwaartekracht;
        correcteAntwoord = correctJ;
        manager.minJ = (int)(correctJ - 5);
        manager.maxJ = (int)(correctJ + 5);
        switch (correctPlanet)
        {
            case 0:
                planets[0].isAnswer = true;
                return;
            case 1:
                planets[1].isAnswer = true;
                return;
            case 2:
                planets[2].isAnswer = true;
                return;
        }
    }

    public void ChooseButton(int num)
    {
        activeButton = num;

        if (planets[num].isAnswer)
        {
            opdrachtCheck = true;
            manager.currentDialog = correct;
            manager.startSentence();
            if (!toetsActive)
            {
                questLeer.transform.parent = parent.transform;
            }
            Debug.Log("Correct");
        }
        else
        {
            opdrachtCheck = false;
            manager.currentDialog = inCorrect;
            manager.startSentence();
            Debug.Log("false");
        }
    }
}
