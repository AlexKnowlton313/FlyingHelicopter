using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDropScript : MonoBehaviour {
    
    private Rigidbody rb;
    public float DeathTime = 2.5f;
    public float dropAcc = .001f;
    public float maxDropSpeed = 1.5f;

    void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        Destroy(gameObject, DeathTime);
    }
	
	void Update () {
    }

    void FixedUpdate()
    {
        rb.velocity += Vector3.down * dropAcc;
        
        Vector3 vel = rb.velocity;
        if (vel.sqrMagnitude > maxDropSpeed * maxDropSpeed)
        {
            rb.velocity = vel.normalized * maxDropSpeed;
        }
    }
}
