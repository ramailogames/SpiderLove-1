using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{
     public void LoadLevel()
    {
        SceneManager.LoadScene("Game");
    }

    public void PlayLoveSong()
    {
        AudioManagerCS.instance.Play("lovesong");
    }

    public void Alert()
    {
        AudioManagerCS.instance.Play("alert");
    }

    public void KidNap()
    {
        AudioManagerCS.instance.Play("kidnap");
    }

    public void Dive()
    {
        AudioManagerCS.instance.Play("dive");
    }

    public void Peak()
    {
        AudioManagerCS.instance.Play("peak");
    }
}
