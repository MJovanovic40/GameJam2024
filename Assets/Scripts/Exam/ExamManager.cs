using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerateText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI target;

    [SerializeField]
    private TextMeshProUGUI input;


    private string inputText;
    private bool inputCorrect;
    private string totalInput;
    private string targetText;
    private string targetTextToDisplay;

    // Start is called before the first frame update
    void Start()
    {
        this.targetText = "Agreed joy vanity regret met may ladies oppose who. Mile fail as left as hard eyes. Meet made call in mean four year it to. Prospect so branched wondered sensible of up. For gay consisted resolving pronounce sportsman saw discovery not. Northward or household as conveying we earnestly believing. No in up contrasted discretion inhabiting excellence. Entreaties we collecting unpleasant at everything conviction.";
        this.targetTextToDisplay = "<color=\"green\"></color>Agreed joy vanity regret met may ladies oppose who. Mile fail as left as hard eyes. Meet made call in mean four year it to. Prospect so branched wondered sensible of up. For gay consisted resolving pronounce sportsman saw discovery not. Northward or household as conveying we earnestly believing. No in up contrasted discretion inhabiting excellence. Entreaties we collecting unpleasant at everything conviction.";
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
            HandleTotalInput(c); // Total mora da stoji pre temp jer proverava validnost i govori da li temp moze da se clearuje ako naidje space.
            HandleTempInput(c);
        }
    }

    void HandleTotalInput(char c)
    {
        if (c != '\b')
        {
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
        if(c != '\b')
            inputText += c;

        if (c == ' ' && inputCorrect)
        {
            inputText = " ";
        } else if (c == '\b' && inputText.Length > 0)
        {
            inputText = inputText.Remove(inputText.Length - 1);
        }
        input.SetText(inputText);
    } 

    void UpdateInputColor()
    {
        if (inputCorrect)
            input.color = Color.green;
        else
            input.color = Color.red;
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
}
