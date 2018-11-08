using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoyStickInput : MonoBehaviour {
    Vector3 Joystickpos;

    float R;

    Vector3 Initpos;

    Transform stick;

    RectTransform InputResult;

    public Vector2 stickinput;
	// Use this for initialization
	void Start ()
    {
        stick = transform.GetChild(0);
        Initpos = stick.position;

        InputResult = stick.GetComponent<RectTransform>();

        R = transform.GetChild(1).GetComponent<RectTransform>().sizeDelta.x * 0.8f / 2f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        stickinput = InputResult.anchoredPosition.normalized;
	}

    public void OnStickDrag()
    {
        if (Vector3.Distance(Input.mousePosition, Initpos) < R)
        {
            stick.position = Input.mousePosition;
        }
        else
        {
            stick.position = Initpos + (Input.mousePosition - Initpos).normalized * R;
        }
    }

    public void OnDragEnd()
    {
        stick.position = Initpos;
    }
}
