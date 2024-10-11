using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    public float countdownTime = 60f; // Start time
    public TextMeshProUGUI timerText; // Reference to the UI Text element

    public GameManagerX gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the timer text starts at 60
        UpdateTimerText(countdownTime);

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManagerX>();

    }

    // Update is called once per frame
    void Update()
    {
        // Reduce the countdown time
        if (countdownTime > 0 && gameManager.isGameActive)
        {
            countdownTime -= Time.deltaTime;
            UpdateTimerText(Mathf.Round(countdownTime)); // Update the timer display
        }
        else if (countdownTime <= 0 && gameManager.isGameActive)
        {
            // Trigger game over when countdown reaches zero
            GameOver();
        }

    }
    private void UpdateTimerText(float time)
    {
        // Update the TextMeshProUGUI with the current countdown value
        timerText.text = "Time: " + time.ToString();
    }

    private void GameOver()
    {
        
        gameManager.GameOver();
        
       
    }
    public void ResetTimer(float newTime)
    {
        countdownTime = newTime;
        UpdateTimerText(countdownTime);
        gameManager.isGameActive = true; // Ensure the game is active
    }
}
