using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RamailoGames;

public class CheckAttempts : MonoBehaviour
{
    public GameObject StopView;
    private void Start()
    {
        Time.timeScale = 1f;

        if ((ScoreAPI.instance.playAndWin || ScoreAPI.instance.competition) && DataManager.instance.attempt <= 0)
        {
            StopView.SetActive(true);
            return;
        }
        StopView.SetActive(false);
    }
}
