using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitScore : MonoBehaviour
{
    private void OnEnable()
    {
        RamailoGamesApiHandler.SubmitScore(FindObjectOfType<Timer>().playedTime);
    }

}
