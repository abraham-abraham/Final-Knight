using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static TMPro.TextMeshProUGUI timerText;

    public  GameObject timerObject;

    private float secondsCount;
    private int minuteCount;
    private int hourCount;

    private void Start()
    {
      //  timerText = GameObject.Find("Time").GetComponent<TMPro.TextMeshProUGUI>();
        timerText = timerObject.GetComponent<TMPro.TextMeshProUGUI>(); 
    }

    void Update()
    {
        UpdateTimerUI();
    }
    //call this on update
    public void UpdateTimerUI()
    {

        
        //set timer UI
        secondsCount += Time.deltaTime;
        if(timerText != null)
        timerText.text = "Time " + hourCount + ":" + minuteCount + ":" + (int)secondsCount;
        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = 0;
        }
        else if (minuteCount >= 60)
        {
            hourCount++;
            minuteCount = 0;
        }
    }
}
