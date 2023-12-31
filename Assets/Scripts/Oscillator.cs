using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{

    Vector3 StartingPosition;
    [SerializeField] Vector3 MovementVector;
    float movementFactor;
    // [SerializeField] [Range(0,1)] float movementFactor;
    [SerializeField] float period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(period <= Mathf.Epsilon){ return; }
        float cycles = Time.time / period; //continously growing over time
        const float tau = Mathf.PI * 2;     //constant value of 6.283
        float rawSinWave = Mathf.Sin(cycles * tau); //going from -1 to 1

        movementFactor = (rawSinWave + 1f)/2f;  //recalculated to go from 0 to 1;

        Vector3 offset = MovementVector * movementFactor;
        transform.position = StartingPosition + offset;
    }
}
