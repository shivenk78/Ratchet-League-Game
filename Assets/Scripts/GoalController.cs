using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalController : MonoBehaviour {

    public GameObject ball;
    public GameObject ground;
    public Text txt;

    private int goalCount;

	// Use this for initialization
	void Start () {
        //ground.GetComponent<MAIN>().Reset();
        goalCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name=="Soccer Ball")
        {
            goalCount++;
            txt.text = goalCount+"";
            ground.GetComponent<MAIN>().Reset();
        }
    }
}
