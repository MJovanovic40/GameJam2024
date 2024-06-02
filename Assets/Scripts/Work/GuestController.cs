using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestController : MonoBehaviour
{

    [SerializeField]
    private GameObject npc;

    [SerializeField]
    private Work work;

    [SerializeField]
    private float delay;

    private Animator animator;

    private int position = -1;

    private string order = "";

    private float[] xPositions = new float[5]
    {
        -7.07f, -4.42f, -0.27f, 2.72f, 6.7f
    };

    private float yFloorPos = -2.42f;

    private float yTopPos = -2f;
    private float xLeftPos = -10.68f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        InvokeRepeating("CheckForOpenSpace", delay, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (position > 0) // Moving to seat
        {
            if (transform.position.x < xPositions[position - 1])
            {
                transform.position = new Vector3(transform.position.x + 0.03f, transform.position.y, transform.position.z);
            }
            else if (transform.position.y < yTopPos)
            {
                if (!animator.GetBool("isClimbing"))
                {
                    animator.SetBool("isWalking", false);
                    animator.SetBool("isClimbing", true);
                }
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.02f, transform.position.z);
            }
            else
            {
                //Handle talking animation
                if (!animator.GetBool("isTalking"))
                {
                    animator.SetBool("isClimbing", false);
                    animator.SetBool("isTalking", true);
                    order = work.CreateOrder(position, this);
                    Debug.Log(order);
                }
            }
        }
        else if (position <= 0) //Should go back
        {
            if (transform.position.y > yFloorPos)
            {
                if (animator.GetBool("isTalking"))
                {
                    animator.SetBool("isTalking", false);
                    animator.SetBool("isClimbing", true);
                }
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.02f, transform.position.z);
            }
            else if (transform.position.x > xLeftPos)
            {
                if (animator.GetBool("isClimbing"))
                {
                    animator.SetBool("isClimbing", false);
                    animator.SetBool("isWalking", true);
                    transform.RotateAround(transform.position, transform.up, 180f);
                }
                transform.position = new Vector3(transform.position.x - 0.03f, transform.position.y, transform.position.z);
            } else if(position == -2)
            {
                transform.RotateAround(transform.position, transform.up, 180f);
                position = -1;
            }
        }
    }

    public void FinishOrder()
    {
        position = -2;
        order = "";
    }

    void CheckForOpenSpace()
    {
        if (position > 0 || transform.position.x > xLeftPos) return;
        int pos = work.GetFirstOpenPosition();
        if (pos == -1) // No free spaces
        {
            return;
        }

        position = pos;
    }

    public string Order
    {
        get { return order; } 
    }

}
