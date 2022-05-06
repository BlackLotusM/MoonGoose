using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Vraag3 : MonoBehaviour
{

    [SerializeField]
    private Sprite[] windEnergie, windInfo, waterEnergie, waterInfo, zonEnergie, zonInfo;
    public Image targetImage;
    public Image uitlegTarget;
    public int correctBtn;

    //used for randomize
    private List<int> intList;

    [SerializeField]
    public List<Collect> intPicState;
    public IEnumerator running;
    public float waitTime;

    public int activeInt = 0;

    [Serializable]
    public class Collect
    {
        public int picState = 0;
        public int btnInt;
        public List<Sprite> sprites = new List<Sprite>();
        public Sprite uitleg;
    }

    private void Start()
    {
        running = updateNum();
        SetAnswer();
    }

    private void Update()
    {
        targetImage.sprite = intPicState[activeInt].sprites[intPicState[activeInt].picState];
        uitlegTarget.sprite = intPicState[activeInt].uitleg;
        if (Input.GetKeyDown(KeyCode.R))
        {
            SetAnswer();
        }
    }

    public IEnumerator updateNum()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            foreach (Collect item in intPicState)
            {
                item.picState += 1;
              
            }
            yield return new WaitForSeconds(waitTime);
            foreach (Collect item in intPicState)
            {
                item.picState -= 1;
            }
        }

        
    }

    public void SetAnswer()
    {
        StopCoroutine(running);
        intPicState = new List<Collect>();
        intList = new List<int>() { 0, 1, 2 };

        
        for (int i = 0; i < 3; i++)
        {
            int random = UnityEngine.Random.Range(0, intList.Count);
            int selected = intList[random];
            intList.Remove(selected);

            if(i == 0)
            {
                int r = UnityEngine.Random.Range(0, zonEnergie.Length - 1);
                if (r % 2 != 0)
                    r += 1;
                Collect temp = new Collect();
                temp.btnInt = selected;
                correctBtn = selected;
                temp.picState = 0;
                if (r == 0)
                    temp.uitleg = zonInfo[r];
                else
                    temp.uitleg = zonInfo[r - 1];
                temp.sprites.Add(zonEnergie[r]);
                temp.sprites.Add(zonEnergie[r + 1]);
                intPicState.Insert(i, temp);
            }
            else if(i == 1){
                int r2 = UnityEngine.Random.Range(0, windEnergie.Length - 1);
                if (r2 % 2 != 0)
                    r2 += 1;
                Collect temp = new Collect();
                temp.btnInt = selected;
                temp.picState = 0;
                temp.sprites.Add(windEnergie[r2]);
                if (r2 == 0)
                    temp.uitleg = windInfo[r2];
                else
                    temp.uitleg = windInfo[r2 - 1];
                temp.sprites.Add(windEnergie[r2 + 1]);
                intPicState.Insert(i, temp);
            }
            else if(i == 2) { 
                    int r3 = UnityEngine.Random.Range(0, waterEnergie.Length - 1);
                if (r3 % 2 != 0)
                    r3 += 1;
                Collect temp = new Collect();
                temp.btnInt = selected;
                temp.picState = 0;
                temp.sprites.Add(waterEnergie[r3]);
                if (r3 == 0)
                    temp.uitleg = waterInfo[r3];
                else
                    temp.uitleg = waterInfo[r3 - 1];
                temp.sprites.Add(waterEnergie[r3 + 1]);
                intPicState.Insert(i, temp);
            }
        }
        running = updateNum();
        StartCoroutine(running);
    }

    public void ChangeInxdex(int index)
    {
        activeInt = index;
    }

    public void CheckAnswer(int value)
    {
        if(value == 1)
        {
            Debug.Log("goed");
        }
        else
        {
            Debug.Log("fout");
        }
    }
}
