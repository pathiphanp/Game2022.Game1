using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_enemy : Bullet_player
{

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bullet_fire();
        bullet_check(enemy);
    }

    public override void bullet_fire()
    {
        base.bullet_fire();
    }

    public override void bullet_check(string enemy)
    {
        base.bullet_check(enemy);
    }
}
