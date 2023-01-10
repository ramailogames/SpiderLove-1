using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionManager : MonoBehaviour
{
    public List<GameObject> instructionList = new List<GameObject>();

    int instructionNumber = 0;

    public void CompletedInstruction()
    {
        instructionList[instructionNumber].SetActive(false);
        instructionNumber++;
        instructionList[instructionNumber].SetActive(true);
    }
     
}
