//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class AntiVaxer : Enemy
//{

    
//    public ParticleSystem virusEffect;

//    protected Rigidbody2D rb;
//    [SerializeField]
//    protected Animator animator;
//    public int health;
//    public float moveSpeed;
//    public string npcName;
//    public int baseAttack;


//    // Start is called before the first frame update
//    void Start()
//    {
        
//        virusEffect = GetComponentInChildren<ParticleSystem>();
//        rb = GetComponent<Rigidbody2D>();
//        animator = GetComponent<Animator>();
//        target = GameObject.FindWithTag("Player").transform;
//        currentState = EnemyState.idle;
//    }

//    // Update is called once per frame
//    void FixedUpdate()
//    {
//        CheckDistance();
        
//    }

//    private void Update()
//    {
//        if(virusEffect != null) { 
//        if (virusEffect.isStopped)
//            virusEffect.Play();
//        }
//    }

//    // virtual means I will override it from a class that inherets from it
//    // unless it is overreddin it will be used
//    public virtual void CheckDistance()
//    {
//        if (Vector3.Distance(target.position, transform.position) <= chaseRadius
//         && Vector3.Distance(target.position, transform.position) > attackRadius)

//        {
//            if (currentState == EnemyState.idle 
//                || currentState == EnemyState.walk
//                && currentState != EnemyState.stagger)
//            {

//                Vector3 moveVector = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.fixedDeltaTime);
//                ChangeAnimation(moveVector - transform.position);
//                rb.MovePosition(moveVector);
                

//                ChangeState(EnemyState.walk);
//                animator.SetBool("Moving", true);

//            }
            
//        }

//        // This can be used to make the Enemy continue walking even if he got in range 
//        // else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        
//        else
//        {

//            // need different idle animations for different stopping directions
//            animator.SetBool("Moving", false);
//        } 
//    }

//    // I need to ask about this function as I do not fully understand it
//    private void SetAnimationFloat(Vector2 setVector)
//    {
//        animator.SetFloat("MoveX", setVector.x);
//        animator.SetFloat("MoveY", setVector.y);
//    }

//    protected void ChangeAnimation(Vector2 directon)
//    {
//        if (Mathf.Abs(directon.x) > Mathf.Abs(directon.y))
//        {
//            if (directon.x > 0)
//            {

//                //animator.SetFloat("MoveY", 1);
//                SetAnimationFloat(Vector2.right);
//            }
//            else if (directon.x < 0)
//            {
//                //animator.SetFloat("MoveY", -1);
//                SetAnimationFloat(Vector2.left);
//            }
//        }
//        else if (Mathf.Abs(directon.x) < Mathf.Abs(directon.y))
//        {
//            if (directon.y > 0)
//            {
//                SetAnimationFloat(Vector2.up);
//            }
//            else if (directon.y < 0)
//            {
//                SetAnimationFloat(Vector2.down);
//            }

//        }
//    }

//    protected void ChangeState(EnemyState newState) 
//    { 
//    if (currentState != newState)
//        {
//            currentState = newState;
//        }

//    }
//}
