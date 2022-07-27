using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_normal : Healthy_ship
{
    public Bullet_player bullet_code;

    public GameObject spawn_bullet;
    public GameObject bullet;

    public bool can_fire;

    public float delay;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
    }

    public override void enemy_destroy(float damageAmount)
    {
        base.enemy_destroy(damageAmount);
    }

    void shoot()
    {
        if (can_fire == true)
        {
            StartCoroutine(shoot_delay());
        }
    }

    IEnumerator shoot_delay()
    {
        Instantiate(bullet, spawn_bullet.transform.position, spawn_bullet.transform.localRotation);
        can_fire = false;
        yield return new WaitForSeconds(delay);
        can_fire = true;
    }

}
