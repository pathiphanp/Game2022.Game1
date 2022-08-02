using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_roll : Healthy_ship
{
    public GameObject[] spawn_bullet;
    public GameObject bullet;

    public bool can_fire;

    public float delay;

    [SerializeField] int speed_roll;
 
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
        roll();
    }

    public override void enemy_destroy(float damageAmount)
    {
        base.enemy_destroy(damageAmount);
    }

    void roll()
    {
        transform.Rotate(0, 0, speed_roll * Time.deltaTime);
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
        for (int i = 0;i < spawn_bullet.Length;i++)
        {
            Instantiate(bullet, spawn_bullet[i].transform.position, spawn_bullet[i].transform.rotation);
        }
        can_fire = false;
        yield return new WaitForSeconds(delay);
        can_fire = true;
    }
}
