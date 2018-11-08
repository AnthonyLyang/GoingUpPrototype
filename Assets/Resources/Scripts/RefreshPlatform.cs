using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshPlatform : MonoBehaviour {

    public GameObject Platform;
    public float RefreshCooldown;
    public float RefreshDis;
    public float RefreshFloat;
    public float InitDis;
    public float HorizontalSilde;



    float Countdown;
    RefreshLaser.RefreshStat Stat;
	// Use this for initialization
	void Start ()
    {
        Stat = RefreshLaser.RefreshStat.Waiting;
        Countdown = RefreshCooldown;
	}
	
	// Update is called once per frame
	void Update ()
    {
		switch(Stat)
            {
            case RefreshLaser.RefreshStat.Waiting:
                {
                    TimeCountDown();
                    break;
                }
            case RefreshLaser.RefreshStat.Refresh:
                {
                    Refresh();
                    Stat = RefreshLaser.RefreshStat.RefreshDone;
                    break;
                }
            case RefreshLaser.RefreshStat.RefreshDone:
                {
                    Countdown = RefreshCooldown + Random.Range((-1) * RefreshFloat, RefreshFloat);
                    Stat = RefreshLaser.RefreshStat.Waiting;
                    break;
                }

            }
	}


    void TimeCountDown()
    {
        Countdown -= Time.deltaTime;
        if (Countdown <= 0)
        {
            Stat = RefreshLaser.RefreshStat.Refresh;
        }
    }

    void Refresh()
    {
        InitDis = InitDis + RefreshDis + Random.Range((-1) * RefreshFloat, RefreshFloat);
        var NewPlat = Instantiate(Platform, transform);
        var PosSlide = new Vector3(0f, (-1f * InitDis), 0f);
        var RandomSilde = Random.insideUnitSphere * HorizontalSilde;
        RandomSilde.y = 0;
        NewPlat.transform.localPosition = PosSlide;
        var NewCube = NewPlat.transform.GetChild(0);
        NewCube.localPosition = RandomSilde;
    }



}
