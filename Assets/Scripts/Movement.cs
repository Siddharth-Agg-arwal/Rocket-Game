using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //PARAMETERS - for tuning, typically set in the editor
    //CACHE - e.g, references for readability or speed
    //STATE - private instance (member) variables
    
    [SerializeField] float mainThrust = 1000;
    [SerializeField] float rotationThrust = 100;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem MainThruster;
    [SerializeField] ParticleSystem RightThruster;
    [SerializeField] ParticleSystem LeftThruster;

    Rigidbody rb;
    AudioSource audioSource;
    bool isAlive;
 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();    
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust(){
        if(Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    
    private void StartThrusting()
    {
        rb.AddRelativeForce(mainThrust * Time.deltaTime * Vector3.up);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (!MainThruster.isPlaying)
        {
            MainThruster.Play();
        }
    }
    
    private void StopThrusting()
    {
        audioSource.Stop();
        MainThruster.Stop();
    }


    void ProcessRotation(){
        if(Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if(Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotation();
        }
    }

    private void RotateRight()
    {
        if (!LeftThruster.isPlaying)
        {
            LeftThruster.Play();
        }
        ApplyRotation(-rotationThrust);
    }


    private void RotateLeft()
    {
        if (!RightThruster.isPlaying)
        {
            RightThruster.Play();
        }
        ApplyRotation(rotationThrust);
    }

    private void StopRotation()
    {
        LeftThruster.Stop();
        RightThruster.Stop();
    }

    void ApplyRotation(float rotationValue){
        rb.freezeRotation = true; //freezing rotation so we can manually rotate
        transform.Rotate(rotationValue * Time.deltaTime * Vector3.forward);
        rb.freezeRotation = false; //unfreezing rotation so physics system can take over
    }
}


