using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformUp : MonoBehaviour {
    public float VelocityUp;
    Vector3 Velocity;

	// Use this for initialization
	void Start ()
    {
        Velocity = new Vector3(0f, VelocityUp, 0f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += (Velocity * Time.deltaTime);
	}
}
