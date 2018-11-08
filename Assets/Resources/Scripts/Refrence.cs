using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refrence : MonoBehaviour {


    public GameObject Player;

    Vector3 RefrencePos;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        RefrencePos = transform.position;
        RefrencePos.y = Player.transform.position.y;
        transform.position = RefrencePos;
	}
}
