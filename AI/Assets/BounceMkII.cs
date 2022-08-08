using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceMkII : MonoBehaviour
{
    public LayerMask layer;
    Rigidbody2D rb;
    [SerializeField]
    [Tooltip("Just for debugging, adds some velocity during OnEnable")]
    private Vector3 initialVelocity;
    private Vector3 lastFrameVelocity;
    public float SetDistanceCheck = 0;
    [SerializeField]
    private float minVelocity = 10f;
    Vector2 oldVelo;
    bool pause = false;
    bool isDie = false;
    public delegate void OnHit(Vector2 velocity);
    public static event OnHit onHit;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = initialVelocity;



    }
    
    // Update is called once per frame
    void Update()
    {
        var vv = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(vv, Vector3.forward);

        lastFrameVelocity = rb.velocity;
        //  var mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //  var delta = mouse - this.transform.position;
        var ray = new Ray2D(this.transform.position, transform.right);

        Debug.DrawLine(ray.origin, ray.GetPoint(SetDistanceCheck), Color.red, 0f);

        var hit = Physics2D.Raycast(ray.origin, ray.direction, SetDistanceCheck, layer);
        if (hit)
        {
            if (hit.collider.tag == "Block")
            {
                //  Debug.Log(collision.gameObject.name);
                //  Debug.Log(collision.gameObject.GetComponent<BlockCollider>());
              
            }        
          //  Debug.Log("qqq");
            // Get a rotation to go from our ray direction (negative, so coming from the wall),
            // to the normal of whatever surface we hit.
            var deflectRotation = Quaternion.FromToRotation(-ray.direction, hit.normal);

            // We then take that rotation and apply it to the same normal vector to basically
            // mirror that angle difference.
            var deflectDirection = deflectRotation * hit.normal;


            var speed = lastFrameVelocity.magnitude;
            if (speed > 7)
                speed = 7;
           // Debug.Log(lastFrameVelocity.magnitude);
            rb.velocity = deflectDirection * Mathf.Max(speed, minVelocity);
           // Debug.Log(rb.velocity);
            float angle = (Mathf.Atan2(deflectDirection.y, deflectDirection.x) * Mathf.Rad2Deg) - 90;
            transform.rotation = Quaternion.Euler(Vector3.forward * (angle + 90));
            Debug.DrawRay(hit.point, deflectDirection, Color.magenta, 0f);
        }



    }
   

}
