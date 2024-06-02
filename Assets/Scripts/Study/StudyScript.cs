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

    [SerializeField]
    private const int scoreGoal = 5;

    [SerializeField]
    private AudioClip correct, incorrect;

    private AudioSource audioSrc;

    private int currentScore = 0;

    private bool firstTime = true;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Player player;

    void darkenBackground()
    {
        spriteRenderer.color = new Color(player.Focus / 100f, player.Focus / 100f, player.Focus / 100f);
        player.DecrementFocus(4);
    }

    IEnumerator Loop ()
    {
        if (!firstTime) yield return new WaitForSeconds(0.5f);
        firstTime = false;
        generateLetter();
        yield return new WaitForSeconds(2f);
        TimeOut();
        yield return new WaitForSeconds(0.5f);
        StartCoroutine("Loop");
    }

    void generateLetter()
    {
        string chars = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        int index = UnityEngine.Random.Range(0, chars.Length);
        letter.text = chars[index].ToString();
        letterInternal = chars[index].ToString();
    }

    void TimeOut()
    {
        Debug.Log("Incorrect");
        letter.SetText("<color=\"red\">" + letter.text);
        audioSrc.clip = incorrect;
        audioSrc.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        player.State = Player.PlayerState.Studying;
        score.SetText(currentScore.ToString() + "/" + scoreGoal.ToString());
        StartCoroutine("Loop");
        InvokeRepeating("darkenBackground", 0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        HandleExit();
        if (Input.GetKeyDown(letterInternal.ToLower()))
        {
            Debug.Log("Correct");
            audioSrc.clip = correct;
            audioSrc.Play();
            currentScore++;
            letter.SetText("<color=\"green\">" + letter.text);
            score.SetText(currentScore.ToString() + "/" + scoreGoal.ToString());
            StopCoroutine("Loop");
            if(currentScore < scoreGoal)
            {
                StartCoroutine("Loop");
            }
            else
            {
                CancelInvoke();
                Debug.Log("SUCCESS!");
                player.State = Player.PlayerState.Inactive;
                player.IncrementPrep();
            }
        }
    }

    void HandleExit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LevelManager.Instance.LoadScene("WorldScene");
        }
    }
}
