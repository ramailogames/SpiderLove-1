using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RamailoGamesScoreManager : MonoBehaviour
{
    [Header("Gui")]
    public TextMeshProUGUI currentScoreTxt;
    public TextMeshProUGUI currentScoreTxt_Gameover;
    public TextMeshProUGUI highScoreTxt;


    private float currentScore = 0;
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

        currentScoreTxt.text = currentScore.ToString() + " M";
        currentScoreTxt_Gameover.text = currentScore.ToString() + " M";
    }


    public void AddScore(float amount)
    {
        currentScore += amount;

        RamailoGamesApiHandler.AddScore((int)amount);
        currentScoreTxt.text = currentScore.ToString() + " M";
        currentScoreTxt_Gameover.text = currentScore.ToString() + " M";

    }

    private void updateScore()
    {
        highScoreTxt.text = RamailoGamesApiHandler.highScore.ToString();
    }

  

}
