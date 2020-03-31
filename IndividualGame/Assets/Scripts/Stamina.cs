using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour {
    Image staminaBar;
    float maxStamina = 100f;
    public static float stamina;
    // Use this for initialization
    void Start () {
        staminaBar = GetComponent<Image>();
        stamina = maxStamina;
    }
	
	// Update is called once per frame
	void Update () {
        staminaBar.fillAmount = stamina / maxStamina;
        if (stamina > maxStamina)
        {
            stamina = maxStamina;
        }else if (stamina < 0f)
        {
            stamina = 0f;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            stamina -= 10f * Time.deltaTime;
        }else
        {
            stamina += 10f * Time.deltaTime;
        }

        if (stamina <= 0f)
        {
            
        }
    }
}
