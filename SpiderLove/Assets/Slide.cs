using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    public GameObject destroyVfx;
    SpriteRenderer sr;
    public Sprite broken;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<PlayerMovement>().canWallJump)
            {
                sr.sprite = broken;
                Invoke("Destroy", .8f);
            }
          
        }
    }

    void Destroy()
    {
        Instantiate(destroyVfx, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
