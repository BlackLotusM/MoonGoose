using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StroomManager : MonoBehaviour
{
    public TextMeshProUGUI[] textNumber;
    public List<int> numberList = new List<int> { 0, 0, 0, 0 };
    public int correctAnswer = 1234;
    private void Start()
    {
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
            Debug.Log("Correct");
        else
            Debug.Log("False");
    }
}