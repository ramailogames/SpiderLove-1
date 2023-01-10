using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLook : MonoBehaviour
{
    private void OnMouseDown()
    {
        FindObjectOfType<CharacterSelection>().CharacterSelectionToggle();
    }
}
