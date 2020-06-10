using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
    public float throttle;
    public float steer;
    public bool lighting;
    public bool brake;


    // Update is called once per frame
    void Update()
    {
        
        throttle = Input.GetAxis("Vertical");
        steer = Input.GetAxis("Horizontal");

        PlaySound();
        lighting = Input.GetKeyDown(KeyCode.L);
        brake = Input.GetKey(KeyCode.Space);
    }

    void PlaySound()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            FindObjectOfType<AudioManager>().Play("Engine sound");
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            FindObjectOfType<AudioManager>().Stop("Engine sound");
        }

    }
}
