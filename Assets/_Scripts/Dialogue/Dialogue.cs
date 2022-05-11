using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Dialogue
{
    public PersonSO characterOBJ;
    public string sentence;
}

[System.Serializable]
public class DialogueManager
{
    public Dialogue[] sentences;
    public bool closeAfter;
    public bool runEvent = false;
    public bool keepNavClosed = false;
    public UnityEvent yourCustomEvent;
}
