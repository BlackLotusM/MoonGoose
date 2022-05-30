using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeText : MonoBehaviour
{
    DialogManager holo;
    public string standard;
    public TextMeshProUGUI target;
    // Start is called before the first frame update
    void Start()
    {
        holo = FindObjectOfType<DialogManager>();
        ChangeSentece();
    }

    public void ChangeSentece()
    {
        string sentence = standard;
        sentence = sentence.Replace("{gewicht}", holo.gewicht.ToString());
        sentence = sentence.Replace("{meter}", holo.meter.ToString());
        sentence = sentence.Replace("{min}", holo.minJ.ToString());
        sentence = sentence.Replace("{max}", holo.maxJ.ToString());
        target.text = sentence;
    }
}
