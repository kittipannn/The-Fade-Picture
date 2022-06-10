using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toBeContinue : MonoBehaviour
{
    public GameObject picture;
    public GameObject tobecontinuePic;
    public GameObject door;
    PlayerMovement player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                picture.SetActive(true);
                GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetFloat("Speed", 0);
                player.enabled = false;
                Invoke("delayToShowPicture", 0.5f);
                this.gameObject.SetActive(false);
            }
        }
    }
    void delayToShowPicture() 
    {
        picture.GetComponent<Animator>().SetBool("isOpen", true);
        Invoke("showDialogue", 4f);
    }
    void showDialogue()
    {
        this.GetComponent<DialogueTrigger>().TriggerDialogue();
        Invoke("showDoorToTeleport", 8f);
    }
    void showDoorToTeleport() 
    {
        door.SetActive(true);
        player.enabled = true;
    }



}
