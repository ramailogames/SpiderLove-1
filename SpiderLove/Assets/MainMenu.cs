using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject mainmenuObj;


    public void Play()
    {
        mainmenuObj.SetActive(false);
    }
}
