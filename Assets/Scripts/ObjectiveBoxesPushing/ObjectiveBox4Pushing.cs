using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveBox4Pushing : MonoBehaviour
{
    public GameObject wallObjective;
    Rigidbody2D rb;

    // Start is called before the first frame update
    public void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.mass = 7f;
            }
            else
            {
                rb.bodyType = RigidbodyType2D.Static;
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("plat4"))
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
