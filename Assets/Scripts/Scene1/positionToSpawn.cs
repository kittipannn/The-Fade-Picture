using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionToSpawn : MonoBehaviour
{
    public Obstacle Obstacle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Obstacle.transform(this.transform);
        }
    }

}
