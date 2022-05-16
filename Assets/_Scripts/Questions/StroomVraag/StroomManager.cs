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

    public DialogTesting correct;
    public DialogTesting incorrect;

    public bool opdrachtCheck;

    public bool toetsActive;
    public GameObject questLeer;
    public GameObject questToets;
    public GameObject parent;

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
        numberList[numberPlace]++;
        if (numberList[numberPlace] > 9)
            numberList[numberPlace] = 0;
        UpdateUI();
    }

    public void DecrementNumber(int numberPlace)
    {
        numberList[numberPlace]--;
        if(numberList[numberPlace] < 0)
            numberList[numberPlace] = 9;
        UpdateUI();
    }

    private void UpdateUI()
    {
        for (int i = 0; i < textNumber.Length; i++)
        {
            textNumber[i].text = numberList[i].ToString();
        }
    }
    public string temp;
    public void LockIn()
    {
        temp = "";
        for (int i = 0; i < numberList.Count; i++)
        {
            temp += numberList[i];
        }
        if (correctAnswer == Convert.ToInt32(temp))
        {
            if (!toetsActive)
            {
                questLeer.transform.parent = parent.transform;
            }
            opdrachtCheck = true;
            correct.SetAndStart();
        }
        else
        {
            incorrect.SetAndStart();
            opdrachtCheck = false;
        }
    }
}
