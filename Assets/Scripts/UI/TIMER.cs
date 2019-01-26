using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TIMER : MonoBehaviour
{
    private enum timeState
    {
        okay, late, hurry
    }

    [SerializeField]
    private GameObject startingPosition, grumble;
    public int startMinutes, startingSeconds;
    private int currentMinutes, currentSeconds;
    private Text timeDisplayed;
    private Color col;
    [SerializeField]
    private readonly FloatReference addTime;
    private bool endingGame = false, resettingGame = false;
    [SerializeField]
    private float fadeTimeForMusic;
    private timeState currentState, lastState;
   
    void Start()
    {
        SetUp();
        InvokeRepeating("DeductTime", 1.0f, 1.0f);
    }

    void Update()
    {
        RefreshTimeOnUI();
        RefreshColourAndMusic();
        CheckStateAndChangeMusic();

        if (endingGame)
        {
            SlowDownTime();
        }
        else if (resettingGame)
        {
            SpeedUpTime();
        }
    }

    void RefreshTimeOnUI()
    {
        timeDisplayed.text = currentMinutes.ToString() + ":" + currentSeconds.ToString();
    }
    void RefreshColourAndMusic()
    {
        if (currentMinutes <= 0)
        {
            if (currentSeconds >= 30)
            {
                col = Color.green;
                timeDisplayed.color = col;
                currentState = timeState.okay;
            }
            else if (currentSeconds >= 15)
            {
                col = Color.yellow;
                timeDisplayed.color = col;
                currentState = timeState.late;
            }
            else if (currentSeconds > 0)
            {
                col = Color.red;
                timeDisplayed.color = col;
                currentState = timeState.hurry;
            }
            else
            {
                col = Color.black;
                timeDisplayed.color = col;
                currentState = timeState.hurry;
            }
        }
        else
        {
            col = Color.green;
            timeDisplayed.color = col;
            currentState = timeState.okay;
        }
    }

    public void AddTime()
    {
        if (currentSeconds <= 49)
        {
            currentSeconds += (int)addTime;
        }
        else
        {
            currentMinutes++;
            currentSeconds += 60 - currentSeconds;
        }
    }
    void DeductTime()
    {
        if (!endingGame && !resettingGame)
        {
            if (currentSeconds > 0)
            {
                currentSeconds--;
            }
            else if (currentMinutes > 0)
            {
                currentMinutes--;
                currentSeconds = 59;
            }
            else
            {
                //GameObject.Find("HOMELESS").SetActive(true);
                endingGame = true;
            }
        }
    }

    void SlowDownTime()
    {
        Debug.Log("Scaling down time");

        if (endingGame)
        {
            Time.timeScale -= 0.01f;

            if (Time.timeScale <= 0.02f)
            {
                endingGame = false;
                Time.timeScale = 0.02f;
                StartCoroutine(WaitUntilSpeedUp());
            }
        }
    }

    IEnumerator WaitUntilSpeedUp()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        resettingGame = true;
    }

    void SpeedUpTime()
    {
        Debug.Log("Scaling Time back up");

        if (resettingGame)
        {
            Time.timeScale += 0.01f;
            if (Time.timeScale >= 0.98f)
            {
                Time.timeScale = 1.0f;

                ResetPlayerPosition();
                FillUpCurrentTime();
                
                resettingGame = false;
            }
        }
    }

    void ResetPlayerPosition()
    {
        GameObject.FindWithTag("Player").transform.position = startingPosition.transform.position;
    }

    void FillUpCurrentTime()
    {
        currentMinutes = startMinutes;
        currentSeconds = startingSeconds;
    }

    void CheckStateAndChangeMusic()
    {
        if (currentState != lastState)
        {
            if (currentMinutes <= 0)
            {
                if (currentSeconds >= 30)
                {
                    grumble.GetComponent<MUSIC>().ChangeLayer(0, fadeTimeForMusic);
                }
                else if (currentSeconds >= 15)
                {
                    grumble.GetComponent<MUSIC>().ChangeLayer(1, fadeTimeForMusic);
                }
                else if (currentSeconds > 0)
                {
                    grumble.GetComponent<MUSIC>().ChangeLayer(2, fadeTimeForMusic);
                }
                else
                {
                    grumble.GetComponent<MUSIC>().ChangeLayer(2, fadeTimeForMusic);
                }
            }
            else
            {
                grumble.GetComponent<MUSIC>().ChangeLayer(0, fadeTimeForMusic);
            }
            lastState = currentState;
        } 
    }

    void SetUp()
    {
        // Set Time
        currentMinutes = startMinutes;
        currentSeconds = startingSeconds;

        // Set the current and last state
        currentState = timeState.okay;
        lastState = currentState;

        // Create color
        col = new Color();
        col = Color.green;

        // Get UI Text and set color
        timeDisplayed = GetComponent<Text>();
        timeDisplayed.color = col;
    }
}
