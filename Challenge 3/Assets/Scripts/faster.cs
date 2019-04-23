using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faster : MonoBehaviour
{
    private float speed;

    private Rigidbody rb;
    
    private int speedB;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = speedB;
        speedB = -5;
        rb.velocity = transform.forward * speed;
    }

    

}
