using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour 
{
    [SerializeField] float sekundyDoReset = 1.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] SurfaceEffector2D speedOverTime;
    [SerializeField] AudioClip crashSFX;
    [SerializeField] AudioClip boinkSFX;
    [SerializeField] AudioClip milkSFX; 
    bool fall = false;
    int defaultSpeed = 11;
    float increment = 0.015f;
    bool groundContact = false;
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Hlava")
        {
            FindObjectOfType<PlayerController>().DisableControls();
            Debug.Log("You are dead!");
            speedOverTime.speed = 1;
            increment = -0.015f;
            if(fall == false)
            {
                GetComponent<AudioSource>().PlayOneShot(milkSFX);
                crashEffect.Play();
                fall = true;
            }
            
            
            Invoke("ReloadScene", sekundyDoReset);
        }
        if(other.tag == "Board")
        {
            Debug.Log("jazdím");
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            groundContact = true;
        }     
    }
    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "Board")
        {
            Debug.Log("nejazdím");
            groundContact = false;
            GetComponent<AudioSource>().PlayOneShot(boinkSFX);
            speedOverTime.speed = defaultSpeed;
        }  
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);  
    }

    void Update()
    {
        if(groundContact == true && fall == false)
        {
            if(speedOverTime.speed < 20)
            {
                increment = 0.025f;
            } else {
                increment = 0.015f;
            }
            speedOverTime.speed = (speedOverTime.speed + increment);
            Debug.Log(speedOverTime.speed);
        }
        
    }
}
