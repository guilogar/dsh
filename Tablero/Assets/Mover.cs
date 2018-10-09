using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float velocity = 10;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float mh = Input.GetAxis("Horizontal");
        float mv = Input.GetAxis("Vertical");

        // mh *= -1;
        mv *= -1;

        if(mh != 0)
        {
            Vector3 movement = new Vector3(mv, 0.0f, mh);
            rb.AddForce(movement * velocity);
        } else if(mv != 0)
        {
            Vector3 movement = new Vector3(mv, 0.0f, mh);
            rb.AddForce(movement * velocity);
        }
    }
}
