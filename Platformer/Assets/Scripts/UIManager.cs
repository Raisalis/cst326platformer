using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text scoreText;
    public TMP_Text coinText;
    public TMP_Text worldText;
    int coins;
    int score;
    int time;

    // Start is called before the first frame update
    void Start()
    {
        coins = 0;
        score = 0;
        time = 300;
    }

    // Update is called once per frame
    void Update()
    {
        // Updates the timer text based on time passed since the game started.
        // NOTE: May need to change to account for a start screen. Or changing levels.
        timerText.text = String.Format("{0}", (int)(time - Time.fixedTime));
    }

    // Function that increases the score when called.
    void addScore(int change)
    {
        score += change;
        if(score < 0) {
            score = 0;
        }
        scoreText.text = String.Format("{000000}", score);
    }

    // Function to add/subtract coins from the UI.
    void addCoins(int change)
    {
        coins += change;
        if(coins < 0) {
            coins = 0;
        }
        coinText.text = String.Format("X{00}", coins);
    }

    // Function to change the World Text on level change.
    void updateWorld(int world, int level)
    {
        worldText.text = String.Format("{0}-{0}", world, level);
    }
}
