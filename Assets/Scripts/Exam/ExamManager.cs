using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System;
using System.Drawing;

public class GenerateText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI target;

    [SerializeField]
    private TextMeshProUGUI input;

    [SerializeField]
    private TextAsset examsAssset;

    [Serializable]
    public class Exam
    {
        public string title;
        public string story;
    }

    [Serializable]
    public class Exams
    {
        public Exam[] exams;
    }

    private string inputText;
    private bool inputCorrect;
    private string totalInput;
    private string targetText;
    private string targetTextToDisplay;
    private Exam[] exams;

    static System.Random rnd = new System.Random();

    private char[] allowedChars = { '\b', ' ', '.', '"', '\'', '(', ')', ',', '?', '!', '$' };

    // Start is called before the first frame update
    void Start()
    {
        this.exams = ReadExams();

        this.targetText = exams[rnd.Next(exams.Length)].story;
        this.targetTextToDisplay = "<color=\"green\"></color>" + this.targetText;
        this.target.SetText(targetTextToDisplay);
        this.inputText = "";
        this.inputCorrect = true;
        this.totalInput = "";
    }

    // Update is called once per frame
    void Update()
    {
        foreach( char c in Input.inputString)
        {
            if (!char.IsDigit(c) && !char.IsLetter(c) && c != '\b' && !allowedChars.Contains(c)) return;
            HandleTotalInput(c); // Total mora da stoji pre temp jer proverava validnost i govori da li temp moze da se clearuje ako naidje space.
            HandleTempInput(c);
        }
    }

    void HandleTotalInput(char c)
    {
        if (c != '\b')
        {
            if (c == ' ' && totalInput.Length > 0 && totalInput[totalInput.Length - 1] == ' ') return;
            totalInput += c;
        }
        else if(totalInput.Length > 0 && (totalInput[totalInput.Length - 1] != ' ' || !inputCorrect))
        {
            totalInput = totalInput.Remove(totalInput.Length - 1);
        }
        CheckInputValidiy();
        UpdateTotalTextColor();
    }

    void HandleTempInput(char c)
    {
        if (c == ' ' && !inputCorrect && inputText[inputText.Length - 1] == ' ') return;

        if (c != '\b')
            inputText += c;

        if (c == ' ' && inputCorrect)
        {
            inputText = " ";
        }  else if (c == '\b' && inputText.Length > 0)
        {
            inputText = inputText.Remove(inputText.Length - 1);
        }
        input.SetText(inputText);
    } 

    void UpdateInputColor()
    {
        if (inputCorrect)
            input.color = UnityEngine.Color.green;
        else
            input.color = UnityEngine.Color.red;
    }

    void UpdateTotalTextColor()
    {
        if (!inputCorrect) return;
        targetTextToDisplay = targetTextToDisplay.Replace("</color>", "");
        int pos = totalInput.Length;
        targetTextToDisplay = targetTextToDisplay.Insert(GetOffsetInsertPos(pos), "</color>");
        target.SetText(targetTextToDisplay);
    }

    void CheckInputValidiy()
    {
        if(targetText.StartsWith(totalInput))
        {
            this.inputCorrect = true;
        } else
        {
            this.inputCorrect = false;
        }
        UpdateInputColor();
    }

    int GetOffsetInsertPos(int pos)
    {
        return pos + "<color=\"green\">".Length;
    }

    Exam[] ReadExams()
    {
        return JsonUtility.FromJson<Exams>(examsAssset.text).exams;
    }
}
