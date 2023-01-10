using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameStart : MonoBehaviour
{
    public GameObject startView;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startView.SetActive(false);
        }
    }

}
