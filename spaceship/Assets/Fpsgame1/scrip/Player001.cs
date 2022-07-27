using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player001 : MonoBehaviour
{
    CharacterController player_control;

    public GameObject oj_check_ground;
    public GameObject bullet;
    public GameObject spawn_bullet;

    public LayerMask ground;

    Animator player_anima;

    public Camera fps_Cam;

    public float spawn_bullet_rage;
    public float range;
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
        Shoot_Pistol();
        Shoot();
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

        /*if (horizontal == 0 && vertical == 0)
        {
            player_anima.Play("Idlea");
        }
        else if (horizontal != 0 || vertical != 0)
        {
            player_anima.Play("walk");
        }*/
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
    void Shoot_Pistol()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet,spawn_bullet.transform.position, spawn_bullet.transform.rotation);
            range = 2.6f;
        }
        if (Input.GetMouseButtonUp(0))
        {
            range = 0;
        }
    }

    void Shoot()
    {
        Debug.DrawRay(fps_Cam.transform.position, fps_Cam.transform.forward * range);

        RaycastHit hit;
        if (Physics.Raycast(fps_Cam.transform.position,fps_Cam.transform.forward,out hit,range))
        {
            //Debug.Log(hit.transform.name);
        }
    }

}
