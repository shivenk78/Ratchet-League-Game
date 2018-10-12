using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerController : MonoBehaviour {

    public GameObject ball;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(ball.transform.position.x+7.5f, transform.position.y, ball.transform.position.z+11.5f);
    }
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = new Vector3(ball.transform.position.x + 7.5f, transform.position.y, ball.transform.position.z + 11.5f);
    }
}
