using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TIMER : MonoBehaviour
{
    public int minutes, seconds;
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
        timeDisplayed.text = minutes.ToString() + ":" + seconds.ToString();
    }

    void RefreshColour()
    {
        if (minutes <= 0)
        {
            if (seconds >= 30)
            {
                col = Color.green;
                timeDisplayed.color = col;
            }
            else if (seconds >= 15)
            {
                col = Color.yellow;
                timeDisplayed.color = col;
            }
            else if (seconds > 0)
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
        if (seconds <= 49)
        {
            seconds += (int)addTime;
        }
        else
        {
            minutes++;
            seconds += 60 - seconds;
        }
    }

    void DeductTime()
    {
        if (!endingGame)
        {
            if (seconds > 0)
            {
                seconds--;
            }
            else if (minutes > 0)
            {
                minutes--;
                seconds = 59;
            }
            else
            {
                // Trigger HOMELESS END SCREEN
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
        Time.timeScale += 0.2f;

        Debug.Log(Time.timeScale);

        if (Time.timeScale == 1.0f)
        {
            Debug.Log("Resetted Game");
            endingGame = false;
        }
    }

    void SetUp()
    {
        // Create color
        col = new Color();
        col = Color.green;

        // Get UI Text and set color
        timeDisplayed = GetComponent<Text>();
        timeDisplayed.color = col;
    }
}
