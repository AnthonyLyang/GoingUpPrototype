using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshScoreOrb : MonoBehaviour {
    enum RefreshStat
    {
        waiting,
        refresh,
        refreshdone
    }

    public GameObject ScoreOrb;
    public float RefreshTime;
    float RefreshCountdown;
    RefreshStat stat;

    public float RefreshDis;


	// Use this for initialization
	void Start ()
    {
        stat = RefreshStat.waiting;
        RefreshCountdown = 0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        switch (stat)
        {
            case RefreshStat.waiting:
                {
                    Countdown();
                    break;
                }
            case RefreshStat.refresh:
                {
                    Refresh();
                    stat = RefreshStat.refreshdone;
                    break;
                }
            case RefreshStat.refreshdone:
                {
                    RefreshCountdown = RefreshTime;
                    stat = RefreshStat.waiting;
                    break;
                }
        }
	}

    void Countdown()
    {
        RefreshCountdown -= Time.deltaTime;
        if (RefreshCountdown<=0f)
        {
            stat = RefreshStat.refresh;
        }
    }
    void Refresh()
    {
        var NewOrb = Instantiate(ScoreOrb, transform);
        var PosSilde = Random.insideUnitSphere * 5f;
        PosSilde.y = 0f;
        NewOrb.transform.localPosition = PosSilde;
        NewOrb.transform.parent = null;
        Destroy(NewOrb, 30f);
    }

}
