using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public string parameter;
    public AudioMixer mixer;
    public Slider slider;
    public TextMeshProUGUI valDisplay;

    public void SetLevel(float sliderVal)
    {
        mixer.SetFloat(parameter, Mathf.Log10(sliderVal) * 20);
        valDisplay.text = "" + (int)(slider.value * 100);
    }

    private void Start()
    {
        valDisplay.text = "" + (int)(slider.value * 100);
    }
}
