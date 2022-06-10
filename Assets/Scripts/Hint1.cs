
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hint1 : MonoBehaviour
{
    public GameObject pickUpTutorial;
    bool showTutotial = false;
    bool isPickUp = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F) && isPickUp)
            {
                this.GetComponentInParent<DialogueTrigger>().TriggerDialogue();
                this.gameObject.SetActive(false);
                isPickUp = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !showTutotial)
        {
            showTutotial = true;
            pickUpTutorial.SetActive(true);
            StartCoroutine(disableTutorial());
        }

    }
    IEnumerator disableTutorial() 
    {
        yield return new WaitForSeconds(3f);
        isPickUp = true;
        pickUpTutorial.SetActive(false);
    }
}
