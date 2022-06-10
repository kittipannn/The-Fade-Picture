using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickBut : MonoBehaviour
{
    public void startButton() 
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void quitButton() 
    { 
        Application.Quit();
    }

}
