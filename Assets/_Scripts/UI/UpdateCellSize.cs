using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
[ExecuteInEditMode]
public class UpdateCellSize : MonoBehaviour
{
    public float div = 4;
    private RectTransform rect;
    private GridLayoutGroup group;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        group = GetComponent<GridLayoutGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        float width = rect.rect.width;
        Vector2 newSize = new Vector2(width / div, rect.rect.height);
        group.cellSize = newSize;
    }
}
#endif
