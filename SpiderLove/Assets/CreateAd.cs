using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAd : MonoBehaviour
{

    private void Awake()
    {
        Application.runInBackground = true; 
    }
    private void OnEnable()
    {
        FindObjectOfType<JsFuncManager>().CreateAd();
        FindObjectOfType<JsFuncManager>().CreateAd();
    }


    private void Start()
    {
        Invoke("CreateAd_", .1f);
        Invoke("CreateAd_", .2f);
       
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ResumeGame();
        }
    }
    public void CreateAd_()
    {
        FindObjectOfType<JsFuncManager>().CreateAd();
        Invoke("ResumeGame", 1f);
    }

    void ResumeGame()
    {
        FindObjectOfType<JsFuncManager>().ReturnFocus();
    }
}
