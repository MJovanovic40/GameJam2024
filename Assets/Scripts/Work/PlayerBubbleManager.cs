using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBubbleManager : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private Work work;

    [SerializeField]
    private GameObject burger;

    [SerializeField]
    private GameObject donut;

    [SerializeField]
    private GameObject cake;

    [SerializeField]
    private GameObject cupcake;

    [SerializeField]
    private GameObject pancakes;

    [SerializeField]
    private GameObject milkshake;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x - 0.5f, player.transform.position.y + 3.6f, player.transform.position.z);
        CheckOrderRender();
    }

    void CheckOrderRender()
    {
        burger.GetComponent<SpriteRenderer>().enabled = false;
        donut.GetComponent<SpriteRenderer>().enabled = false;
        cake.GetComponent<SpriteRenderer>().enabled = false;
        cupcake.GetComponent<SpriteRenderer>().enabled = false;
        pancakes.GetComponent<SpriteRenderer>().enabled = false;
        milkshake.GetComponent<SpriteRenderer>().enabled = false;

        if (work.CurrentCarriedItem.Length > 0)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            switch (work.CurrentCarriedItem) 
            {
                case "burger":
                    burger.GetComponent<SpriteRenderer>().enabled = true;
                    break;
                case "donut":
                    donut.GetComponent<SpriteRenderer>().enabled = true;
                    break;
                case "cake":
                    cake.GetComponent<SpriteRenderer>().enabled = true;
                    break;
                case "cupcake":
                    cupcake.GetComponent<SpriteRenderer>().enabled = true;
                    break;
                case "pancakes":
                    pancakes.GetComponent<SpriteRenderer>().enabled = true;
                    break;
                case "milkshake":
                    milkshake.GetComponent<SpriteRenderer>().enabled = true;
                    break;
            }


        } else
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    

}
