using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_player : MonoBehaviour
{
    [SerializeField] protected LayerMask[] mask;

    protected Rigidbody2D rb;

    [SerializeField] protected float speed;

    [SerializeField] protected string enemy;

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
        bullet_check(enemy);
    }
    //??????????????????????
    void bullet_fire()
    {
        rb.velocity = transform.up * speed;
    }
    //??????????????????
    public virtual void bullet_check(string enemy)
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
            if (hit.collider.tag == enemy)
            {
                if (hit.collider.TryGetComponent<Healthy_ship>(out Healthy_ship enemyComponent))
                {
                    enemyComponent.enemy_destroy(1);
                }
                Destroy(gameObject);
            }
        }
        last_transfrom = transform.position;
    }
}
