using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject player;
    private Transform spawnPos;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = spawnPos.position;
        }
    }
    public Transform transform(Transform transform)
    {
        return spawnPos = transform;
    }

}
