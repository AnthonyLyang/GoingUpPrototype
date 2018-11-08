using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathActivate : MonoBehaviour {
    public GameObject Death;
	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.y <= -2000f)
        {
            Death.SetActive(true);
        }
	}
}
