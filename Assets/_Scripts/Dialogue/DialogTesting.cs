using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogTesting : MonoBehaviour
{
    public int currentConvoIndex = 0;
    public int currentSentenceIndex = -1;
    public float sentenceSpeed = 0.09f;
    //Disables when done
    public bool active = true;
    public bool runOnStart;

    public DialogueManager[] sentences;
}
