using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogTesting : MonoBehaviour
{
    public int currentConvoIndex = 0;
    public int currentSentenceIndex = 0;

    public float sentenceSpeed = 0.09f;
    public GameObject panel;
    //Disables when done
    public bool active = true;
    public bool runOnStart;

    public DialogueManager[] sentences;
}
