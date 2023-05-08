using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownTimer : MonoBehaviour
{

    float currentTime = 0;
    float StartingTime = 10f;



    // Start is called before the first frame update
    void Start()
    {
        currentTime = StartingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
    }
}
