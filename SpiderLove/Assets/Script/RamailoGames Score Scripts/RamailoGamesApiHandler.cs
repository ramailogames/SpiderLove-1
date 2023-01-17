using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using RamailoGames;
using TMPro;

public class RamailoGamesApiHandler : MonoBehaviour
{
  
    public static int currentScore = 0;

    public static int highScore = 0;
   

    public static event UnityAction OnScoreUpdate;

    public TextMeshProUGUI attemptText;
    public GameObject shopButton;
    public GameObject shopView;
    public GameObject claimBtn;

    private void Start()
    {
        currentScore = 0;

        ScoreAPI.GetData((bool s, Data_RequestData d) => {
            if (s)
            {
                if (ScoreAPI.instance.playAndWin || ScoreAPI.instance.competition)
                {
                    Debug.Log(d.attempts);
                    DataManager.instance.attempt = d.attempts;
                    attemptText.text = "Attempts : " + d.attempts.ToString();

                    // SoundManager.instance.attempt = d.attempts;
                }
                else
                {
                    //attemptText.transform.parent.gameObject.SetActive(false);
                    attemptText.gameObject.SetActive(false);
                    if (shopButton != null)
                        shopButton.gameObject.SetActive(false);
                }
            }
            else
            {
                //attemptText.transform.parent.gameObject.SetActive(false);
                attemptText.gameObject.SetActive(false);
                if (shopButton != null)
                    shopButton.gameObject.SetActive(false);
            }
        });

    }

    private void OnEnable()
    {
        currentScore = 0;
       


    }
    internal static void SubmitScore(float playtime)
    {
        ScoreAPI.SubmitScore(currentScore, (int)playtime, (bool s, string msg) => { });
        Debug.Log("scoreSumbitted");
    }

    internal static void AddScore(int amount)
    {
        currentScore += amount;
        if (currentScore > highScore)
        {
            highScore = currentScore;
        }
        OnScoreUpdate?.Invoke();

    }


    internal static void UpdateHighScore(UnityAction callback)
    {
        ScoreAPI.GetData((bool s, Data_RequestData d) => {
            if (s)
            {
                highScore = d.high_score;
             
                callback?.Invoke();
            }
        });
    }



    public void SetAttempts()
    {
        ScoreAPI.GetData((bool s, Data_RequestData d) => {
            if (s)
            {
                if (ScoreAPI.instance.playAndWin || ScoreAPI.instance.competition)
                {
                    Debug.Log(d.attempts);
                    DataManager.instance.attempt = d.attempts;
                    attemptText.text = "Attempts : " + d.attempts.ToString();

                    // SoundManager.instance.attempt = d.attempts;
                }
                else
                {
                    //attemptText.transform.parent.gameObject.SetActive(false);
                    attemptText.gameObject.SetActive(false);
                    if (shopButton != null)
                        shopButton.gameObject.SetActive(false);
                }
            }
            else
            {
                //attemptText.transform.parent.gameObject.SetActive(false);
                attemptText.gameObject.SetActive(false);
                if (shopButton != null)
                    shopButton.gameObject.SetActive(false);
            }
        });
    }

    public void ShopBtn()
    {
        shopView.SetActive(true);

    }

    public void CloseShopBtn()
    {
        shopView.SetActive(false);
    }


   
    public void ClamBtn()
    {
        ScoreAPI.instance.OnClaimButtonClick((int)FindObjectOfType<RamailoGamesScoreManager>().currentScore);
        claimBtn.SetActive(false);
    }
}
