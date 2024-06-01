using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RandomEncounters : MonoBehaviour
{
    private const float robOddStart = 0f, robOddEnd = 0.091f, breakupOddStart = 0.101f, breakupOddEnd = 0.309f, hookupOddStart = 0.32f, hookupOddEnd = 0.53f,
        crashOddStart = 0.60f, crashOddEnd = 0.65f, powerOddStart = 0.65f, powerOddEnd = 0.855f, injuryOddStart = 0.855f, injuryOddEnd = 1f;

    [SerializeField]
    private Player player;

    IEnumerator Loop()
    {
        yield return new WaitForSeconds(5f);
        float random = UnityEngine.Random.Range(0, 1);
        switch(player.State)
        {
            case Player.PlayerState.AtExam: yield break;
            case Player.PlayerState.Inactive: yield break;
            case Player.PlayerState.InTown:
                {
                    switch(random)
                    {
                        case float i when i > robOddStart && i <= robOddEnd: Debug.Log("Opljackan si"); break;
                        case float i when i > breakupOddStart && i <= breakupOddEnd && player.HasGf: Debug.Log("Raskinula riba s tobom"); break;
                        case float i when i > crashOddStart && i <= crashOddEnd: Debug.Log("Slupao se auto u tebe"); break;
                    }
                    break;
                }
            case Player.PlayerState.AtWork:
                {
                    if (random > injuryOddStart && random <= injuryOddEnd) Debug.Log("Povredio si se na poslu");
                    break;
                }
            case Player.PlayerState.Studying:
                {
                    if (random > powerOddStart && random <= powerOddEnd) Debug.Log("Nestalo struje dok ucis");
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
