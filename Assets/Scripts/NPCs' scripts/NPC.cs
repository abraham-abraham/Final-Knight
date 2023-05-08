using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NPC : MonoBehaviour
{

    public bool infected;
    public bool masked;
    public bool susceptible;
    public bool vaccinated;

    public ParticleSystem virusEffect;

    public GameObject virusObject;
    public GameObject mask;
    public GameObject vax;
    public GameObject graveStone;

    public GameObject VirusPool;

    public bool isCooledDown;

    public float coolDownTime;
    public float coolDownTimeCounter;
    
    public float waitTime;
    public float waitTimeCounter;

    int scoreLost = 1;
    public static int scoreLostMultiplier = 1;


    void CheckMasked()
    {
        if (masked == false)
        {
            if (mask != null)
            {
                mask.SetActive(false);
            }
        }
        else
        {
            if (mask != null)
            {
                mask.SetActive(true);
            }
                
        }
    }

    void CheckSusceptible()
    {
        if (susceptible == false)
        {
            if (graveStone != null)
            {
                graveStone.SetActive(false);
            }

        }
        else if (susceptible == true)
        {
            if (graveStone != null)
            {
                graveStone.SetActive(true);
            }
                
        }

    }

    void CheckInfected()
    {
        if (infected == false)
        {
            if (virusObject != null)
            {
                virusObject.SetActive(false);
            }
                
        }
        else if (infected == true)
        {
            if (virusObject != null)
            {
                virusObject.SetActive(true);
            }
                
        }
    }

    void CheckVaccinated()
    {
        if (!vaccinated)
        {
            if (vax != null)
            {
                vax.SetActive(false);
            }
        }

        else if (vaccinated)
        {
            if (vax != null)
            {
                vax.SetActive(true);
            }
                    
        }  
    }


    void Start()
    {
        coolDownTimeCounter = coolDownTime;
        waitTimeCounter = waitTime;
      //  virusEffect = GetComponentInChildren<ParticleSystem>();

        CheckMasked();

        CheckSusceptible();

        CheckVaccinated();

        CheckInfected();

        StartCountDown();
    }

    void StartCountDown()
    {
        coolDownTimeCounter -= Time.deltaTime;
    }


    void loopVirusEffect()
    {
        if (virusEffect != null)
        {
            if (virusEffect.isStopped)
                virusEffect.Play();
        }
    }


    void Update()
    {

        loopVirusEffect();


        CheckMasked();

        CheckSusceptible();

        CheckInfected();

        CheckVaccinated();


        if (infected)
        {
            SpreadVirus();
        }

    }

    private void SpreadVirus()
    {
        coolDownTimeCounter -= Time.deltaTime;

        if (isCooledDown)
        {
            isCooledDown = false;

            GameManager.score = GameManager.score - (scoreLost * scoreLostMultiplier);
            Instantiate(VirusPool, transform.position, Quaternion.identity);
        }
        
        else if (coolDownTimeCounter < 0)
        {
            isCooledDown = true;
            coolDownTimeCounter = coolDownTime;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Corona"))
        {
            if (!vaccinated) 
            { 
            infected = true;
            }
        }

    }
}
