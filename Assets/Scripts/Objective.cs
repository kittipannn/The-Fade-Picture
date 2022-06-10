using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Objective : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.GetComponentInParent<DialogueTrigger>().TriggerDialogue();
            StartCoroutine(delayToChangeScene());
        }
    }
    IEnumerator delayToChangeScene() 
    {
        yield return new WaitForSeconds(16);
        SceneManager.LoadSceneAsync(2);
    }

}
