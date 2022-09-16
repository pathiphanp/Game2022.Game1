using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlD : MonoBehaviour
{
    public GameObject groundMap;

    public LayerMask floor;
    public float horizontal;
    public float speed;
    public int pownJump;
    public int haveJump;
    public float radiusPla;
    Rigidbody2D rb;

    Animator aniPla;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        aniPla = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayMove();
        PlayJump();
        Chackfloor();
    }
    void PlayMove()
    {
        horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y) ;
        if(horizontal != 0)
        {
            if(horizontal > 0)
            {
                transform.localScale = new Vector2(1, 1);
            }
            else if (horizontal < 0)
            {
                transform.localScale = new Vector2(-1, 1);

            }
            aniPla.Play("platermove");
        }
        else
        {
            aniPla.Play("idel");
        }

    }
    void PlayJump()
    {
        if (Input.GetKeyDown("space") && haveJump > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, pownJump);
            haveJump--;
        }
    }

    void Chackfloor()
    {
        if(Physics2D.OverlapCircle(groundMap.transform.position, radiusPla, floor) && rb.velocity.y == 0)
        {
            haveJump = 2;
        }
    }
}
