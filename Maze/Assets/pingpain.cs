using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pingpain : MonoBehaviour
{
    public Transform startMarker;
    public Transform endMarker;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector2.Distance(startMarker.position, endMarker.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = new Vector2(Mathf.PingPong(Time.time, 11), 2);



    }
}
