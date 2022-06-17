using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public GameObject bullet;
    public GameObject spaw;
    public LayerMask floor;
    CharacterController chaControl;
    Vector3 character;
    public Transform chackfloor;



    float detegarvity = -6.5f;
    public float garvity;
    public float radius;
    public int speedMove;
    public int speedJump;
    // Start is called before the first frame update
    void Start()
    {
        chaControl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        shot();
        Garvity();
    }

    void MovePlayer()
    {        
        garvity += detegarvity * Time.deltaTime;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        character = new Vector3(horizontal * speedMove * Time.deltaTime,garvity * Time.deltaTime, 0);
        if (Input.GetKeyDown("w")) 
        {
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
            garvity = 0;
        }

    }
}
