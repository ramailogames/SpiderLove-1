using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class PackageType:MonoBehaviour
{
    [HideInInspector]public string package_name;
    [HideInInspector]public int amount;
    [HideInInspector]public int id;
    //public string attempts;

    public TMP_Text packageNameText;
    public TMP_Text amountText;
    public TMP_Text attemptText;
    public Button packageButton;

    public void SetDatas()
    {
        packageNameText.text = package_name;
        amountText.text ="Rs." +amount.ToString();
        //attemptText.text = attempts;
    }
}
