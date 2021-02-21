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

        //Check if mouse was clicked
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Checks under mouse
            if (Physics.Raycast(ray, out hit, 5000.0f))
            {
                //If brick was hit, destroy it
                if (hit.transform.CompareTag("Brick"))
                {
                    Destroy(hit.transform.gameObject);
                }
                
                //If question box was hit, add coins
                if (hit.transform.CompareTag("Question"))
                {
                    coins += 10;
                    coinText.text = coins.ToString();
                }
            }
        }
    }
}
