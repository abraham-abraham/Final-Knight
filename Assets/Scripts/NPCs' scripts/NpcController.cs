using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    Rigidbody2D rb;
    protected Animator animator;


    public float moveSpeed;

    public bool isMoving;

    public float moveTime;
    public float moveTimeCounter;

    public float idleTime;
    public float idleTimeCounter;


    public Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        idleTimeCounter = idleTime;
        moveTimeCounter = moveTime;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    // movement handling

    void move()
    {
        if (isMoving)
        {
            animator.SetBool("Moving", true);
            moveTimeCounter -= Time.deltaTime;

            Vector3 moveVector = Vector3.MoveTowards(transform.position, moveDirection, moveSpeed * Time.fixedDeltaTime);
            ChangeAnimation(moveDirection - transform.position);
            rb.MovePosition(moveVector);

            if (moveTimeCounter < 0)
            {
                isMoving = false;
                idleTimeCounter = idleTime;

            }
        }
        else
        {
            animator.SetBool("Moving", false);
            rb.velocity = Vector2.zero;

            idleTimeCounter -= Time.deltaTime;
            if (idleTimeCounter < 0)
            {
                isMoving = true;
                moveTimeCounter = moveTime;
                moveDirection = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), 0);

            }
        }
    }

    // animation handling

    private void SetAnimationFloat(Vector2 setVector)
    {
        animator.SetFloat("MoveX", setVector.x);
        animator.SetFloat("MoveY", setVector.y);
    }

    void ChangeAnimation(Vector2 directon)
    {
        if (Mathf.Abs(directon.x) > Mathf.Abs(directon.y))
        {
            if (directon.x > 0)
            {

                //animator.SetFloat("MoveY", 1);
                SetAnimationFloat(Vector2.right);
            }
            else if (directon.x < 0)
            {
                //animator.SetFloat("MoveY", -1);
                SetAnimationFloat(Vector2.left);
            }
        }
        else if (Mathf.Abs(directon.x) < Mathf.Abs(directon.y))
        {
            if (directon.y > 0)
            {
                SetAnimationFloat(Vector2.up);
            }
            else if (directon.y < 0)
            {
                SetAnimationFloat(Vector2.down);
            }

        }
    }

    
}
