using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
    public Image walkTutorial;
    void Start()
    {

        this.GetComponentInParent<DialogueTrigger>().TriggerDialogue();
        StartCoroutine(tutorialPopUp());
    }
    IEnumerator tutorialPopUp() 
    {
        yield return new WaitForSeconds(7.5f);

        walkTutorial.enabled = true;
        StartCoroutine(disableTutorialPopup());
    }
    IEnumerator disableTutorialPopup() 
    {
        yield return new WaitForSeconds(3.5f);
        walkTutorial.enabled = false;

    }
    
}
