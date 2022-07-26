using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public LayerMask[] mask;

    Rigidbody2D rb;

    public float speed;

    Vector3 last_transfrom;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bullet_fire();
        bullet_check();
    }
    //??????????????????????
    void bullet_fire()
    {
        rb.velocity = transform.up * speed;
    }
    //??????????????????
    void bullet_check()
    {       
        Vector2 direction = transform.position - last_transfrom;
        float direction_mag = direction.magnitude;
        Debug.DrawLine(last_transfrom,transform.position);
        RaycastHit2D hit = Physics2D.Raycast(last_transfrom, transform.position, direction_mag);
        if (hit)
        {
            if (hit.collider.tag == "oj")
            {
                Destroy(gameObject);
            }
            hit_enemy(hit, "enemy");
        }
        last_transfrom = transform.position;
    }

    void hit_enemy( RaycastHit2D hit_enemy , string enemy)
    {
        if (hit_enemy.collider.tag == enemy)
        {
            if (hit_enemy.collider.TryGetComponent<Healthy_ship>(out Healthy_ship enemyComponent))
            {
                enemyComponent.enemy_destroy(1);
            }
            Destroy(gameObject);
        }
    }
}
