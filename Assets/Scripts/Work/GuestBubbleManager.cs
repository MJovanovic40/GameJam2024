using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GuestBubbleManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GuestController guestController;

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
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 3, player.transform.position.z);
        CheckOrderRender();
    }

    void CheckOrderRender()
    {
        if (guestController.Order.Length > 0)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            switch (guestController.Order)
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
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
            burger.GetComponent<SpriteRenderer>().enabled = false;
            donut.GetComponent<SpriteRenderer>().enabled = false;
            cake.GetComponent<SpriteRenderer>().enabled = false;
            cupcake.GetComponent<SpriteRenderer>().enabled = false;
            pancakes.GetComponent<SpriteRenderer>().enabled = false;
            milkshake.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
