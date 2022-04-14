using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogTesting : MonoBehaviour
{
    //public TextMeshProUGUI characterName;
    //public Image characterProfile;
    //public TextMeshProUGUI txtDialogue;
    //public GameObject navigationUI;

    public int currentConvoIndex = 0;
    public int currentSentenceIndex = 0;

    public float sentenceSpeed = 0.09f;
    public GameObject panel;

    //public IEnumerator typer;
    //public bool corIsRunning;

    //Disables when done
    public bool active = true;
    public bool runOnStart;

    public DialogueManager[] sentences;
    

    //public void activateObject()
    //{
    //    if (active && !panel.activeSelf)
    //    {
    //        panel.SetActive(true);
    //        startSentence();
    //    }
    //}

    //private void Start()
    //{
    //    if(runOnStart)
    //        startSentence();
    //}

    //public void startSentence()
    //{
    //    if (!active)
    //    {
    //        return;
    //    }
    //    if (!corIsRunning)
    //        currentSentenceIndex++;

    //    if(currentSentenceIndex == sentences[currentConvoIndex].sentences.Length && !corIsRunning)
    //    {
    //        if (sentences[currentConvoIndex].closeAfter)
    //        {
    //            navigationUI.SetActive(true);
    //            panel.SetActive(false);
    //            currentSentenceIndex = -1;
    //        }else
    //            currentSentenceIndex = 0;

    //        currentConvoIndex++;

    //        if(currentConvoIndex == sentences.Length)
    //            active = false;
    //        if (sentences[currentConvoIndex - 1].closeAfter)
    //        {
    //            return;
    //        }
    //    }

    //    if(!corIsRunning && currentConvoIndex == sentences.Length)
    //    {
    //        return;
    //    }

    //    navigationUI.SetActive(false);
    //    panel.SetActive(true);

    //    Dialogue[] currentSentence = sentences[currentConvoIndex].sentences;
    //    if (!corIsRunning)
    //    {
    //        typer = typeSentence(currentSentence[currentSentenceIndex]);
    //        StartCoroutine(typer);
    //    }
    //    else
    //    {
    //        skipSentence(currentSentence[currentSentenceIndex].sentence);
    //    }
    //}

    //public void skipSentence(string sentence)
    //{
    //    if (corIsRunning)
    //    {
    //        corIsRunning = false;
    //        StopCoroutine(typer);
    //        txtDialogue.text = sentence;
    //    }
    //}

    //public IEnumerator typeSentence(Dialogue sentence)
    //{
    //    txtDialogue.text = "";
    //    characterProfile.sprite = sentence.characterOBJ.profilePic;
    //    characterName.text = sentence.characterOBJ.characterName;

    //    corIsRunning = true;
    //    foreach (char c in sentence.sentence)
    //    {
    //        txtDialogue.text += c;
    //        yield return new WaitForSeconds(sentenceSpeed);
    //    }
    //    corIsRunning = false;
    //}

}
