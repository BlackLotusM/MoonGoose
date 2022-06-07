using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StroomManager : MonoBehaviour
{
    public TextMeshProUGUI oxygenSupplierTXT;
    public TextMeshProUGUI batteryTXT;
    public TextMeshProUGUI[] textNumber;
    public List<int> numberList = new List<int> { 0, 0, 0, 0 };
    public int correctAnswer = 1234;

    public OpenQuestion helpBtn;

    public DialogTesting answer;
    public DialogTesting changedAnswer;

    public bool opdrachtCheck;

    public bool toetsActive;
    public GameObject questLeer;
    public GameObject questToets;
    public GameObject parent;
    public int atempt = 0;
    public AudioSource audio;
    public AudioSource click;
    public bool active = false;

    public void ActivateQuestion()
    {
        active = true;
    }

    private void Start()
    {
        GenerateQuestion();
        UpdateUI();
    }

    public void GenerateQuestion()
    {
        numberList = new List<int> { 0, 0, 0, 0 };
        int _capaciteitBaterij = UnityEngine.Random.Range(3333, 8888);
        int _gebruikOxygenSypply = UnityEngine.Random.Range(1000, _capaciteitBaterij);
        batteryTXT.text = "Cappaciteit Baterij: "+ _capaciteitBaterij + "\n WattUur" ;
        oxygenSupplierTXT.text = (decimal)_gebruikOxygenSypply / 1000 + " kWh";
        correctAnswer = _capaciteitBaterij - _gebruikOxygenSypply;
        UpdateUI();
    }

    public void IncrementNumber(int numberPlace)
    {
        if (!active)
            return;
        numberList[numberPlace]++;
        if (numberList[numberPlace] > 9)
            numberList[numberPlace] = 0;
        UpdateUI();
    }

    public void DecrementNumber(int numberPlace)
    {
        if (!active)
            return;
        numberList[numberPlace]--;
        if(numberList[numberPlace] < 0)
            numberList[numberPlace] = 9;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if(active)
            click.Play();
        for (int i = 0; i < textNumber.Length; i++)
        {
            textNumber[i].text = numberList[i].ToString();
        }
    }
    public string temp;
    public void LockIn()
    {
        if (!active)
            return;
        atempt++;
        audio.Play();
        questLeer.transform.parent = parent.transform;
        changedAnswer.dm.StopCor();
        if (atempt == 1)
        {
            opdrachtCheck = true;
            answer.SetAndStart();
        }
        else
        {
            changedAnswer.dm.panel.SetActive(false);
            changedAnswer.currentConvoIndex = 0;
            changedAnswer.currentSentenceIndex = -1;
            changedAnswer.active = true;
            changedAnswer.SetAndStart();
            opdrachtCheck = false;
        }

        //helpBtn.CloseBtn(false);
        //temp = "";
        //for (int i = 0; i < numberList.Count; i++)
        //{
        //    temp += numberList[i];
        //}
        //if (correctAnswer == Convert.ToInt32(temp))
        //{
        //    if (!toetsActive)
        //    {
                
        //    }
            
        //}
        //else
        //{
            
        //}
    }
}
