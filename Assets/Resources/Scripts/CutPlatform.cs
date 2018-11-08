using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutPlatform : MonoBehaviour {


    Transform Cursor;
    Transform Ground;


    Vector3 CursorToPlatformPos;
    Vector3 PlatformPos;

    Vector3 NewGroundScale;
    Vector3 NewPartScale;


    Rigidbody rigid;
    float Mass;
    public float InitMass;

    public Transform WallX1;
    public Transform WallX2;
    public Transform WallZ1;
    public Transform WallZ2;




    bool CanBeCut = true;
    bool IsNewPart = false;


	// Use this for initialization
	void Start ()
    {
        Ground = transform;
        rigid = GetComponent<Rigidbody>();


        if (!IsNewPart)
        {
            Mass = InitMass;
            rigid.mass = Mass;
            if (Ground.localPosition.x > 1f)
            {
                FitWallX(WallX1);
            }
            if (Ground.localPosition.x < -1f)
            {
                FitWallX(WallX2);
            }
            if (Ground.localPosition.z > 1f)
            {
                FitWallZ(WallZ1);
            }
            if (Ground.localPosition.z < -1f)
            {
                FitWallZ(WallZ2);
            }
        }

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Cut"))
        {
            Debug.Log("Enter");
            if (CanBeCut)
            {
                Cursor = other.transform.parent;
                Ground = transform;
                GetCursorInfo();
                if (Cursor.eulerAngles.y == 90f|| Cursor.eulerAngles.y == -90f)
                {
                    if (Mathf.Abs((other.transform.position - transform.position).x) >= transform.localScale.x - 0.1f)
                    {
                        Debug.Log("IgnoreEdge");
                        return;
                    }
                    CutParallelZ();
                }
                else if (Cursor.eulerAngles.y == 0f|| Cursor.eulerAngles.y == 180f)
                {
                    if (Mathf.Abs((other.transform.position - transform.position).z) >= transform.localScale.z - 0.1f)
                    {
                        Debug.Log("IgnoreEdge");
                        return;
                    }
                    CutParallelX();
                }
                else
                {
                    return;
                }
            }
        }
        if (Mass < InitMass * 0.2f)
        {
            rigid.isKinematic = false;
            Destroy(gameObject, 1.5f);
        }
    }

    void GetCursorInfo()
    {
        CursorToPlatformPos = Cursor.position - transform.position;
        CursorToPlatformPos.y = 0;
    }

    void CutParallelX()
    {
        PlatformPos = Ground.position;
        NewGroundScale = Ground.localScale;//新的主体的比例
        var Assist1 = new Vector3(0, 0, CursorToPlatformPos.z);
        var Assist2 = Assist1.normalized * NewGroundScale.z / 2f;
        var PosSilde = (Assist2 - Assist1) / 2f;

        var NewPart = Instantiate(Ground.gameObject, Ground.parent);


        var NewCut = NewPart.GetComponent<CutPlatform>();
        NewCut.IsNewPart = true;
        NewCut.CanBeCut = false;



        Ground.localPosition -= PosSilde;
        NewGroundScale.z = (Assist1 + Assist2).magnitude;


        NewPart.transform.localPosition += (PosSilde + Assist1);
        NewPartScale = NewPart.transform.localScale;
        NewPartScale.z = Ground.localScale.z - NewGroundScale.z;
        NewPart.transform.localScale = NewPartScale;
        


        if (NewPart.transform.localScale.z == 0f)
        {
            Destroy(NewPart);
        }
        NewPart.transform.parent = null;
        
        Destroy(NewPart, 1f);


        Mass = rigid.mass * (NewGroundScale.z / Ground.localScale.z);

        var NewRigid = NewPart.GetComponent<Rigidbody>();
        NewRigid.isKinematic = false;
        NewRigid.mass = rigid.mass - Mass;
        NewRigid.AddForceAtPosition(Vector3.down * 10f, NewPart.transform.position + NewPart.transform.forward*0.1f, ForceMode.Impulse);


        rigid.mass = Mass;
        Ground.localScale = NewGroundScale;
        
    }

    void CutParallelZ()
    {
        PlatformPos = Ground.position;
        NewGroundScale = Ground.localScale;
        var Assist1 = new Vector3(CursorToPlatformPos.x, 0, 0);
        var Assist2 = Assist1.normalized * NewGroundScale.x / 2f;
        var PosSilde = (Assist2 - Assist1) / 2f;

        var NewPart = Instantiate(Ground.gameObject, Ground.parent);

        var NewCut = NewPart.GetComponent<CutPlatform>();
        NewCut.IsNewPart = true;
        NewCut.CanBeCut = false;

        Ground.localPosition -= PosSilde;
        NewGroundScale.x = (Assist1 + Assist2).magnitude;

        NewPart.transform.localPosition += (PosSilde + Assist1);
        NewPartScale = NewPart.transform.localScale;
        NewPartScale.x = Ground.localScale.x - NewGroundScale.x;
        NewPart.transform.localScale = NewPartScale;

        if (NewPart.transform.localScale.x == 0f)
        {
            Destroy(NewPart);
        }

        NewPart.transform.parent = null;
        Destroy(NewPart,1f);
        Mass = rigid.mass * (NewGroundScale.x / Ground.localScale.x);

        var NewRigid = NewPart.GetComponent<Rigidbody>();
        NewRigid.isKinematic = false;
        NewRigid.mass = rigid.mass - Mass;
        NewRigid.AddForceAtPosition(Vector3.down * 10f, NewPart.transform.position + NewPart.transform.forward*0.1f, ForceMode.Impulse);

        rigid.mass = Mass;
        Ground.localScale = NewGroundScale;
    }

    void FitWallX(Transform X)
    {
        CursorToPlatformPos = X.position - transform.position;
        CursorToPlatformPos.y = 0;

        PlatformPos = Ground.position;
        NewGroundScale = Ground.localScale;
        var Assist1 = new Vector3(CursorToPlatformPos.x, 0, 0);
        var Assist2 = Assist1.normalized * NewGroundScale.x / 2f;
        var PosSilde = (Assist2 - Assist1) / 2f;


        //var NewPart = Instantiate(Ground.gameObject, Ground.parent);

        Ground.localPosition -= PosSilde;
        NewGroundScale.x = (Assist1 + Assist2).magnitude;

        //NewPart.transform.localPosition += (PosSilde + Assist1);
        //NewPartScale = NewPart.transform.localScale;
        //NewPartScale.x = Ground.localScale.x - NewGroundScale.x;
        //NewPart.transform.localScale = NewPartScale;
        //NewPart.GetComponent<Rigidbody>().isKinematic = false;
        //NewPart.GetComponent<CutPlatform>().CanBeCut = false;


        //if (NewPart.transform.localScale.x == 0f)
        //{
        //    Destroy(NewPart);
        //}

        //NewPart.transform.parent = null;
        //Destroy(NewPart, 3f);
        Mass = rigid.mass * (NewGroundScale.x / Ground.localScale.x);
        //NewPart.GetComponent<Rigidbody>().mass = rigid.mass - Mass;
        rigid.mass = Mass;



        Ground.localScale = NewGroundScale;


    }

    void FitWallZ(Transform Z)
    {
        CursorToPlatformPos = Z.position - transform.position;
        CursorToPlatformPos.y = 0;


        PlatformPos = Ground.position;
        NewGroundScale = Ground.localScale;//新的主体的比例
        var Assist1 = new Vector3(0, 0, CursorToPlatformPos.z);
        var Assist2 = Assist1.normalized * NewGroundScale.z / 2f;
        var PosSilde = (Assist2 - Assist1) / 2f;

        //var NewPart = Instantiate(Ground.gameObject, Ground.parent);

        Ground.localPosition -= PosSilde;
        NewGroundScale.z = (Assist1 + Assist2).magnitude;


        //NewPart.transform.localPosition += (PosSilde + Assist1);
        //NewPartScale = NewPart.transform.localScale;
        //NewPartScale.z = Ground.localScale.z - NewGroundScale.z;
        //NewPart.transform.localScale = NewPartScale;
        //NewPart.GetComponent<Rigidbody>().isKinematic = false;
        //NewPart.GetComponent<CutPlatform>().CanBeCut = false;

        //if (NewPart.transform.localScale.z == 0f)
        //{
        //    Destroy(NewPart);
        //}
        //NewPart.transform.parent = null;
        //Destroy(NewPart, 3f);


        Mass = rigid.mass * (NewGroundScale.z / Ground.localScale.z);
        //NewPart.GetComponent<Rigidbody>().mass = rigid.mass - Mass;
        rigid.mass = Mass;
        Ground.localScale = NewGroundScale;
    }

}
