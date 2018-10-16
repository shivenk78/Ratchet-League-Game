using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    public float speed;
    public float turnSpeed;
    public KeyCode forward;
    public KeyCode back;
    public KeyCode turnLeft;
    public KeyCode turnRight;

    private Rigidbody rb;
    private float initialX;
    private float initialY;
    private float initialZ;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        initialX = transform.position.x;
        initialY = transform.position.y;
        initialZ = transform.position.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(forward))
        {
            //rb.velocity = new Vector3(speed, rb.velocity.y, rb.velocity.z);
            rb.AddRelativeForce(new Vector3(0.0f, 0.0f, -speed));
        }
        else if (Input.GetKey(back))
        {
            //rb.velocity = new Vector3(-speed, rb.velocity.y, rb.velocity.z);
            rb.AddRelativeForce(new Vector3(0.0f, 0.0f, speed));
        }

        if (Input.GetKey(turnLeft))
        {
            transform.Rotate(0.0f, -turnSpeed, 0.0f);
        }
        else if (Input.GetKey(turnRight))
        {
            transform.Rotate(0.0f, turnSpeed, 0.0f);
        }
    }

    public void Reset()
    {
        transform.position = new Vector3(initialX, initialY, initialZ);
        if(name=="Blue Car")
            transform.rotation = new Quaternion(0, 90, 0, 1);
        else
            transform.rotation = new Quaternion(0, -90, 0, 1);

        
    }
}
