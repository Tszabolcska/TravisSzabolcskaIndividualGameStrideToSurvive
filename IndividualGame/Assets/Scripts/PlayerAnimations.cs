using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerAnimations : MonoBehaviour
{
    public FirstPersonController firstPersonController;
    Animator TestCreature;
    public bool isRunning;
    public bool isSprinting;

    [SerializeField] private AudioClip bite;
    [SerializeField] private AudioClip roar;

    private AudioSource m_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        TestCreature = gameObject.GetComponent<Animator>();
        m_AudioSource = GetComponent<AudioSource>();
        isRunning = false;
        isSprinting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.D))
        {
            isRunning = true;
            TestCreature.SetBool("isRunning", true);
        }
        else
        {
            isRunning = false;

            TestCreature.SetBool("isRunning", false);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
            TestCreature.SetBool("isSprinting", true);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                PlayRoarSound();
            }
        }
        
        else if (firstPersonController.runningstamina == 0)
        {
            isSprinting = false;

            TestCreature.SetBool("isSprinting", false);
        }
        else
        {
            isSprinting = false;

            TestCreature.SetBool("isSprinting", false);
        }
    }
    private void PlayBiteSound()
    {
        m_AudioSource.clip = bite;
        m_AudioSource.Play();
    }
    private void PlayRoarSound()
    {
        m_AudioSource.clip = roar;
        m_AudioSource.Play();
    }
    
}