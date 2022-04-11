using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


#if UNITY_EDITOR
[ExecuteInEditMode]
public class SameWithEditor : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private RectTransform rect;
    private GridLayoutGroup group;
    // Update is called once per frame
    void Update()
    {
        if (!Application.isEditor) return;
        rect = GetComponent<RectTransform>();
        group = GetComponent<GridLayoutGroup>();

        Vector2 newSize = new Vector2(rect.rect.width, 105);
        group.cellSize = newSize;
    }

}
#endif

