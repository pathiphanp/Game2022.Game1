using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_control : MonoBehaviour
{
    Rigidbody2D rb;

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
        if (Input.GetButton("Jump"))
        {
            if (can_fire == true)
            {
                StartCoroutine(shoot_delay());
            }
        }
    }
    //????????????
    IEnumerator shoot_delay()
    {
        Instantiate(bullet, spawn_bullet.transform.position, bullet.transform.localRotation);
        can_fire = false;
        yield return new WaitForSeconds(delay);
        can_fire = true;
    }
}
