using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMovement : MonoBehaviour
{

    public float moveSpeed;
    Rigidbody2D rb;
    protected Animator animator;

    private bool isWalking;

    public float walkTime;
    private float walkTimeCounter;



    public float waitTime;
    private float waitTimeCounter;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        waitTimeCounter = waitTime;
        walkTimeCounter = walkTime; 

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
