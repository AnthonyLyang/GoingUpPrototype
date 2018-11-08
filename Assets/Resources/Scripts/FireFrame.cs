using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFrame : MonoBehaviour {
    public float PushSpeed;
    public float delta;
    public float realspeed;
    // Use this for initialization

    void Start ()
    {
        realspeed = PushSpeed * 2f;
	}

    // Update is called once per frame

    void Update ()
    {
        if (GameMode.pro != GameProgress.Running)
        {
            return;
        }
        if (realspeed >= PushSpeed)
        {
            realspeed -= Mathf.Lerp(0f, PushSpeed, delta * Time.deltaTime);
        }
        transform.position += Vector3.down * (realspeed);
    }
}
