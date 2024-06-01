using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class StudyScript : MonoBehaviour 
{
    [SerializeField]
    private TextMeshProUGUI letter;

    private String letterInternal;
    
    void generateLetter()
    {
        string chars = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        int index = UnityEngine.Random.Range(0, chars.Length);
        letter.text = chars[index].ToString();
        letterInternal = chars[index].ToString();
    }

    void timeOut()
    {
        Debug.Log("Incorrect");
        letter.SetText("<color=\"red\">" + letter.text);
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("generateLetter", 0f, 2.5f);
        InvokeRepeating("timeOut", 2.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(letterInternal.ToLower()))
        {
            CancelInvoke();
            Debug.Log("Correct");
            letter.SetText("<color=\"green\">" + letter.text);
            InvokeRepeating("generateLetter", 0.5f, 2.5f);
            InvokeRepeating("timeOut", 2.5f, 2.0f);
        }
    }
}
