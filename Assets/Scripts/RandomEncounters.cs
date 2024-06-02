using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RandomEncounters : MonoBehaviour
{
    private const float robOddStart = 0f, robOddEnd = 0.091f, breakupOddStart = 0.101f, breakupOddEnd = 0.209f, hookupOddStart = 0.32f, hookupOddEnd = 0.53f,
        crashOddStart = 0.60f, crashOddEnd = 0.65f, powerOddStart = 0.65f, powerOddEnd = 0.855f, injuryOddStart = 0.855f, injuryOddEnd = 0.9f, tipOddStart = 0.9f,
        friendOddStart = 0.209f, friendOddEnd = 0.31f;

    [SerializeField]
    private Player player;

    [SerializeField]
    private GameObject StudyManager;

    IEnumerator Loop()
    {
        yield return new WaitForSeconds(5f);
        float random = UnityEngine.Random.Range(0f, 1f);
        Debug.Log(random);
        switch(player.State)
        {
            case Player.PlayerState.AtExam: yield break;
            case Player.PlayerState.Inactive: yield break;
            case Player.PlayerState.InTown:
                {
                    switch(random)
                    {
                        case float i when i > robOddStart && i <= robOddEnd:
                            {
                                Debug.Log("Opljackan si");
                                player.DecrementFocus(5);
                                player.DecrementHealth(5);
                                player.DecrementStamina(5);
                                player.DecrementMoney(3000);
                                break;
                            }
                        case float i when i > breakupOddStart && i <= breakupOddEnd && player.HasGf:
                            {
                                Debug.Log("Raskinula riba s tobom");
                                player.HasGf = false;
                                player.DecrementFocus(50);
                                player.DecrementStamina(10);
                                break;
                            }
                        case float i when i > crashOddStart && i <= crashOddEnd: 
                            {
                                Debug.Log("Slupao se auto u tebe");
                                player.DecrementFocus(30);
                                player.DecrementHealth(80);
                                player.DecrementStamina(80);
                                player.DecrementMoney(20000);
                                //TODO: mozda preskociti 3dana u bolnici kao?
                                break; 
                            }
                        case float i when i > friendOddStart && i <= friendOddEnd:
                            {
                                Debug.Log("Naleteo si na starog druga i dobro ste se ispricali");
                                player.IncrementFocus(5);
                                player.DecrementStamina(5);
                                player.IncrementHealth(10);
                                player.DecrementMoney(250);
                                break;
                            }
                    }
                    break;
                }
            case Player.PlayerState.AtWork:
                {
                    if (random > injuryOddStart && random <= injuryOddEnd)
                    {
                        Debug.Log("Povredio si se na poslu");
                        player.DecrementHealth(20);
                        //TODO prekinuti minigame ranije
                    }
                 
                    else if (random > tipOddStart && random <= 1f) 
                    { 
                        Debug.Log("Dobio si baksis od musterije"); 
                        player.IncrementMoney(300); 
                    }
                    break;
                }
            case Player.PlayerState.Studying:
                {
                    if (random > powerOddStart && random <= powerOddEnd) 
                    { 
                        StudyScript obj = StudyManager.GetComponent<StudyScript>();
                        if (obj != null) { 
                            obj.StopAllCoroutines();
                            obj.CancelInvoke();
                        }
                        Debug.Log("Nestalo struje dok ucis");
                        StopAllCoroutines();
                    }
                    break;
                }
        }
        StartCoroutine("Loop");
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Loop");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
