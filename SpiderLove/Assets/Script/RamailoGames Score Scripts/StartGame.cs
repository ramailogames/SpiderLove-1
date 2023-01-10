using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RamailoGames;

public class StartGame : MonoBehaviour
{
    private void Awake()
    {
        ScoreAPI.GameStart();
    }
    
}
