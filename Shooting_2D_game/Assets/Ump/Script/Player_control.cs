using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_control : Healthy_ship
{
    Rigidbody2D rb;

    public GameObject box_map;
    public GameObject bullet;
    public GameObject spawn_bullet;
    public GameObject camera_follow;

    public bool can_fire;

    public float speed;
    public float speed_follow;
    public float speed_box_map;
    public float delay;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        player_move();
        shoot();
        camera_follow_player();
        box_map_follow_player();
    }
    //????????????????????????
    void player_move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rb.velocity = (transform.right * horizontal + transform.up * vertical) * speed;
    }
    //????????????
    void shoot()
    {
            if (can_fire == true)
            {
                StartCoroutine(shoot_delay());
            }
    }
    //????????????
    IEnumerator shoot_delay()
    {
        Instantiate(bullet, spawn_bullet.transform.position, spawn_bullet.transform.localRotation);
        can_fire = false;
        yield return new WaitForSeconds(delay);
        can_fire = true;
    }

    void box_map_follow_player()
    {
        box_map.transform.position = new Vector3(transform.position.x + speed_box_map, box_map.transform.position.y,transform.position.z);
    }

    public override void enemy_destroy(float damageAmount)
    {
        base.enemy_destroy(damageAmount);
    }

    void camera_follow_player()
    {
        if (camera_follow.transform.position.y > 0.75)
        {
            camera_follow.transform.position = new Vector3(camera_follow.transform.position.x, 0.75f, camera_follow.transform.position.z);
        }
        else if (camera_follow.transform.position.y < -0.21)
        {
            camera_follow.transform.position = new Vector3(camera_follow.transform.position.x, -0.21f, camera_follow.transform.position.z);
        }
        camera_follow.transform.position = Vector3.Lerp(camera_follow.transform.position, new Vector3(camera_follow.transform.position.x,transform.position.y,camera_follow.transform.position.z), speed_follow * Time.deltaTime);
    }


}
