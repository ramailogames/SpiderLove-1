using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [HideInInspector] public float playedTime = 0;

    private void OnEnable()
    {
        playedTime = 0;
    }

    private void Update()
    {
        playedTime += Time.fixedDeltaTime;
    }
}
