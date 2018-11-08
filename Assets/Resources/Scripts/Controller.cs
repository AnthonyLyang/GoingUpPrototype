using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    Character character;
    public GameObject WeaponSocket;
    Animator animator;
    GunFire Gun;

    GameObject RangedWeapon;
    GameObject MeleeWeapon;

    public JoyStickInput joystick;
    Vector2 MoveInput;

    // Use this for initialization
    private void Awake()
    {
        character = GetComponent<Character>();
        Gun = GetComponentInChildren<GunFire>();
        animator = GetComponentInChildren<Animator>();
        RangedWeapon = Gun.gameObject.transform.parent.gameObject;
        MeleeWeapon = null;
    }


    void Start ()
    {
        RangedWeapon.SetActive(false);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {



#if UNITY_ANDROID
        MoveInput = joystick.stickinput;

        Debug.Log(joystick.stickinput);

        character.InputMoveV = MoveInput.y;
        character.InputMoveH = MoveInput.x;


#else

        character.InputMoveV = Input.GetAxis("Vertical");
        character.InputMoveH = Input.GetAxis("Horizontal");

#endif


        if (Input.GetMouseButtonDown(1))
        {
            RangedWeapon.SetActive(true);
            character.AimingControllerIn = true;            
        }
        if (Input.GetMouseButtonUp(1))
        {
            character.AimingControllerOut = true;
            Invoke("DropGun", 0.3f);
        }
        if (character.IsGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Jump");
                character.Jump();
            }
        }
        if (character.InWall)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                character.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            if (Input.GetKey(KeyCode.B))
            {
                character.Climb();
            }
        }




        character.Aim();
        character.UpdateMove();
        if (Gun.gameObject.activeSelf)
        {
            if (character.IsAiming)
            {
                if (Input.GetMouseButton(0))
                {
                    animator.SetTrigger("Fire");
                    Gun.Fire();
                }
                if (Gun.weaponstate!=GunFire.WeaponStatus.Loading && Input.GetKeyDown(KeyCode.R))
                {
                    Gun.Reload();
                }
            }
        }
    }
    void DropGun()
    {
        RangedWeapon.SetActive(false);
    }


}