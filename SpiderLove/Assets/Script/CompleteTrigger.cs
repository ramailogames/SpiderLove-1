using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            FindObjectOfType<InstructionManager>().CompletedInstruction();
            Destroy(gameObject);
        }
    }
}
