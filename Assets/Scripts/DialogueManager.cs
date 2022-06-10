using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    PlayerMovement player;
    public GameObject dialogCanvas;

    public Queue<string> sentences;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
       

        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        dialogCanvas.SetActive(true);
        nameText.text = dialogue.name;
        sentences.Clear();
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetFloat("Speed", 0);
        player.enabled = false;

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();

    }
    public void DisplayNextSentence() 
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        StartCoroutine(nextSentence());
    }
    IEnumerator nextSentence() 
    {
        yield return new WaitForSeconds(2.5f);
        DisplayNextSentence();
    }
    IEnumerator TypeSentence(string sentence) 
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    void EndDialogue() 
    {
        dialogCanvas.SetActive(false);
        player.enabled = true;
    }


}
