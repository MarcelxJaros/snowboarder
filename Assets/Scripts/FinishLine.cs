using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float sekundyDoReset = 2f;
    [SerializeField] ParticleSystem finishEffect;
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Hlava")
        {
            // Debug.Log("You finished!");
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", sekundyDoReset);
            
        }            
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);  
    }
}
