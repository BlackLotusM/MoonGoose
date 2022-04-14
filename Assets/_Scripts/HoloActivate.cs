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

    private void Start()
    {
        manager = FindObjectOfType<DialogManager>();
        manager.currentDialog = test;
        manager.startSentence();
        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }
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

    public void chooseButton(int num)
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
