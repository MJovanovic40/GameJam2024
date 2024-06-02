using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Work : MonoBehaviour
{
    [SerializeField]
    private float timeToPrepare = 3f;

    [SerializeField]
    private Image errorImage;

    [SerializeField]
    private AudioClip orderSucc;

    private string combination = "";

    private AudioSource audioSrc;

    private Dictionary<string, string> recipes = new Dictionary<string, string>
    {
        {"rdllu", "burger"}, {"rdurr", "donut"}, {"ulldl", "cake"}, {"drrru", "cupcake"}, {"ururl", "pancakes"}, {"ruldl", "milkshake"}
    };

    private Dictionary<int, string> orders = new Dictionary<int, string>();
    private Dictionary<int, GuestController> seats = new Dictionary<int, GuestController>();

    private string currentCarriedItem = "";
    
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        //InvokeRepeating("CreateOrder", 0f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentCarriedItem.Length > 0)
        {
            HandleDeliverInput();
            return;
        }
        HandleCombinationInput();

        FadeOutErrorImage();
    }

    void HandleCombinationInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            combination += "u";
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            combination += "d";
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            combination += "l";
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            combination += "r";
        }
        CheckCombination();

    }

    void HandleDeliverInput()
    {
        foreach(char c in Input.inputString)
        {
            if (!char.IsDigit(c) || currentCarriedItem.Length == 0) return;
            int position = int.Parse(c.ToString());
            if (position <= 0 || position > 5) return;
            DeliverOrder(position);
        }
    }

    void CheckCombination()
    {
        string[] recipeKeys = recipes.Keys.ToArray();

        foreach (string key in recipeKeys)
        {
            if(key.Equals(combination))
            {
                HandleSuccessfulRecipe(key);
                return;
            }
            if(key.StartsWith(combination))
            {
                return;
            }
        }
        HandleWrongCombination();
    }

    void HandleSuccessfulRecipe(string recipe)
    {
        combination = "";
        string[] orderList = orders.Values.ToArray();

        //Recipe is successful
        string order = recipes[recipe];
        Debug.Log(order);

        if (!orderList.Contains(order))
        {
            HandleNonExistentOrder();
            return;
        }

        currentCarriedItem = order;
    }

    void HandleNonExistentOrder()
    {
        Debug.Log("Order does not exist.");
        DisplayErrorImage();
    }

    void HandleWrongCombination()
    {
        Debug.Log("Wrong combination.");
        Debug.Log(combination);
        combination = "";
        DisplayErrorImage();
    }

    void DeliverOrder(int position)
    {
        if (currentCarriedItem.Length == 0) return;
        if (!(orders.ContainsKey(position) && orders[position].Equals(currentCarriedItem)))
        {
            HandleWronglyDeliveredOrder();
            return;
        }
        Debug.Log("Successfully Delivered to position: " + position);
        HandleSuccessfullyDeliveredOrder(position);
    }

    void HandleSuccessfullyDeliveredOrder(int position)
    {
        Debug.Log("Order delivered successfully.");
        currentCarriedItem = "";
        seats[position].FinishOrder();
        seats.Remove(position);
        orders.Remove(position);
        audioSrc.clip = orderSucc;
        audioSrc.Play();
    }
    void HandleWronglyDeliveredOrder()
    {
        Debug.Log("Delivered to wrong position.");
        currentCarriedItem = "";
        DisplayErrorImage();
    }

    public string CreateOrder(int pos, GuestController reference)
    {
        if (orders.Count == 5 || orders.ContainsKey(pos) || pos > 5 || pos < 0) return ""; // Restaurant is full

        string[] recipesList = recipes.Values.ToArray();
        System.Random rand = new System.Random();

        string choice = recipesList[rand.Next(recipesList.Length)];
        orders.Add(pos, choice);
        seats.Add(pos, reference);
        Debug.Log("Created order: " + choice);
        return choice;
    }

    public string Combination
    {
        get { return combination; }
    }

    public string CurrentCarriedItem
    {
        get { return currentCarriedItem; }
    }

    public bool CheckCombinationForRecipe(string combination, string recipe)
    {
        string[] keys = recipes.Keys.ToArray();

        foreach (string key in keys)
        {
            if(key.StartsWith(combination) && recipes[key].Equals(recipe))
            {
                return true;
            }
        }
        return false;
    }

    void FadeOutErrorImage()
    {
        if(errorImage.color.a > 0)
        {
            Debug.Log(errorImage.color.a);
            errorImage.color = new Color(errorImage.color.r, errorImage.color.g, errorImage.color.b, errorImage.color.a - 0.01f);
        }
    }

    void DisplayErrorImage()
    {
        errorImage.color = new Color(errorImage.color.r, errorImage.color.g, errorImage.color.b, 0.9f);
    }

    public int GetFirstOpenPosition()
    {
        for(int i = 1; i <= 5; i++)
        {
            if(!orders.ContainsKey(i))
            {
                return i;
            }
        }
        return -1;
    }

    public string GetOrderForPosition(int pos)
    {
        return orders.GetValueOrDefault(pos, "");
    }

    public Dictionary<int, GuestController> Seats
    {
        get { return seats; }
    }
}
