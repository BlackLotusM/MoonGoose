using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data; //refference for DataTable 
using System.Text.RegularExpressions;
using System.Xml.XPath;
using System.IO;
using TMPro;

public class Calculator : MonoBehaviour
{
    public string math;
    public TMP_InputField inputField;
    public TMP_InputField answerField;
    public Moveplanet planet;

    public void Done()
    {
        planet.Done("Jou antwoord" + answerField.text);
    }

    public void AddCharacter(string character)
    {
        math += character;
        inputField.text = math;
        answerField.text = "= " + Evaluate(math);
    }

    public void UpdateCalc()
    {
        inputField.text = math;
        answerField.text = "= " + Evaluate(math);
    }

    public void edit()
    {
        math = inputField.text;
        inputField.text = math;
        answerField.text = "= " + Evaluate(math);
    }


    public string Evaluate(string expression)
    {
        var xsltExpression =
            string.Format("number({0})",
                new Regex(@"([\+\-\*])").Replace(expression, " ${1} ")
                                        .Replace("/", " div ")
                                        .Replace("%", " mod "));

        double temp = (double)new XPathDocument
            (new StringReader("<r/>"))
                .CreateNavigator()
                .Evaluate(xsltExpression);
        
        bool test = double.IsNaN(temp);
        if (test)
        {
            return "Error";
        }else if(temp < 0)
        {
            return "Antwoord kan niet negatief zijn";
        }
        else
        {
            return temp + "J";
        }
    }
}
