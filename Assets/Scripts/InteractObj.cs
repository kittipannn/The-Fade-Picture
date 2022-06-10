using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObj : MonoBehaviour
{
    Rigidbody2D rb;
    Animator player;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.mass = 7f;
                player.SetBool("IsPush", true);
            }
            else if (rb.velocity.y != 0)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.mass = 7f;
                player.SetBool("IsPush", true);
            }
            else
            {
                rb.bodyType = RigidbodyType2D.Static;
                player.SetBool("IsPush", false);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.SetBool("IsPush", false);
        }
    }
}
