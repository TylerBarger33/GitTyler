using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public float speed;
    
    private Rigidbody rb;
    void Start()
    { 
        Func();
    }

    public void Func()

    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        if (Input.GetKey(KeyCode.H))
        {
            speed = -10;
        }
    }
    

}