using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject gameoverView;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gameoverView.SetActive(false);
    }
    public void Gameover()
    {
        StartCoroutine(Enum_Gameover());
    }

    IEnumerator Enum_Gameover()
    {
        yield return new WaitForSeconds(1f);

        gameoverView.SetActive(true);
    }
}
