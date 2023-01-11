using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLook : MonoBehaviour
{
    public SpriteRenderer sr;
    public Sprite[] spriteList;
    public GameObject hat;
    public GameObject nose;
    public GameObject ear;
    private void OnMouseDown()
    {
        FindObjectOfType<CharacterSelection>().CharacterSelectionToggle();
    }

    private void Update()
    {
        Change();
    }

    void Change()
    {
        sr.sprite = spriteList[SaveSettings.characterInt];
        switch(SaveSettings.characterInt)
        {
            case 0:
                hat.SetActive(false);
                ear.SetActive(false);
                nose.SetActive(false);
                break;
            case 1:
                hat.SetActive(false);
                ear.SetActive(true);
                nose.SetActive(false);
                break;
            case 2:
                hat.SetActive(false);
                ear.SetActive(false);
                nose.SetActive(true);
                break;
            case 3:
                hat.SetActive(false);
                ear.SetActive(false);
                nose.SetActive(false);
                break;
            case 4:
                hat.SetActive(false);
                ear.SetActive(false);
                nose.SetActive(false);
                break;
            case 5:
                hat.SetActive(true);
                ear.SetActive(false);
                nose.SetActive(false);
                break;

        }
    }
}
