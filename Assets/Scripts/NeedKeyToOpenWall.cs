using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NeedKeyToOpenWall : MonoBehaviour
{
    public ScriptObj key;

    public GameObject needKey1;
    public GameObject needKey2;
    public GameObject needKey3;

    public GameObject needSomethingWindmill;
    public GameObject opened;
    bool useKey1 = false, useKey2 = false, useKey3 = false , useObj = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Key #1
        if(collision.gameObject.CompareTag("Player") && key.key1 == 1 && this.gameObject.CompareTag("wall1") )
        {
            StartCoroutine(DelayToFalse()); //open wall 1
            useKey1 = true;
            key.key1--;
        }
        else if (collision.gameObject.CompareTag("Player") && key.key1 == 0 && this.gameObject.CompareTag("wall1") && !useKey1)
        {
            needKey1.gameObject.SetActive(true); //show text need key1 to open
            StartCoroutine(DelayTextToFalse(needKey1));

        }

        //Key #2
        if (collision.gameObject.CompareTag("Player") && key.key2 == 1 && this.gameObject.CompareTag("wall2"))
        {
            StartCoroutine(DelayToFalse()); //open wall 2
            useKey2 = true;
            key.key2--;

        }
        else if (collision.gameObject.CompareTag("Player") && key.key2 == 0 && this.gameObject.CompareTag("wall2") && !useKey2)
        {
            needKey2.gameObject.SetActive(true); //show text need key2 to open
            StartCoroutine(DelayTextToFalse(needKey2));

        }

        //Key #3
        if (collision.gameObject.CompareTag("Player") && key.key3 == 1 && this.gameObject.CompareTag("wall3"))
        {
            StartCoroutine(DelayToFalse()); //open wall 3
            useKey3 = true;
            key.key3--;

        }
        else if (collision.gameObject.CompareTag("Player") && key.key3 == 0 && this.gameObject.CompareTag("wall3") && !useKey3)
        {
            needKey3.gameObject.SetActive(true); //show text need key3 to open
            StartCoroutine(DelayTextToFalse(needKey3)); 

        }

        //Objective Key
        if (collision.gameObject.CompareTag("Player") && key.objectiveKey == 0 && this.gameObject.CompareTag("boxOfMem") && !useObj)
        {
            needSomethingWindmill.gameObject.SetActive(true);
            StartCoroutine(DelayTextToFalse(needSomethingWindmill));

        }
        else if (collision.gameObject.CompareTag("Player") && key.objectiveKey == 1 && this.gameObject.CompareTag("boxOfMem") && !useObj)
        {
            needSomethingWindmill.gameObject.SetActive(true);
            StartCoroutine(DelayTextToFalse(needSomethingWindmill));

        }
        else if (collision.gameObject.CompareTag("Player") && key.objectiveKey == 2 && this.gameObject.CompareTag("boxOfMem") && !useObj)
        {
            needSomethingWindmill.gameObject.SetActive(true);
            StartCoroutine(DelayTextToFalse(needSomethingWindmill));

        }
        else if (collision.gameObject.CompareTag("Player") && key.objectiveKey == 3 && this.gameObject.CompareTag("boxOfMem"))
        {
            opened.gameObject.SetActive(true);
            useObj = true;
            key.objectiveKey = 0;
            StartCoroutine(DelayToChangeScene());
            //open box of memory

            
        }
    }

    public IEnumerator DelayToFalse()
    {
        yield return new WaitForSeconds(2f);
        
        this.gameObject.SetActive(false);
        //Debug.Log("destroy");
    }

    public IEnumerator DelayTextToFalse(GameObject key)
    {
        yield return new WaitForSeconds(2f);
        key.gameObject.SetActive(false);
    }

    IEnumerator DelayToChangeScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadSceneAsync(3);
    }
}
