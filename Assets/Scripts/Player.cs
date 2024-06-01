using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private int health;
    [SerializeField]
    private int stamina;
    [SerializeField]
    private string name;
    [SerializeField]
    private float money;
    [SerializeField]
    private int focus;

    // Start is called before the first frame update
    void Start()
    {
        this.health = 100;
        this.stamina = 100;
        this.name = "Cico";
        gameObject.name = "Cico";
        this.money = 1000.0f;
        this.focus = 100;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Getters and setters
    public int Health 
    { 
        get { return health; }
        private set 
        { 
            health = Mathf.Clamp(value, 0, 100); 
        }
    }
    public int Stamina 
    { 
        get { return stamina; }
        private set
        {
            stamina = Mathf.Clamp(value, 0, 100);
        }
    }
    public string Name { get { return name; } }
    public float Money 
    { 
        get { return money; } 
        set { money = value; }
    }
    public int Focus 
    { 
        get { return focus; } 
        private set
        {
            focus = Mathf.Clamp(value, 0, 100);
        }
    }

    // State management
    public void IncrementHealth(int amount) 
    { Health += amount; }
    public void DecrementHealth(int amount)
    {
        if (Health - amount < 100)
        {
            // Handle Player death
            return;
        }
        Health -= amount;
    }
    public void IncrementStamina(int amount)
    { stamina += amount; }
    public void DecrementStamina(int amount)
    {
        if (Stamina - amount < 0)
        {
            //TODO: Decrement health
            DecrementHealth(1);
            return;
        }
        stamina -= amount; 
    }
    public void IncrementMoney(float amount)
    { Money += amount; }
    public void DecrementMoney(float amount)
    { Money -= amount; }
    public void IncrementFocus(int amount)
    { Focus += amount; }
    public void DecrementFocus(int ammount)
    { Focus -= ammount; }
}
