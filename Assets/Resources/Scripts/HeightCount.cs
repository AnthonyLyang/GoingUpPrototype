using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeightCount : MonoBehaviour {
    Transform Parent;
    float Height;
    string HeightToScreen;
    
    TextMesh text;

	// Use this for initialization
	void Start ()
    {
        Parent = transform.parent;
        text = transform.GetChild(1).GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Height = Parent.localPosition.y;
        HeightToScreen = ((int)(Height+transform.localPosition.y) / 10).ToString();
        text.text = HeightToScreen;
	}
}
