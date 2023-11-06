using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float mainThrust = 1000;
    [SerializeField] float rotationThrust = 100;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust(){
        if(Input.GetKey(KeyCode.Space)){
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
        
    }

    void ProcessRotation(){
        if(Input.GetKey(KeyCode.A)){
            ApplyRotation(rotationThrust);
        }
        else if(Input.GetKey(KeyCode.D)){
            ApplyRotation(-rotationThrust);
        }
    }

    void ApplyRotation(float rotationValue){
        rb.freezeRotation = true; //freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationValue * Time.deltaTime);
        rb.freezeRotation = false; //unfreezing rotation so physics system can take over
    }
}


