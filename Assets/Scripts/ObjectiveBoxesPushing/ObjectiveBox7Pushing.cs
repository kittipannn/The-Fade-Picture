using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveBox7Pushing : MonoBehaviour
{
    public GameObject wallObjective;
    Rigidbody2D rb;
    Animator player;

    // Start is called before the first frame update
    public void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }
    public void OnTriggerStay2D(Collider2D collision)
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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("plat7"))
        {
            StartCoroutine(DelayToFalse());
        }
    }

    public IEnumerator DelayToFalse()
    {
        yield return new WaitForSeconds(2f);
        wallObjective.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
        Debug.Log("destroy");
    }
}
