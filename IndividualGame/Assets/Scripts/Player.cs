using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour {
    public GameObject predator;
    public GameManager gameManager;
    Animator anim;

    void Start()
    {
        anim = predator.GetComponent<Animator>();
    }
    
    
    public void OnTriggerEnter(Collider col)
    {
        
        Destroy(col.gameObject);

        //bool eat = true;
        //anim.SetBool("Eat", eat);

        if (col.tag == "sick")
        {
            float staminaHit = col.GetComponent<Enemy>().staminaDamage;
            Stamina.stamina += staminaHit;
            float flavor = col.GetComponent<Enemy>().nutrients;
            Health.health += flavor;
            gameManager.SickDie();
            
        }
        else
        {
            float conditioning = col.GetComponent<Enemy>().nutrients;
            Stamina.stamina += conditioning;
            float flavor = col.GetComponent<Enemy>().nutrients;
            Health.health += flavor;
            int scoreValue = col.GetComponent<Enemy>().scoreValue;
            Score.score += scoreValue;
            gameManager.EnemyDie();
            
        }
    }


}
