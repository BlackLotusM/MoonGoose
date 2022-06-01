using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI characterName;
    public Image characterProfile;
    public TextMeshProUGUI txtDialogue;
    public GameObject navigationUI;
    public PersonSO leerlingOBJ;

    public double meter;
    public double gewicht;
    public double minJ;
    public double maxJ;

    public float sentenceSpeed = 0.09f;
    public GameObject panel;

    public IEnumerator typer;
    public bool corIsRunning;

    public bool keepNavDisable;

    //Disables when done
    public bool runOnStart;

    public DialogTesting currentDialog;

    public void activateObject()
    {
        if (currentDialog.active && !panel.activeSelf)
        {
            panel.SetActive(true);
            startSentence();
        }
    }

    private void Start()
    {
        if (currentDialog && currentDialog.runOnStart)
            startSentence();
    }

    public void StopCor()
    {
        if (typer != null)
        {
            StopCoroutine(typer);
            corIsRunning = false;
        }
    }

    public void startSentence()
    {
        //Need to check somewhere if it was antwoord change
        //Need to check where i can reset.

        //Checked of dialog wel actief is zo niet return
        if (!currentDialog.active)
        {
            panel.SetActive(false);
            return;
        }

        panel.SetActive(true);

        //Als sentence klaar is dan kan je dit uitvoeren
        if (!corIsRunning)
        {
            currentDialog.currentSentenceIndex++;

            if (currentDialog.currentSentenceIndex == currentDialog.sentences[currentDialog.currentConvoIndex].sentences.Length)
            {
                if (currentDialog.sentences[currentDialog.currentConvoIndex].closeAfter)
                {
                    panel.SetActive(false);
                    if (currentDialog.sentences[currentDialog.currentConvoIndex].runEvent)
                    {
                        if (currentDialog.sentences[currentDialog.currentConvoIndex].yourCustomEvent != null)
                            currentDialog.sentences[currentDialog.currentConvoIndex].yourCustomEvent.Invoke();
                    }

                    currentDialog.currentSentenceIndex = -1;
                    currentDialog.currentConvoIndex++;
                    if (currentDialog.currentConvoIndex == currentDialog.sentences.Length)
                    {
                        currentDialog.active = false;
                    }
                    return;
                }
                else
                {
                    //Resets for if there are more than 1 block of lines
                    currentDialog.currentSentenceIndex = 0;
                }

                //Increases convo index
                currentDialog.currentConvoIndex++;

                if (currentDialog.currentConvoIndex == currentDialog.sentences.Length - 1 && currentDialog.currentSentenceIndex == currentDialog.sentences[currentDialog.currentConvoIndex].sentences.Length - 1 && currentDialog.resetAfter)
                {
                    currentDialog.active = true;
                    currentDialog.currentConvoIndex = 0;
                    currentDialog.currentSentenceIndex = -1;
                }

                if (currentDialog.currentConvoIndex == currentDialog.sentences.Length)
                {
                        currentDialog.active = false;
                }

                if (currentDialog.sentences[currentDialog.currentConvoIndex - 1].closeAfter)
                {
                    return;
                }
            }

            if (currentDialog.currentConvoIndex == currentDialog.sentences.Length)
            {
                return;
            }
        }

        //Checks if you can skip or should start new sentence
        Dialogue[] currentSentence = currentDialog.sentences[currentDialog.currentConvoIndex].sentences;
        if (!corIsRunning)
        {
            typer = typeSentence(currentSentence[currentDialog.currentSentenceIndex]);
            StartCoroutine(typer);
        }
        else
        {
            skipSentence(currentSentence[currentDialog.currentSentenceIndex].sentence);
        }
    }

    public void skipSentence(string sentence)
    {
        if (corIsRunning)
        {
            corIsRunning = false;
            StopCoroutine(typer);
            txtDialogue.text = sentence;
        }
    }
    public IEnumerator typeSentence(Dialogue sentence)
    {
        corIsRunning = true;
        txtDialogue.text = "";
        characterProfile.sprite = sentence.characterOBJ.profilePic;
        characterName.text = sentence.characterOBJ.characterName;
        sentence.sentence = sentence.sentence.Replace("{leerling}", leerlingOBJ.characterName);
        sentence.sentence = sentence.sentence.Replace("{gewicht}", gewicht.ToString());
        sentence.sentence = sentence.sentence.Replace("{meter}", meter.ToString());
        sentence.sentence = sentence.sentence.Replace("{min}", minJ.ToString());
        sentence.sentence = sentence.sentence.Replace("{max}", maxJ.ToString());
        
        foreach (char c in sentence.sentence)
        {
            txtDialogue.text += c;
            yield return new WaitForSeconds(sentenceSpeed);
        }
        corIsRunning = false;
        if (currentDialog.currentConvoIndex == currentDialog.sentences.Length - 1 && currentDialog.currentSentenceIndex == currentDialog.sentences[currentDialog.currentConvoIndex].sentences.Length - 1)
        {
            currentDialog.active = false;
        }
    }
}
