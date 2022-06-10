using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StaminaControler : MonoBehaviour
{
    public GameObject staminaObj;
    public Slider staminaBar;

    public float currentStamina = 100;
    public Transform staminaPos;
    void Start()
    {

    }

   
    void Update()
    {
        staminaBar.value = currentStamina;
        staminaObj.transform.position = new Vector2(staminaPos.position.x, staminaPos.position.y);
        Stamina();
    }
    public void useStamina(float useStamina) 
    {
        currentStamina -= useStamina;
        staminaObj.SetActive(true);
    }

    void Stamina() 
    {
        if (currentStamina < 0)
            currentStamina = 0;
        if (currentStamina >= 100)
        {
            currentStamina = 100;
            staminaObj.SetActive(false);
        }
        currentStamina += 8 * Time.deltaTime;
    }
}
