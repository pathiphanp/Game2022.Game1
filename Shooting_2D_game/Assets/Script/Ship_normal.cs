using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_normal : Healthy_ship
{
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void enemy_destroy(float damageAmount)
    {
        base.enemy_destroy(damageAmount);
    }
}
