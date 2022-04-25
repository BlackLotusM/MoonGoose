using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteInEditMode]
public class FixText : MonoBehaviour
{
    public TMP_FontAsset font;
    public TextMeshProUGUI[] meshes;
    // Start is called before the first frame update
    void Start()
    {
        meshes = FindObjectsOfType<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (TextMeshProUGUI item in meshes)
        {
            item.font = font;
        }
    }
}
