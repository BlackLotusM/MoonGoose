using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionShow : MonoBehaviour
{
    public DialogManager holo;
    public TextMeshProUGUI sentence;
    public GameObject target;
    public bool dialogueDone;
    public string defaultText;

    // Start is called before the first frame update
   

    public void UpdateText()
    {
        sentence.text = defaultText;
        sentence.text = sentence.text.Replace("{gewicht}", holo.gewicht.ToString());
        sentence.text = sentence.text.Replace("{meter}", holo.meter.ToString());
        sentence.text = sentence.text.Replace("{min}", holo.minJ.ToString());
        sentence.text = sentence.text.Replace("{max}", holo.maxJ.ToString());
    }

    public void StateText(bool state)
    {
        if(dialogueDone)
            target.SetActive(state);
        UpdateText();
    }

    public void DialogueDone(bool state)
    {
        dialogueDone = state;
    }
}
