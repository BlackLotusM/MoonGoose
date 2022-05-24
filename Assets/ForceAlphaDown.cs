using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ForceAlphaDown : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(textMesh.color.a > 0)
        {
            Color temp = textMesh.color;
            temp.a -= 0.32f * Time.deltaTime;
            textMesh.color = temp;
        }
    }
}
