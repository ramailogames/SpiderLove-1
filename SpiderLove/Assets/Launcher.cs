using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [Header("Properties")]
    public float radius;
    public LayerMask whatIsPlayer;


    private void Update()
    {
        Collider2D checkPlayer = Physics2D.OverlapCircle(transform.position, radius, whatIsPlayer);

        if(checkPlayer != null)
        {
            checkPlayer.GetComponent<PlayerMovement>().Launch();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
