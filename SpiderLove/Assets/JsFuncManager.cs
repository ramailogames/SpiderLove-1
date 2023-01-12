using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class JsFuncManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Alert();

    [DllImport("__Internal")]
    private static extern void AlertParam(string param);

    [DllImport("__Internal")]
    private static extern int GetInt();

    [DllImport("__Internal")]
    private static extern string GetString();

    [DllImport("__Internal")]
    private static extern void openAd();

    [DllImport("__Internal")]
    private static extern void focusReturn();

    public void ReturnFocus()
    {
        focusReturn();
    }


    public void CreateAd() // On Create Ad Button
    {
        openAd();
    }
    public void UnityCallJsFunc()
    {
        Alert();
    }

    public void UnityCallJsFuncWithParam(string param)
    {
        AlertParam(param);
    }

    public void ReturnIntFromJS()
    {
       
    }

    public void ReturnStringFromJS()
    {

    }
}
