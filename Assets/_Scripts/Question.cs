using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Answers{
    [HideInInspector]
    public string titel;
    public string answers;
    public bool correct;
    [Space]
    public bool selected;
    public string filled;
}

[System.Serializable]
public class Question 
{
    public string titel;
    public string question;
    public bool multipleChoice = true;
    public List<Answers> answers;

    public void CheckAnswer()
    {
        
    }
}
