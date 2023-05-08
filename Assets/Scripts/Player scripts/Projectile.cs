using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ProjectileType
{
    vax,
    mask,
    disinfector
}

public class Projectile : MonoBehaviour
{
    //public static TMPro.TextMeshProUGUI scoreText;

    //public static int score;

    int gainedScore = 2;

    public static int scoreMultiplier = 1;

    public float speed;
    public Rigidbody2D rb;


    public ProjectileType projectileType;

    float timeLeft = 4;


    // Start is called before the first frame update
    void Start()
    {
        scoreMultiplier = 2;
        
        //scoreText = GameObject.Find("Score").GetComponent<TMPro.TextMeshProUGUI>();

        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        //scoreText.text = "Score " + score.ToString();

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Destroy(this.gameObject);
        }

        
    }

    public void Setup(Vector2 velocity, Vector3 direction)
    {
        rb.velocity = velocity.normalized * speed;
        transform.rotation = Quaternion.Euler(direction);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //print("collided");
        
        if (other.gameObject.CompareTag("NPC"))
        {
            Destroy(this.gameObject);

            if(this.projectileType == ProjectileType.vax) {
                other.GetComponent<NPC>().vaccinated = true;
            } 
            if(this.projectileType == ProjectileType.mask) {
                other.GetComponent<NPC>().masked = true;
            } 
            if(this.projectileType == ProjectileType.disinfector) {
                other.GetComponent<NPC>().infected = false;
            }
            
        }
        
        if (other.gameObject.CompareTag("Corona"))
        {
            Destroy(this.gameObject);

            if (this.projectileType == ProjectileType.disinfector)
            {
                GameManager.score += gainedScore * scoreMultiplier;
                Destroy(other.gameObject);
            }
             
        }
    }
}


