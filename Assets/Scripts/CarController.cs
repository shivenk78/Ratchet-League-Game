using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    public float speed;
    public float turnSpeed;
    public float jumpForce;
    public KeyCode forward;
    public KeyCode back;
    public KeyCode turnLeft;
    public KeyCode turnRight;
    public KeyCode jump;

    private Rigidbody rb;
    private float initialX;
    private float initialY;
    private float initialZ;
    private Quaternion initRot;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        initialX = transform.position.x;
        initialY = transform.position.y;
        initialZ = transform.position.z;
        initRot = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool inAir = transform.position.y > 1;
        float airSpeed = speed;
        float airTurnSpeed = turnSpeed;
        if (inAir)
        {
            airSpeed = speed / 10;
            airTurnSpeed = turnSpeed / 10;
        }

        if (Input.GetKey(forward))
        {
            //rb.velocity = new Vector3(speed, rb.velocity.y, rb.velocity.z);
            rb.AddRelativeForce(new Vector3(0.0f, 0.0f, -airSpeed));
        }
        else if (Input.GetKey(back))
        {
            //rb.velocity = new Vector3(-speed, rb.velocity.y, rb.velocity.z);
            rb.AddRelativeForce(new Vector3(0.0f, 0.0f, airSpeed));
        }

        if (Input.GetKey(turnLeft))
        {
            rb.AddRelativeTorque(new Vector3(0.0f, -airTurnSpeed, 0.0f));
        }
        else if (Input.GetKey(turnRight))
        {
            rb.AddRelativeTorque(new Vector3(0.0f, airTurnSpeed, 0.0f));
        }
        if (Input.GetKey(jump) && !inAir)
        {
            rb.AddRelativeForce(new Vector3(0.0f, jumpForce, 0.0f));
        }
        if (Vector3.Dot(transform.up, Vector3.down) == 1)
        {
            Reset();
        }
    }

    public void Reset()
    {
        transform.position = new Vector3(initialX, initialY, initialZ);
        transform.rotation = Quaternion.Slerp(transform.rotation, initRot, Time.deltaTime);
        rb.velocity = new Vector3(0, 0, 0);
    }
}
