using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
    Ray ray;
    Transform Node1;
    LineRenderer lineRenderer;
	// Use this for initialization
	void Start ()
    {
        lineRenderer = GetComponent<LineRenderer>();
        Node1 = transform.GetChild(0);
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        //lineRenderer.SetPosition(0, transform.position);
        ray = new Ray(Node1.position, Node1.forward);
        Debug.DrawRay(Node1.position, Node1.forward, Color.black, 1f);
        RaycastHit Hit;
        if (Physics.Raycast(ray, out Hit, 100f))
        {
            if(!Hit.transform==Node1)
            {
                var Endpoint = transform.InverseTransformPoint(Hit.point);
                lineRenderer.SetPosition(1, Endpoint);
            }
        }
	}
}
