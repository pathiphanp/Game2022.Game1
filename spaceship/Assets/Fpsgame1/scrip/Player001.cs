using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player001 : MonoBehaviour
{
    CharacterController player_control;

    public GameObject oj_check_ground;

    public LayerMask ground;

    Animator player_anima;

    public float max_jump;
    public float jump;
    public float speed_move;
    public float radius;
    public float jump_pown;
    public float gravity;
    public float data_gravity;
    // Start is called before the first frame update
    void Start()
    {
        player_control = GetComponent<CharacterController>();
        player_anima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        player_move();
        check_ground();
    }

    void player_move()
    {
        gravity += data_gravity * Time.deltaTime;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown("space") && jump > 0)
        {
            jump--;
            gravity = jump_pown;
        }


        Vector3 pla_move_re = (((transform.right * horizontal + transform.forward * vertical) * speed_move) + new Vector3( 0, gravity,0)) * Time.deltaTime;

        if (horizontal == 0 && vertical == 0)
        {
            player_anima.Play("Idlea");
        }
        else if (horizontal != 0 || vertical != 0)
        {
            player_anima.Play("walk");
        }
        player_control.Move(pla_move_re);
    }
    void check_ground()
    {
        if (Physics.CheckSphere(oj_check_ground.transform.position,radius,ground))
        {
            jump = max_jump;
            gravity = 0;
        }
    }

}
