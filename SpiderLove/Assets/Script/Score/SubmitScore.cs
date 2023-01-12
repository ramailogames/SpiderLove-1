using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RamailoGames;
public class SubmitScore : MonoBehaviour
{
    private void OnEnable()
    {
        RamailoGamesApiHandler.SubmitScore(FindObjectOfType<Timer>().playedTime);

       
    }

}
