using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshLaser : MonoBehaviour {
    int XorZ;
    int B;
    Vector3 RefreshPos = Vector3.zero;

    public float RefreshCooldown;
    public float RefreshCooldownOnPos;
    public float DestroyTime;

    float RefreshFloat;


    public float RefreshMinDistance;
    float RefreshMaxDistanceX;
    float RefreshMaxDistanceZ;


    float Countdown;
    float CountdownOnPos;

    public enum RefreshStat
    {
        Waiting,
        Refresh,
        RefreshDone
    }

    public GameObject Laser;
    public GameObject Laser2;

    public GameObject TargetCube;
    public GameObject Player;

    RefreshStat Stat;
    RefreshStat OnPlayerPos;



	// Use this for initialization
	void Start ()
    {
        Countdown = Random.Range(0f,RefreshCooldown);
        CountdownOnPos = RefreshCooldownOnPos;

        Stat = RefreshStat.Waiting;
        RefreshMaxDistanceX = TargetCube.transform.localScale.x / 2f;
        RefreshMaxDistanceZ = TargetCube.transform.localScale.z / 2f;

        OnPlayerPos = RefreshStat.Waiting;
        





	}
	
	// Update is called once per frame
	void Update ()
    {
        switch (Stat)
        {
            case RefreshStat.Waiting:
                {
                    TimeCountDown();
                    break;
                }
            case RefreshStat.Refresh:
                {
                    if (OnPlayerPos == RefreshStat.Refresh || CountdownOnPos <= 0.5f)
                    {
                        Countdown = 1f;
                        Stat = RefreshStat.Waiting;
                        break;
                    }

                    Refresh();
                    RefreshFloat = Random.Range(-0.5f, 0.5f);
                    Countdown = RefreshCooldown + RefreshFloat;
                    Stat = RefreshStat.RefreshDone;
                    break;
                }
            case RefreshStat.RefreshDone:
                {
                    Stat = RefreshStat.Waiting;
                    break;
                }
        }

        switch (OnPlayerPos)
        {
            case RefreshStat.Waiting:
                {
                    TimeCountDownOnPos();
                    break;
                }
            case RefreshStat.Refresh:
                {
                    RefreshOnPos();
                    CountdownOnPos = RefreshCooldownOnPos;
                    OnPlayerPos = RefreshStat.RefreshDone;
                    break;
                }
            case RefreshStat.RefreshDone:
                {
                    OnPlayerPos = RefreshStat.Waiting;
                    break;
                }
        }



	}
    void TimeCountDown()
    {
        Countdown -= Time.deltaTime;
        if (Countdown <= 0)
        {
            Stat = RefreshStat.Refresh;
        }
    }
    void TimeCountDownOnPos()
    {
        CountdownOnPos -= Time.deltaTime;
        if (CountdownOnPos <= 0)
        {
            OnPlayerPos = RefreshStat.Refresh;
        }
    }


    void Refresh()
    {
        var NewLaser = Instantiate(Laser, transform);
        Vector3 RefreshPos;
        XorZ = Random.Range(0, 2);
        if (XorZ == 0)
        {
            float A = Random.Range(RefreshMinDistance, RefreshMaxDistanceX);
            int Minus = Random.Range(0, 2);
            if (Minus == 1)
            {
                A *= -1;
            }
            RefreshPos = new Vector3(A, 20f, 0f);
            NewLaser.transform.localPosition = RefreshPos;
            NewLaser.transform.localEulerAngles = new Vector3(0, 90f, 0);
        }
        else
        {
            float A = Random.Range(RefreshMinDistance, RefreshMaxDistanceZ);
            int Minus = Random.Range(0, 2);
            if (Minus == 1)
            {
                A *= -1;
            }
            RefreshPos = new Vector3(0f, 20f, A);
            NewLaser.transform.localPosition = RefreshPos;
        }
        NewLaser.transform.parent = null;
        Destroy(NewLaser, DestroyTime);
    }


    void RefreshOnPos()
    {
        var NewLaser = Instantiate(Laser2, transform);

        XorZ = Random.Range(0, 2);
        if (XorZ == 0)
        {
            RefreshPos = Player.transform.position;
            RefreshPos.z = 0f;
            RefreshPos.y = 20f;

            NewLaser.transform.localPosition = RefreshPos;
            NewLaser.transform.localEulerAngles = new Vector3(0, 90f, 0);
        }
        else
        {
            RefreshPos = Player.transform.position;
            RefreshPos.x = 0f;
            RefreshPos.y = 20f;
            NewLaser.transform.localPosition = RefreshPos;
        }
        NewLaser.transform.parent = null;
        Destroy(NewLaser, DestroyTime);
    }


}
