using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public GameObject spaw;
    public LayerMask floor;
    CharacterController chaControl;
    Vector3 character;
    public Transform chackfloor;



    float detegarvity = -6.5f;

    public int haveJump;
    public int jumpCount;
    public float horizontal;
    public float vertical;
    public float garvity;
    public float radius;
    public int speedMove;
    public int speedJump;
    public float speedRotation;
    // Start is called before the first frame update
    void Start()
    {
        chaControl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        MovePlayer();
        Chackface();
        shot();
        Garvity();
    }

    void MovePlayer()
    {        
        garvity += detegarvity * Time.deltaTime;
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        character = new Vector3(horizontal * speedMove * Time.deltaTime,garvity * Time.deltaTime, 0);
        if (Input.GetKeyDown("w") && haveJump > 0) 
        {
            haveJump--;
            character = new Vector3(0, vertical + speedJump * Time.deltaTime, 0);
            garvity = speedJump;

        }
        chaControl.Move(character);

    }

    void shot()
    {
        if (Input.GetKeyDown("space"))
        {
            Instantiate(bullet, spaw.transform.position, spaw.transform.rotation);
        }
    }
    void Garvity()
    {
        if(Physics.CheckSphere(chackfloor.transform.position, radius, floor))
        {
            haveJump = jumpCount; 
            garvity = 0;
        }
    }

    void Chackface()
    {
        if(horizontal < 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), speedRotation * Time.deltaTime);
        }
        if (horizontal > 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 180, 0), speedRotation * Time.deltaTime);
        }
    }
}
