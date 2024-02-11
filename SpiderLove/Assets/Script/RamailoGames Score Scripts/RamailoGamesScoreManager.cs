using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RamailoGamesScoreManager : MonoBehaviour
{
    [Header("Gui")]
    public TextMeshProUGUI currentScoreTxt;
    public TextMeshProUGUI highScoreTxt;


    [HideInInspector] public float currentScore = 0;
    [HideInInspector] public float playedTime = 0;
    bool fetch = true;

    private void OnEnable()
    {
        currentScore = 0;
        playedTime = 0;

        if (fetch)
        { 
            RamailoGamesApiHandler.UpdateHighScore(updateScore);
        }
        else
        {
            updateScore();
        }
    }

    private void Start()
    {
        currentScore = 0;
        playedTime = 0;

        currentScoreTxt.text = currentScore.ToString();
    }


    public void AddScore(float amount)
    {
        currentScore += amount;

        RamailoGamesApiHandler.AddScore((int)amount);
        currentScoreTxt.text = currentScore.ToString();

    }

    private void updateScore()
    {
        highScoreTxt.text = RamailoGamesApiHandler.highScore.ToString();
    }

  

}
