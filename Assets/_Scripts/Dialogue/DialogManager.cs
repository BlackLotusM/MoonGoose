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

    public void startSentence()
    {
        if (!currentDialog.active)
        {
            panel.SetActive(false);
            return;
        }
        if (!corIsRunning)
            currentDialog.currentSentenceIndex++;

        if (currentDialog.currentSentenceIndex == currentDialog.sentences[currentDialog.currentConvoIndex].sentences.Length && !corIsRunning)
        {
            if (currentDialog.sentences[currentDialog.currentConvoIndex].runEvent)
            {
                if(currentDialog.sentences[currentDialog.currentConvoIndex].yourCustomEvent != null)
                    currentDialog.sentences[currentDialog.currentConvoIndex].yourCustomEvent.Invoke();
            }
            if (currentDialog.sentences[currentDialog.currentConvoIndex].closeAfter)
            {
                if(!currentDialog.sentences[currentDialog.currentConvoIndex].keepNavClosed && !keepNavDisable)
                    navigationUI.SetActive(true);
                panel.SetActive(false);
                currentDialog.currentSentenceIndex = -1;
            }
            else
            {
                currentDialog.currentSentenceIndex = 0;
            }

            currentDialog.currentConvoIndex++;

            if (currentDialog.currentConvoIndex == currentDialog.sentences.Length)
                currentDialog.active = false;
            if (currentDialog.sentences[currentDialog.currentConvoIndex - 1].closeAfter)
            {
                return;
            }
        }

        if (!corIsRunning && currentDialog.currentConvoIndex == currentDialog.sentences.Length)
        {
            return;
        }
        
        navigationUI.SetActive(false);
        panel.SetActive(true);

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
        txtDialogue.text = "";
        characterProfile.sprite = sentence.characterOBJ.profilePic;
        characterName.text = sentence.characterOBJ.characterName;
        sentence.sentence = sentence.sentence.Replace("{leerling}", leerlingOBJ.characterName);
        sentence.sentence = sentence.sentence.Replace("{gewicht}", gewicht.ToString());
        sentence.sentence = sentence.sentence.Replace("{meter}", meter.ToString());
        sentence.sentence = sentence.sentence.Replace("{min}", minJ.ToString());
        sentence.sentence = sentence.sentence.Replace("{max}", maxJ.ToString());
        corIsRunning = true;
        foreach (char c in sentence.sentence)
        {
            txtDialogue.text += c;
            yield return new WaitForSeconds(sentenceSpeed);
        }
        corIsRunning = false;
        if (currentDialog.currentConvoIndex == currentDialog.sentences.Length - 1 && currentDialog.currentSentenceIndex == currentDialog.sentences[currentDialog.currentConvoIndex].sentences.Length - 1)
            currentDialog.active = false;
    }
}
