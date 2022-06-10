using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showDialogue : MonoBehaviour
{
    public GameObject tobe;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.GetComponentInParent<DialogueTrigger>().TriggerDialogue();
        }
        if (collision.gameObject.CompareTag("Player") && this.gameObject.name == "Dialogue Final")
        {
            this.GetComponentInParent<DialogueTrigger>().TriggerDialogue();
            Invoke("setTrue", 5.5f);
        }
    }
    void setTrue()
    {
        tobe.SetActive(true);
        Invoke("setFalse", 3f);
    }
    void setFalse() 
    {
        tobe.SetActive(false);
    }
}
