using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayList : MonoBehaviour
{
    public void BranchJump()
    {
        AudioManagerCS.instance.Play("branchjump");
    }

}
