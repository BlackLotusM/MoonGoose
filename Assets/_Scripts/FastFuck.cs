using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastFuck : MonoBehaviour
{
    public Image holder;
    public Sprite v1, v2;
    public bool run = true;
    private void Start()
    {
        StartCoroutine(sheeeee());
    }
    public IEnumerator sheeeee()
    {
        while (run)
        {
            yield return new WaitForSeconds(0.75f);
            holder.sprite = v1;
            yield return new WaitForSeconds(0.75f);
            holder.sprite = v2;
        }
    }
}
