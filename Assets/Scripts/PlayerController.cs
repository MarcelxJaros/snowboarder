using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float torque = 1f;
    [SerializeField] float boostSpeed = 10f;
    [SerializeField] float baseSpeed = 11f;
    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        Invoke("ReloadScene", 0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove == true)
        {
            RotatePlayer();
            //RespondToBoos();
        }
        
        
    }

    public void DisableControls()
    {
        canMove = false;
    }

    void RespondToBoos()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            surfaceEffector2D.speed += boostSpeed;
        } else 
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torque);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torque);
        }
    }
}
