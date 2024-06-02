using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ArrowManager : MonoBehaviour
{
    [SerializeField]
    private char direction;

    [SerializeField]
    private int index;

    [SerializeField]
    private GameObject workManager;

    [SerializeField]
    private string recipe;

    private Work workScript;


    // Start is called before the first frame update
    void Start()
    {
        workScript = workManager.GetComponent<Work>();
        GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        string combination = workScript.Combination;
          
        if (index > combination.Length - 1)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            return;
        };

        if (combination[index] == direction && workScript.CheckCombinationForRecipe(combination, recipe))
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else 
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }

    }
}
