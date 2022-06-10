using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollect : MonoBehaviour
{
    public ScriptObj key;
    public GameObject keyObj1;
    public GameObject keyObj2;
    public GameObject keyObj3;

    public GameObject objectiveKey1;
    public GameObject objectiveKey2;
    public GameObject objectiveKey3;

    public GameObject txt_obj_key1;
    public GameObject txt_obj_key2;
    public GameObject txt_obj_key3;

    private void Start()
    {
        key.key1 = 0;
        key.key2 = 0;
        key.key3 = 0;
        key.objectiveKey = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("key1"))
        {
            key.key1++;
            keyObj1.gameObject.SetActive(false);
            Debug.Log("collected the key1");
        }

        if (collision.gameObject.CompareTag("key2"))
        {
            key.key2++;
            keyObj2.gameObject.SetActive(false);
            Debug.Log("collected the key2");
        }

        if (collision.gameObject.CompareTag("key3"))
        {
            key.key3++;
            keyObj3.gameObject.SetActive(false);
            Debug.Log("collected the key3");
        }

        if (collision.gameObject.CompareTag("objectiveKey1"))
        {
            key.objectiveKey++;
            objectiveKey1.gameObject.SetActive(false);
            txt_obj_key1.gameObject.SetActive(true);
            StartCoroutine(DelayTextToFalse(txt_obj_key1));
            Debug.Log("collected the objective key#1");
        }

        if (collision.gameObject.CompareTag("objectiveKey2"))
        {
            key.objectiveKey++;
            objectiveKey2.gameObject.SetActive(false);
            txt_obj_key2.gameObject.SetActive(true);
            StartCoroutine(DelayTextToFalse(txt_obj_key2));
            Debug.Log("collected the objective key#2");
        }

        if (collision.gameObject.CompareTag("objectiveKey3"))
        {
            key.objectiveKey++;
            objectiveKey3.gameObject.SetActive(false);
            txt_obj_key3.gameObject.SetActive(true);
            StartCoroutine(DelayTextToFalse(txt_obj_key3));
            Debug.Log("collected the objective key#3");
        }
    }

    public IEnumerator DelayTextToFalse(GameObject key)
    {
        yield return new WaitForSeconds(3f);
        key.gameObject.SetActive(false);
    }
}
