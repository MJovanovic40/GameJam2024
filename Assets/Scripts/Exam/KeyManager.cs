using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyManager : MonoBehaviour
{

    private Animator animator;
    private TextMeshProUGUI text;

    private string mapping;

    [SerializeField]
    private KeyCode keyCode;


    [SerializeField]
    private GameObject examManager;

    // Start is called before the first frame update
    void Start()
    {

        animator = gameObject.GetComponent<Animator>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        string code = keyCode.ToString().Replace("Alpha", "").Trim();
        code = GetMapping(code);
        if (examManager != null && keyCode.ToString().Length == 1)
            mapping = examManager.GetComponent<ExamManager>().KeyboardMap.GetValueOrDefault(code[0], code[0]).ToString();
        else
            mapping = GetMapping(code);
        if (text != null)
        {
            text.SetText(mapping + "");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            animator.Play("New State", -1, 0f);
        }
    }

    string GetMapping(string mapping)
    {
        switch(mapping)
        {
            case "Backspace":
                return "<-";
            case "Control":
                return "CTRL";
            case "Escape":
                return "ESC";
            case "Tilde":
                return "~";
            case "BackQuote":
                return "`";
            case "Minus":
                return "-";
            case "Equals":
                return "=";
            case "LeftParen":
                return "{";
            case "RightParen":
                return "}";
            case "Backslash":
                return "\\";
            case "LeftBracket":
                return "[";
            case "RightBracket":
                return "]";
            case "Semicolon":
                return ";";
            case "Quote":
                return "'";
            case "Return":
                return "Enter";
            case "CapsLock":
                return "Caps";
            case "LeftShift":
                return "Shift";
            case "RightShift":
                return "Shift";
            case "LeftControl":
                return "Ctrl";
            case "RightControl":
                return "Ctrl";
            case "LeftWindows":
                return "Win";
            case "RightWindows":
                return "Win";
            case "LeftAlt":
                return "Alt";
            case "RightAlt":
                return "Alt";
            case "RightMeta":
                return "Meta";
            case "Comma":
                return ",";
            case "Period":
                return ".";
            case "Slash":
                return "/";
            default:
                return mapping;
        }
    }
}