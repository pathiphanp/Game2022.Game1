using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_control : MonoBehaviour
{
    Rigidbody2D rb;

    public GameObject box_map;
    public GameObject bullet;
    public GameObject spawn_bullet;

    public bool can_fire;

    public float speed;
    public float delay;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        player_move();
        shoot();
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
        box_map.transform.position = new Vector3(transform.position.x,box_map.transform.position.y,transform.position.z);
    }
}
