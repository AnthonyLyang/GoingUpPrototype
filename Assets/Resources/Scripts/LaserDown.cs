using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDown : MonoBehaviour {
    public Vector3 Velocitydown;
    Transform ShadowScale;
    public Transform Ref;

    Vector3 ScaleTemp;
    float DisFlag;

    // Use this for initialization
	void Start ()
    {
        ShadowScale = transform.GetChild(1);
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position -= Velocitydown * Time.deltaTime;
        //DisFlag = Mathf.Abs(transform.position.y - Ref.position.y);
        //if (DisFlag <= 1f)
        //{
        //    return;
        //}
        //var A = 0.1f * DisFlag;
        //ScaleTemp = ShadowScale.localScale;
        //ScaleTemp.z = A;
        //ShadowScale.localScale = ScaleTemp;
	}
}
