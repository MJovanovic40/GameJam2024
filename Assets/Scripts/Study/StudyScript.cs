using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class StudyScript : MonoBehaviour 
{
    [SerializeField]
    private TextMeshProUGUI letter;

    [SerializeField]
    private TextMeshProUGUI score;

    private String letterInternal;

    private int scoreGoal = 5;

    private int currentScore = 0;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Player player;

    void darkenBackground()
    {
        spriteRenderer.color = new Color(player.Focus / 100f, player.Focus / 100f, player.Focus / 100f);
        player.DecrementFocus(4);
    }

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
        score.SetText(currentScore.ToString() + "/" + scoreGoal.ToString());
        InvokeRepeating("generateLetter", 0f, 2.5f);
        InvokeRepeating("timeOut", 2.0f, 2.0f);
        InvokeRepeating("darkenBackground", 0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(letterInternal.ToLower()))
        {
            CancelInvoke();
            Debug.Log("Correct");
            currentScore++;
            letter.SetText("<color=\"green\">" + letter.text);
            score.SetText(currentScore.ToString() + "/" + scoreGoal.ToString());
            if(currentScore < scoreGoal)
            {
                InvokeRepeating("generateLetter", 0.5f, 2.5f);
                InvokeRepeating("timeOut", 2.5f, 2.0f);
            }
            else
            {
                CancelInvoke();
                Debug.Log("SUCCESS!");
            }
        }
    }
}
