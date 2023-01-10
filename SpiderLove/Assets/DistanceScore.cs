using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DistanceScore : MonoBehaviour
{
    public Rigidbody2D player;
    

    private void Start()
    {
        InvokeRepeating("IncreaseScore", 1f, .2f);
    }

    void IncreaseScore()
    {
       
        if (player == null)
        {
            return;
        }
        if(player.velocity.y <= 0)
        {
            return;
        }

        
        FindObjectOfType<RamailoGamesScoreManager>().AddScore(1f);
    }
}
