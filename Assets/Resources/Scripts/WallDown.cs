using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDown : MonoBehaviour {
    public Vector3 Velocitydown;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position -= Velocitydown * Time.deltaTime;
    }
}
