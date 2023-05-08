using UnityEngine;
using UnityEngine.InputSystem;

// Takes and handles input and movement for a player character
public class PlayerController : MonoBehaviour
{

    bool isMoving = false;
    private bool canMove = true;
    [SerializeField]
    float moveSpeed = 150f;
    [SerializeField]
    float maxSpeed = 3.5f;


    // Each frame of physics, what percentage of speed should be shaved of velocety out of 1 (100%)
    public float idleFriction = 0.9f;

    Rigidbody2D rb;

    Animator animator;
    SpriteRenderer spriteRenderer;
    Vector2 moveInput = Vector2.zero;
    public bool isRunning = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    bool IsMoving
    {
        set
        {
            isMoving = value;
            animator.SetBool("isMoving", isMoving);
            //animator.SetBool("isRunning", !isMoving);
            maxSpeed = 3.5f;
        }
    }

    bool IsRunning
    {
        set
        {
            //isRunning = value;
            animator.SetBool("isRunning", isRunning);
            //animator.SetBool("isMoving", !isRunning);
            maxSpeed = 4f;
        }
    }


    private void FixedUpdate()
    {

        // If movement input is not 0, try to move
        if (canMove == true && moveInput != Vector2.zero)
        {
            // move animation and add velocety

            // Accelerate the player while run direction is pressed
            // But don't allow player to run faster than the max speed in any direction

            rb.velocity = Vector2.ClampMagnitude(rb.velocity + (moveInput * moveSpeed * Time.deltaTime), maxSpeed);

            // control whether looking left or right

            if (moveInput.x > 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (moveInput.x < 0)
            {
                spriteRenderer.flipX = true;
            }

            if (isRunning)
            {
                IsRunning = true;
                animator.SetBool("isMoving", false);
                animator.SetBool("isRunning", true);
            }
            else
            {
                IsRunning = false;
                animator.SetBool("isMoving", true);
                animator.SetBool("isRunning", false);
            }


        }
        else
        {
            // No movement so interpolate velocity towards 0
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, idleFriction);
            IsMoving = false;
            IsRunning = false;
            animator.SetBool("isRunning", false);
        }

    }



    // Get input values for the player movement
    void OnMove(InputValue movementValue)
    {
        moveInput = movementValue.Get<Vector2>();
    }




    void OnFire()
    {
        animator.SetTrigger("swordAttack");
    }


    //void UpdateAnimatorParameters()
    //{
    //    animator.SetBool("isMoving", isMoving);
    //}






    void OnRun()
    {
        isRunning = !isRunning;
        print("isRunning" + isRunning);
    }

    //public void SwordAttack()
    //{
    //    //LockMovement();

    //    if (spriteRenderer.flipX == true)
    //    {
    //        swordAttack.AttackLeft();
    //    }
    //    else
    //    {
    //        swordAttack.AttackRight();
    //    }
    //}

    //public void EndSwordAttack()
    //{
    //    //UnlockMovement();
    //    swordAttack.StopAttack();
    //}

    public void LockMovement()
    {
        canMove = false;
        print("can move false");
    }

    public void UnlockMovement()
    {
        canMove = true;
        print("can move true");
    }



    //private bool TryMove(Vector2 direction)
    //{
    //    if (direction != Vector2.zero)
    //    {
    //        // Check for potential collisions
    //        int count = rb.Cast(
    //            direction, // X and Y values between -1 and 1 that represent the direction from the body to look for collisions
    //            movementFilter, // The settings that determine where a collision can occur on such as layers to collide with
    //            castCollisions, // List of collisions to store the found collisions into after the Cast is finished
    //            moveSpeed * Time.fixedDeltaTime + collisionOffset); // The amount to cast equal to the movement plus an offset
    //        Vector3 start = new Vector3(rb.position.x, rb.position.y, 0);
    //        Vector3 end = start + new Vector3(direction.x, direction.y, 0) * (moveSpeed * Time.fixedDeltaTime + collisionOffset);
    //        Debug.DrawLine(start, end, Color.red, 5f);

    //        //foreach (var hit in castCollisions)
    //        //{
    //        //    print("Collided with: " + hit.collider.gameObject.name);
    //        //}

    //        if (count == 0)
    //        {
    //            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    //            return true;
    //        }
    //        else
    //        {
    //         //   print("cant move");
    //            return false;
    //        }
    //    }
    //    else
    //    {
    //        // Can't move if there's no direction to move in
    //        return false;
    //    }

    //}


}
