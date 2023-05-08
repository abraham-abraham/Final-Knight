using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    interact,
    attack
}


public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;

    public int score;
    

    [SerializeField]
    float moveSpeed = 5f;
    float moveSpeedMultiplier = 1;

    public GameObject powerUpObject;
    public ParticleSystem powerUp;

    public Rigidbody2D rb;
    public Animator animator;

    public GameObject vaxProjectile;
    public GameObject maskProjectile;
    public GameObject disinfectorProjectile;


    public bool inBoostMode;
    public float boostModeTime = 6;


    public bool cooledDown;
    float coolDownTime = .2f;

    // to carry the input from the Updat() to FixedUpdate()
    Vector2 moveDirection;


    private void Start()
    {
       

        animator.SetFloat("MoveX", 0);
        animator.SetFloat("MoveY", -1);

        cooledDown = true;
    }


    // Update is called once per frame
    void Update()
    {
        // physics calculations
        ProcessInput();
        if (inBoostMode)
        {
            if(powerUp != null)
            {
                if (powerUp.isStopped)
                {
                    powerUp.Play();
                }
            }
            
        }
    }

    private void ProcessInput()
    {
        moveDirection = Vector2.zero;

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // We normalize the moveDirection vector in order to move diagonally at the same speed as vertically or horizontally
        moveDirection = new Vector2(moveX, moveY).normalized;

        if(Input.GetButtonDown("Vaccine Projectile") &&  (cooledDown))
        {

            //print("shooting");
            StartCoroutine(vaxAttackCo(vaxProjectile));
        }
        
        else if(Input.GetButtonDown("Mask Projectile") &&  (cooledDown))
        {

            //print("shooting");
            StartCoroutine(vaxAttackCo(maskProjectile));
        }   
        
        else if(Input.GetButtonDown("Disinfector Projectile") &&  (cooledDown))
        {

            //print("shooting");
            StartCoroutine(vaxAttackCo(disinfectorProjectile));
        }  
        
        else if(Input.GetButtonDown("Power Up") &&  (cooledDown))
        {
            if (!inBoostMode)
            {
                BoostMode();
            }
        }

        UpdateAnimation();

    }



    public void BoostMode()
    {
        if (powerUpObject != null)
        {
            powerUpObject.SetActive(true);
        }
        inBoostMode = true;

        moveSpeedMultiplier =  2;

        Projectile.scoreMultiplier =  2;

        NpcSpawner.spawnTimeMultiplier = 2;

        NPC.scoreLostMultiplier = 2;

        Invoke("BoostDown", 15);

    }

    public void BoostDown()
    {
        if (powerUpObject != null)
        {
            powerUpObject.SetActive(false);
        }
        inBoostMode = false;

        moveSpeedMultiplier = 1;

        Projectile.scoreMultiplier = 1;

        NpcSpawner.spawnTimeMultiplier = 1;

        NPC.scoreLostMultiplier = 1;
    }

    private IEnumerator vaxAttackCo(GameObject projectileType)
    {


        yield return null;
       
        MakePerjectile(projectileType);
        cooledDown = false;

    
        yield return new WaitForSeconds(coolDownTime);
        cooledDown = true;

        
    }

    private void MakePerjectile(GameObject projectileTypy)
    {
        Vector2 temp = new Vector2(animator.GetFloat("MoveX"), animator.GetFloat("MoveY"));

        Projectile vaxProjectile = Instantiate(projectileTypy, transform.position + new Vector3(0, 0.5f, 0) , Quaternion.identity).GetComponent<Projectile>();
        vaxProjectile.Setup(temp, ChooseArrowDirection());
    }


    Vector3 ChooseArrowDirection()
    {
        float temp = Mathf.Atan2(animator.GetFloat("MoveY"), animator.GetFloat("MoveX")) * Mathf.Rad2Deg;
        return new Vector3(0, 0, temp);
    }

    void UpdateAnimation()
    {
        if (moveDirection != Vector2.zero)
        {
            animator.SetFloat("MoveX", moveDirection.x);
            animator.SetFloat("MoveY", moveDirection.y);
        }

        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);

        animator.SetFloat("Speed", moveDirection.sqrMagnitude);
    }


    // called 50 times per second
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // Time.fixedDeltaTime is the amount of time that has elapsed since the function was last called
        rb.velocity = new Vector2(moveDirection.x * moveSpeed * moveSpeedMultiplier, moveDirection.y * moveSpeed);
    }
}
