//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PatrolAntiVaxer : AntiVaxer
//{
//    public Transform[] path;
//    public int currentPoint;
//    public Transform currentGoal;
//    // We dont need the exact position so we will round it
//    public float roundingDistance = 0.1f;

  


//    // We are using the AntiVaxer Start method


//    // the checkDistance is called from the base class FixedUpdate
//    // which mean this checkDistance is called from this class FixedUpdate
//    public override void CheckDistance()
//    {
//        ChangeState(EnemyState.walk);
//        animator.SetBool("Moving", true);

//        if (Vector3.Distance(target.position, transform.position) <= chaseRadius
//         && Vector3.Distance(target.position, transform.position) > attackRadius)

//        {
//            if (currentState == EnemyState.idle
//                || currentState == EnemyState.walk
//                && currentState != EnemyState.stagger)
//            {

//                Vector3 moveVector = Vector3.MoveTowards(transform.position, 
//                                                            target.position, moveSpeed * Time.fixedDeltaTime);
//                ChangeAnimation(moveVector - transform.position);
//                rb.MovePosition(moveVector);

//                // this character will always be in walk state
//                // ChangeState(EnemyState.walk);
//                animator.SetBool("Moving", true);

//            }

//        }

//       else if(Vector3.Distance(target.position, transform.position) <= chaseRadius
//         && Vector3.Distance(target.position, transform.position) < attackRadius){
//            animator.SetBool("Moving", false);
//        }

//        // This can be used to make the Enemy continue walking even if he got in range 
//        // else if (Vector3.Distance(target.position, transform.position) > chaseRadius)

//        else
//        {
//            if(Vector3.Distance(transform.position, 
//                                   path[currentPoint].position) > roundingDistance)
//            {
//                Vector3 moveVector = Vector3.MoveTowards(transform.position, 
//                                                        path[currentPoint].position, 
//                                                            moveSpeed * Time.fixedDeltaTime);

//                ChangeAnimation(moveVector - transform.position);
//                rb.MovePosition(moveVector);
//            }
//            else
//            {
//                ChangeGoal();
//            }

//        }
//    }


//    private void ChangeGoal()
//    {
//        if (currentPoint == path.Length - 1)
//        {
//            currentPoint = 0;
//            currentGoal = path[0];
//        }
//        else
//        {
//            currentPoint++;
//            currentGoal = path[currentPoint];
//        }
//    }
//}