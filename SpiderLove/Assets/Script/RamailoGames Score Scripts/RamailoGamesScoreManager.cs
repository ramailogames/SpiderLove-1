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
    public TextMeshProUGUI highScoreTxt_Gameover;


    [HideInInspector]public float currentScore = 0;
    [HideInInspector] public float playedTime = 0;
    bool fetch = true;

    private void OnEnable()
    {
        currentScore = 0;
        playedTime = 0;

        Invoke("FetechData", 0.1f);
    }

    void FetechData()
    {
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
        if(currentScoreTxt_Gameover != null)
        {
            currentScoreTxt_Gameover.text = currentScore.ToString();
        }
        

    }

    private void updateScore()
    {
        highScoreTxt.text = RamailoGamesApiHandler.highScore.ToString();

        if(highScoreTxt_Gameover != null)
        {
            highScoreTxt_Gameover.text = RamailoGamesApiHandler.highScore.ToString();
        }
       
    }

  

}
