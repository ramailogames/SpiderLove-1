using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class pauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseView;
   

    bool toggle;
    private void Start()
    {
        pauseView.SetActive(false);
       
    }


    public void Pause()
    {
        toggle = !toggle;
       // FindObjectOfType<AudioManagerCS>().Play("button");
        if (toggle)
        {
            pauseView.SetActive(true);
            Time.timeScale = 0;
        }
        else if (!toggle)
        {
            Time.timeScale = 1;
            pauseView.SetActive(false);
        }
    }
}
