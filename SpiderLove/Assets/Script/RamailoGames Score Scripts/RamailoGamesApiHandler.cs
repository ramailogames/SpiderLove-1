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


    private void Awake()
    {
        highScore = 0;
    }
    private void Start()
    {
        currentScore = 0;
       
    }

    private void OnEnable()
    {
        currentScore = 0;
      
    }
    internal static void SubmitScore(float playtime)
    {
        ScoreAPI.SubmitScore(currentScore, (int)playtime, (bool s, string msg) => { });
       
        Debug.Log("scoreSumbitted");
        currentScore = 0;
        highScore = 0;
       
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



}
