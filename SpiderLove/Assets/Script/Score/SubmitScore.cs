using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RamailoGames;
using TMPro;

public class SubmitScore : MonoBehaviour
{
    public RamailoGamesScoreManager scoreManager;
    public GameObject playAgainBtn;
    public TextMeshProUGUI playAndWinTryAgainText;
  
    private void OnEnable()
    {
        RamailoGamesApiHandler.SubmitScore(FindObjectOfType<Timer>().playedTime);

        if (ScoreAPI.instance.playAndWin)
        {
            if (scoreManager.currentScore > DataManager.instance.play_and_win_leading_score)
            {
                Debug.Log("You win and beat Play and win leading score");
                playAgainBtn.SetActive(false);
                FindObjectOfType<RamailoGamesApiHandler>().claimBtn.SetActive(true);
            }
            else
            {
                Debug.Log("Try again");
                playAndWinTryAgainText.text = "Only " + (int)(DataManager.instance.play_and_win_leading_score - FindObjectOfType<RamailoGamesScoreManager>().currentScore) + " points from Winning " + DataManager.instance.rewardAmount;


            }
            FindObjectOfType<RamailoGamesApiHandler>().SetAttempts();
        }

        DataManager.instance.UpdateAttempt();
       
    }

}
