using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public LayerMask[] mask;

    Rigidbody2D rb;

    public int index_mask;

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
            if (hit.collider.tag == "enemy")
            {
                Destroy(hit.collider.gameObject);
                Destroy(gameObject);
            }
        }
        last_transfrom = transform.position;
    }
}
