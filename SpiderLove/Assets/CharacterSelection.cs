using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public Image charImage;
    public Sprite[] charList;
    public int charInt = 0;

    public GameObject leftBtn, rightBtn;
    public GameObject charSelectionView;

    bool toggle = true;

    private void Start()
    {
        PlayerPrefs.SetInt("charInt", charInt);
        SaveSettings.characterInt = charInt;
    }

    public void CharacterSelectionToggle()
    {
        toggle = !toggle;

        if (toggle)
        {
            charSelectionView.SetActive(false);
        }
        else if(!toggle)
        {
            charSelectionView.SetActive(true);
        }

    }

    private void Update()
    {
        if(charInt <= 0)
        {
            leftBtn.SetActive(false);
        }
        else
        {
            leftBtn.SetActive(true);
        }

        if(charInt >= charList.Length - 1)
        {
            rightBtn.SetActive(false);
        }
        else
        {
            rightBtn.SetActive(true);
        }
    }

    public void Left()
    {
        if(charInt <= 0)
        {
           
            return;
        }
        charInt--;
        PlayerPrefs.SetInt("charInt", charInt);
        SaveSettings.characterInt = charInt;
        charImage.sprite = charList[charInt];
    }

    public void Right()
    {
        if(charInt >= charList.Length - 1)
        {

            return;
        }
        charInt++;
        PlayerPrefs.SetInt("charInt", charInt);
        SaveSettings.characterInt = charInt;
        charImage.sprite = charList[charInt];
    }
}
