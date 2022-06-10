using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showTutorial : MonoBehaviour
{
    public GameObject tutorial;
    bool start = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && start)
        {
            tutorial.SetActive(true);
            start = false;
            StartCoroutine(disableTutorial());
        }
    }
    IEnumerator disableTutorial()
    {
        yield return new WaitForSeconds(5f);
        tutorial.SetActive(false);
        
    }
}
