using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    //public UnityEvent OnDestroy;
    public int scoreValue = 10;
    public GameObject enemy;
    public GameObject sickEnemy;
    public Transform target;
    private NavMeshAgent agent;
    public float EnemyDistance = 20.0f;
    public float nutrients = 50.0f;
    public float staminaDamage = 0f;
    public bool isJumping = false;
    Animator anim;

    
    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("Fleeing", isJumping);
        float distance = Vector3.Distance(transform.position, target.position);
        //Debug.Log("Distance: " + distance);
        //if (target != null)
        //{    
        //    agent.destination = target.position;
        //}

        if (distance < EnemyDistance)
        {
            isJumping = true;
            Vector3 dirToPlayer = transform.position - target.position;
            Vector3 newPos = transform.position + dirToPlayer;
            agent.SetDestination(newPos);
            
        }else if(distance >= EnemyDistance)
        {
            isJumping = false;
        }
    }
}
