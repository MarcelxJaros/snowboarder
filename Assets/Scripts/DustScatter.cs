using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustScatter : MonoBehaviour
{
    [SerializeField] ParticleSystem snowParticle;
    
    void Start() 
    {
        snowParticle.Stop();
    }
    
    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Ground")
        {
            snowParticle.Play();

        }
    }
    void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Ground")
        {
            snowParticle.Stop();
        }
        
    }
        
}
