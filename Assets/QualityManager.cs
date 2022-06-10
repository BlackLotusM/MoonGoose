using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QualityManager : MonoBehaviour
{
    public Image[] targets;
    private void Start()
    {
        int qualityLevel = QualitySettings.GetQualityLevel();
        for (int i = 0; i < targets.Length; i++)
        {
            Color col = targets[i].color;
            if (i == qualityLevel)
            {
                col.a = 1;
            }
            else
            {
                col.a = 0.5f;
            }
            targets[i].color = col;
        }
    }
    public void SetQuality(int qualityLevel)
    {
        QualitySettings.SetQualityLevel(qualityLevel);
        for (int i = 0; i < targets.Length; i++)
        {
            Color col = targets[i].color;
            if (i == qualityLevel)
            {
                col.a = 1;
            }
            else
            {
                col.a = 0.5f;
            }
            targets[i].color = col;
        }
    }
}
