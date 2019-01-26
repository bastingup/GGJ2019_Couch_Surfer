using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TIMER : MonoBehaviour
{
    public int startMinutes, startingSeconds;
    private int currentMinutes, currentSeconds;
    private Text timeDisplayed;
    private Color col;
    [SerializeField]
    private readonly FloatReference addTime;
    private bool endingGame = false;

    void Start()
    {
        SetUp();
        InvokeRepeating("DeductTime", 1.0f, 1.0f);
    }
    

    void Update()
    {
        RefreshTimeOnUI();
        RefreshColour();
    }

    void RefreshTimeOnUI()
    {
        timeDisplayed.text = currentMinutes.ToString() + ":" + currentSeconds.ToString();
    }

    void RefreshColour()
    {
        if (currentMinutes <= 0)
        {
            if (currentSeconds >= 30)
            {
                col = Color.green;
                timeDisplayed.color = col;
            }
            else if (currentSeconds >= 15)
            {
                col = Color.yellow;
                timeDisplayed.color = col;
            }
            else if (currentSeconds > 0)
            {
                col = Color.red;
                timeDisplayed.color = col;
            }
            else
            {
                col = Color.black;
                timeDisplayed.color = col;
            }
        }
        else
        {
            col = Color.green;
            timeDisplayed.color = col;
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
        if (!endingGame)
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
                GameObject.Find("HOMELESS").SetActive(true);
                endingGame = true;
                SlowDownTime();
            }
        }
    }

    void SlowDownTime()
    {
        while (true)
        {
            Time.timeScale -= 0.01f;

            Debug.Log(Time.timeScale);

            if (Time.timeScale == 0.0f)
            {
                ResetGame();
            }
        }
    }

    void ResetGame()
    {
        Time.timeScale += 0.01f;

        Debug.Log(Time.timeScale);

        if (Time.timeScale == 1.0f)
        {
            Debug.Log("Resetted Game");
            endingGame = false;
        }
    }

    void SetUp()
    {
        // Set Time
        currentMinutes = startMinutes;
        currentSeconds = startingSeconds;

        // Create color
        col = new Color();
        col = Color.green;

        // Get UI Text and set color
        timeDisplayed = GetComponent<Text>();
        timeDisplayed.color = col;
    }
}
