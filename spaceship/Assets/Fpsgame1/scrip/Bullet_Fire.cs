using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Fire : MonoBehaviour
{
    public float speed_bullet;

    Vector3 last_transfrom;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 direction = transform.position - last_transfrom;
        Debug.DrawLine(last_transfrom,transform.position);
        float direction_mag = direction.magnitude;

        if (Physics.Raycast(transform.position,last_transfrom,out hit,direction_mag))
        {

        }
        last_transfrom = transform.position;

        rb.velocity = transform.up * speed_bullet;
    }
}
