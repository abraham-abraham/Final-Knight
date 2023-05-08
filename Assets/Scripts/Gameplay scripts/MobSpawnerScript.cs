using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawnerScript : MonoBehaviour
{
    

    int npcMaxNumber = GameManager.level * 10;
    int npcNumber = 0;

    float spawnRadius = 7f;


    // difficulty parameters depends on the level

    public static int spawnTimeMultiplier;

    int minProbabilityRange = 0;
    int maxProbabilityRange = GameManager.level * GameManager.difficultyStep;

    // with each level the spawn time decrease
    public static float spawnTime = 2 - GameManager.level;



    // in the first level with a difficulty step of 10 we have a 10% chance of the initiated NCP getting a bad state
    // in second level the chance is 20% of getting unwanted state
    bool StateRandomizer()
    {
        int i = Random.Range(0, 100);

        {
            if (i >= minProbabilityRange && i < maxProbabilityRange)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }


    // array of NPCs to spawn
    public GameObject[] nPCs;


    // Start is called before the first frame update
    void Start()
    {
        

        spawnTimeMultiplier = 1;

        if (npcNumber <= npcMaxNumber)
        {
           // print("spawned at start\n" + "current: " + npcNumber + "\nmax: " + npcMaxNumber);

            StartCoroutine(spawnAnNPC());
        }


    }

    private void Update()
    {
      //  levelText.text = "Level " + GameManager.level.ToString();


        minProbabilityRange = 0;
        maxProbabilityRange = GameManager.level * GameManager.difficultyStep;

        // with each level the spawn time decrease
        spawnTime = Random.Range(10 - GameManager.level, 15 - GameManager.level) * spawnTimeMultiplier;
    }

    IEnumerator spawnAnNPC()
    {

        Vector2 spawnPosition = transform.position;
        spawnPosition += Random.insideUnitCircle.normalized * spawnRadius;

        if (npcNumber < npcMaxNumber)
        {

            GameObject npc = Instantiate(nPCs[Random.Range(0, nPCs.Length)], spawnPosition, Quaternion.identity);

            npcNumber++;

            //  print("npcNumber: " + npcNumber + "npcMaxNumber: " + npcMaxNumber);


            // properties of spawned NPCs

            // Speed and time properties of spawned NPCs
            npc.GetComponent<NpcController>().moveSpeed = Random.Range(GameManager.level + 2, GameManager.level + 4);
            npc.GetComponent<NpcController>().moveTime = Random.Range(GameManager.level + 2, GameManager.level + 4);
            npc.GetComponent<NpcController>().idleTime = Random.Range(GameManager.level + 2, GameManager.level + 4);


            npc.GetComponent<NPC>().coolDownTime = Random.Range(5 - GameManager.level, 10 - GameManager.level);



            // health and protection properties of spawned NPCs
            npc.GetComponent<NPC>().infected = StateRandomizer();

            if (!npc.GetComponent<NPC>().infected)
            {
                npc.GetComponent<NPC>().susceptible = StateRandomizer();
            }

            // since vaccinated and masked NPCs will make the game easier we revierce the odds for it
            if (!npc.GetComponent<NPC>().infected && !npc.GetComponent<NPC>().susceptible)
            {
                npc.GetComponent<NPC>().vaccinated = StateRandomizer();
                npc.GetComponent<NPC>().masked = StateRandomizer();
            }

        }

        yield return new WaitForSeconds(spawnTime);
        StartCoroutine(spawnAnNPC());
    }
}
