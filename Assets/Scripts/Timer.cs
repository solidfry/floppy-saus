using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    public float timeRemaining = 120f;
    private float originalTime;
    public Color32 startColor;
    public Color32 endColor;
    public float transitionDuration = 5f;

    [SerializeField]
    public bool timerRunning = false;
    public TMP_Text timeText;
    private void OnEnable()
    {
        GameEvents.OnPreRoundEvent += ResetTimer;
        GameEvents.OnPlayingEvent += StartTimer;
    }

    private void OnDisable()
    {
        GameEvents.OnPreRoundEvent -= ResetTimer;
        GameEvents.OnPlayingEvent -= StartTimer;
    }
    private void Awake()
    {
        originalTime = timeRemaining;
        DisplayTimer(timeRemaining);
    }

    void Update()
    {
        HandleTimer();
    }

    public void StartTimer()
    {
        timerRunning = true;
        timeText.color = startColor;
    }

    void HandleTimer()
    {
        if (timerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTimer(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                SetTimerInactive();
                Debug.Log("Timer is inactive now");
            }
        }

    }

    void DisplayTimer(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        timeText.color = Color32.Lerp(startColor, endColor, Mathf.PingPong(Time.time, transitionDuration) / transitionDuration);

    }

    public void SetTimerInactive()
    {
        timerRunning = false;
        GameEvents.OnTimerZeroEvent?.Invoke();
    }

    public void ResetTimer()
    {
        timeRemaining = originalTime;
        timerRunning = false;
    }
}
