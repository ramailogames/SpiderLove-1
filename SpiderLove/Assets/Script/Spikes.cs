using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public GameObject deathVfx;
    public GameObject eye;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(deathVfx, collision.transform.position, Quaternion.identity);
            Instantiate(eye, collision.transform.position, Quaternion.identity);
            AudioManagerCS.instance.Play("splash");
            AudioManagerCS.instance.Play("death");
            GameManager.instance.Gameover();
            Destroy(collision.gameObject);
        }
    }
}
