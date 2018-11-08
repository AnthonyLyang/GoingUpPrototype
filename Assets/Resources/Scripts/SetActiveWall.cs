using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveWall : MonoBehaviour {
    public Transform player;
    List<GameObject> walls = new List<GameObject>();

    bool activated = false;
    bool truechanged = false;
    bool falsechanged = false;
	// Use this for initialization
	void Start ()
    {
        foreach (Transform child in transform)
        {
            walls.Add(child.gameObject);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Vector3.Distance(player.position, transform.position) < 150f)
        {
            activated = true;
        }
        else
        {
            activated = false;
        }
        if (activated)
        {
            if (!truechanged)
            {
                foreach (GameObject wall in walls)
                {
                    wall.SetActive(true);
                }
                truechanged = true;
                falsechanged = false;
            }
        }
        else
        {
            if (!falsechanged)
            {
                foreach (GameObject wall in walls)
                {
                    wall.SetActive(false);
                }
                truechanged = false;
                falsechanged = true;
            }
        }


	}
}
