using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HoloActivate : MonoBehaviour
{
    public Moveplanet[] planets;
    public ParticleSystem particle;
    public ParticleSystem particle2;
    
    public int activeButton = -1;
    public DialogTesting test;
    public DialogTesting correct;
    public DialogTesting inCorrect;
    public DialogManager manager;
    public GameObject[] buttons;

    public float gewicht;
    public float meters;
    public float correcteAntwoord;

    private void Start()
    {
        manager = FindObjectOfType<DialogManager>();
        manager.currentDialog = test;
        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }

        ResetPlanets();
    }

    private void OnMouseDown()
    {
        manager.startSentence();
        manager.activateObject();

        foreach (Moveplanet planet in planets)
        {
            planet.updateState();
        }
    }
    private void Update()
    {
        if (planets[0].planetActive)
        {
            if (particle.gameObject.transform.localScale.x < 1f)
            {
                var vec = particle.gameObject.transform.localScale;
                vec.x += 0.008f;
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
                vec.x -= 0.008f;
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

        gewicht = (float)Math.Round(UnityEngine.Random.Range(2.1f, 12.5f) * 10f) * 0.1f;
        meters = UnityEngine.Random.Range(1, 8);
        manager.gewicht = gewicht;
        manager.meter = meters;

        float zwaarteKracht1 = (float)Math.Round(UnityEngine.Random.Range(9.00f, 12.00f) * 100f) / 100f;
        float minAnswer = zwaarteKracht1 - 3;
        float maxAnswer = zwaarteKracht1 + 2;

        float zwaarteKracht2 = (float)Math.Round(UnityEngine.Random.Range(minAnswer - 2.9f, minAnswer) * 100f) / 100f;
        float zwaarteKracht3 = (float)Math.Round(UnityEngine.Random.Range(maxAnswer, maxAnswer + 5.5f) * 100f) / 100f;

        planets[0].SetNewValues(zwaarteKracht2);
        planets[1].SetNewValues(zwaarteKracht1);
        planets[2].SetNewValues(zwaarteKracht3);

        foreach(Moveplanet planet in planets)
        {
            planet.isAnswer = false;
        }

        int correctPlanet = UnityEngine.Random.Range(0, planets.Length);

        float correctJ = gewicht * meters * planets[correctPlanet].zwaartekracht;
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
            manager.currentDialog = correct;
            manager.startSentence();
            Debug.Log("Correct");
        }
        else
        {
            manager.currentDialog = inCorrect;
            manager.startSentence();
            Debug.Log("false");
        }
    }
}
