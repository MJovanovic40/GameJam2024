using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public enum PlayerState
    {
        Inactive, //pre nego sto se upali minigejm/dok je idle, ako treba
        AtWork, //na poslu
        AtExam, //na ispitu
        Studying, //uci minigejm
        InTown //u gradu se seta
    }

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

    [SerializeField]
    private PlayerState currentState;

    [SerializeField]
    private bool hasGf;

    [SerializeField]
    private int examPrepPercent = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.health = StatsPersistManager.health;
        this.stamina = StatsPersistManager.stamina;
        this.name = "Cico";
        gameObject.name = "Cico";
        this.money = StatsPersistManager.money;
        this.focus = StatsPersistManager.focus;
        this.examPrepPercent = StatsPersistManager.examPrepPercent;
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

    public bool HasGf
    {
        get { return hasGf; }
        set { hasGf = value; }
    }

    public PlayerState State
    {
        get { return currentState; }
        set { currentState = value; }
    }

    public int ExamPrep
    {
        get { return examPrepPercent; }
        private set
        {
            examPrepPercent = Mathf.Clamp(value, 0, 100);
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

    public void IncrementPrep()
    {
        ExamPrep += 25;
    }

    public void ResetPrep()
    {
        ExamPrep = 0;
    }

    public void IncrementHealth(int amount) 
    { Health += amount; }
    public void DecrementHealth(int amount)
    {
        if (Health - amount < 0)
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
    public void DecrementFocus(int amount)
    { Focus -= amount; }
}
