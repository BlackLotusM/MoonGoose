using UnityEngine;

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
}
