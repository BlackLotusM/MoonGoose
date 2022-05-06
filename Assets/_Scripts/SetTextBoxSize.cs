using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class SetTextBoxSize : MonoBehaviour
{
    public GridLayoutGroup group;
    private RectTransform rect;
    public float standardWidth = 200;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        rect = GetComponent<RectTransform>();
        float widht = rect.rect.width;
        float height = rect.rect.height;
        if (widht < standardWidth)
            widht = standardWidth;
        Vector2 newSize = new Vector2(widht, height);
        group.cellSize = newSize;
    }
}
