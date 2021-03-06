﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TIMER : MonoBehaviour
{
    public enum timeState
    {
        okay, late, hurry
    }

    [SerializeField]
    private GameObject startingPosition, grumble;
    public int startMinutes, startingSeconds, currentMinutes, currentSeconds;
    private Text timeDisplayed;
    private Color col;
    [SerializeField]
    private readonly FloatReference addTime;
    private bool endingGame = false, resettingGame = false;
    [SerializeField]
    private float fadeTimeForMusic;
    public timeState currentState, lastState;
    private bool deductTime;
    private Quaternion startRotation = Quaternion.Euler(0,-270,0);

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
    }

    void RefreshTimeOnUI()
    {
        if (currentMinutes < 10)
        {
            timeDisplayed.text = "0" + currentMinutes.ToString();
        }
        else if (currentMinutes >= 10)
        {
            timeDisplayed.text = currentMinutes.ToString();
        }

        timeDisplayed.text += ":";

        if (currentSeconds < 10)
        {
            timeDisplayed.text += "0" + currentSeconds.ToString();
        }
        else if (currentSeconds >= 10)
        {
            timeDisplayed.text += currentSeconds.ToString();
        }
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
            currentSeconds += 10;
        }
        else
        {
           currentMinutes++;
           currentSeconds = 60 - currentSeconds;
        }
    }
    void DeductTime()
    {
        if (deductTime)
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
                StartCoroutine(Homeless());
                
            }
        }
    }

    public void Kill()
    {
        StartCoroutine(Homeless());
    }

    private IEnumerator Homeless()
    {
        FindObjectOfType<UISounds>().PlayHomelessSound();

        deductTime = false;

        float fadeTime = 1;
        float staySlowTime = 2.5f;
        float slowTimeScale = 0.1f;

        FindObjectOfType<HomelessScreen>().FadeIn();
        DOTween.To(scale => Time.timeScale = scale, Time.timeScale, slowTimeScale, fadeTime).timeScale=1;
        yield return new WaitForSecondsRealtime(fadeTime);

        yield return new WaitForSecondsRealtime(staySlowTime);

        DOTween.To(scale => Time.timeScale = scale, Time.timeScale, 1, fadeTime).timeScale = 1;
        FindObjectOfType<HomelessScreen>().FadeOut();
        yield return new WaitForSecondsRealtime(fadeTime);

        deductTime = true;
        resettingGame = true;
        ResetPlayerPosition();
        FillUpCurrentTime();
        ResetGameState();
    }

    private void ResetGameState()
    {
        FindObjectOfType<EventsMaster>().ResetEvents();
        FindObjectOfType<Mission>().ResetMission();
        RotatePlayerBackUp();
    }

    void ResetPlayerPosition()
    {
        FindObjectOfType<SofaController>().transform.position = startingPosition.transform.position;
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

    void RotatePlayerBackUp()
    {
        FindObjectOfType<SofaController>().transform.rotation = Quaternion.Euler(0, -270, 0);
    }

    void SetUp()
    {
        // Set Time
        currentMinutes = startMinutes;
        currentSeconds = startingSeconds;
        deductTime = true;

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
