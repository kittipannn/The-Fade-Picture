using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public GameObject portal;
    public GameObject player;
    


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Invoke("Teleport",0);
            }
        }
    }
    void Teleport() 
    {
        player.transform.position = new Vector2(portal.transform.position.x, portal.transform.position.y);
    }


}
