using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
    ParticleSystem LightOrb;


    bool PosAdapted = false;

    public GameMode gamemode;

    Transform player;
	// Use this for initialization
	void Start ()
    {
        LightOrb = transform.parent.GetChild(1).gameObject.GetComponent<ParticleSystem>();
        player = gamemode.gameObject.transform;
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LightOrb.Play();
            gameObject.SetActive(false);
            Destroy(transform.parent.gameObject, 2f);
            gamemode.Score += 1;
            gamemode.SCORE.text = "SCORE:" + gamemode.Score;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (!PosAdapted)
        {
            if (!other.CompareTag("Cut") && !other.CompareTag("Wall"))
            {
                float y = other.transform.position.y;
                var pos = transform.parent.position;
                transform.parent.position += Vector3.up * (y + 2.1f - pos.y);
            }
        }   
    }

}
