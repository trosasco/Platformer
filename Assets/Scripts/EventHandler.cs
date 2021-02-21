using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventHandler : MonoBehaviour
{

    public Text timeText;
    public Text worldText;
    public Text coinText;
    public Text pointText;
    
    public int startingTime = 400;
    private int timeRemaining;
    private float time;

    private int coins = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        time = startingTime;
        worldText.text = "1-1";
        pointText.text = "00000";
        coinText.text = coins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //Countdown remaining time
        if (time > 0)
        {
            time -= Time.deltaTime;
            timeRemaining = Mathf.RoundToInt(time);
            timeText.text = timeRemaining.ToString();
        }
    }
}
