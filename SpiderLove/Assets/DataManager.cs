using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using RamailoGames;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

 

    [Header("Datas")]
    public int highscore;
    public int play_and_win_leading_score;
    public int attempt;
    public string playerName;
    public string rewardAmount;
    public string playerProfile;


    private void Awake()
    {
        if (instance)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    private void Start()
    {
        ScoreAPI.GetData((bool s, Data_RequestData d) => {
            if (s)
            {
                highscore = d.high_score;
                play_and_win_leading_score = d.play_and_win_leading_score;
                playerName = d.fname;
                playerProfile = d.photo;
                rewardAmount = d.reward_amount;
                attempt = d.attempts;
            }
        });
        ScoreAPI.instance.GetAttemptsDatas();
    }

    public void UpdateAttempt()
    {
        ScoreAPI.GetData((bool s, Data_RequestData d) => {
            if (s)
            {
                highscore = d.high_score;
                play_and_win_leading_score = d.play_and_win_leading_score;
                playerName = d.fname;
                playerProfile = d.photo;
                rewardAmount = d.reward_amount;
                attempt = d.attempts;
            }
        });
    }

}
