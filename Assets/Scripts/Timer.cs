using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI m_timeText;
    [SerializeField]private GamerEvent OnGameOver;
    [SerializeField]private GamerEvent OnTimerOver;
    [SerializeField]private GamerEvent OnWinGame;
    private bool timeIsRunning = false;
    [SerializeField]private float timeRemaining = 60.0f;

    private void Start() 
    {
        timeIsRunning = true;    
    }

    private void Update()
    {
        if(timeIsRunning)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timeIsRunning = false;
                OnTimerOver.Raise();
            }
        }
    }
    public void DisplayTime (float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60.0f);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60.0f);
        m_timeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2.0f);
        OnGameOver.Raise();
    }

    public void EndGame()
    {
        StartCoroutine(GameOver());
    }

    IEnumerator WinGame()
    {
        yield return new WaitForSeconds(2.0f);
        OnWinGame.Raise();
    }

    public void NewLevel()
    {
        StartCoroutine(WinGame());
    }
}
