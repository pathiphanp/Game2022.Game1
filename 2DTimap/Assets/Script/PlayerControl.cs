using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;

    public GameObject chackGround;

    public LayerMask ground;

    public Text pointText;

    float horizontal;
    public int speed;

    public float radius;
    public int jumpown;
    public int jumpHave;
    public int jumpMax;

    public int pointRe;
    public int pointWin;

    Animator playerAnima;
    // Start is called before the first frame update
    void Start()
    {
        jumpHave = jumpMax;
        rb = GetComponent<Rigidbody2D>();
        playerAnima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePla();
        Jump();
        ChackGround();
        WinSeen();
    }
    void MovePla()
    {
        horizontal = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (horizontal == 0)
        {
            playerAnima.Play("idle");
        }
        else if (horizontal != 0)
        {
            playerAnima.Play("walk");
            if (horizontal < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (horizontal > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown("space") && jumpHave > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpown);
            jumpHave--;
        }
    }

    void ChackGround()
    {
        if (Physics2D.OverlapCircle(chackGround.transform.position,radius,ground) && rb.velocity.y <= 0)
        {
            jumpHave = jumpMax;
        }
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "coin")
        {
            pointRe++;
            pointText.text = pointRe.ToString();
            Destroy(player.gameObject);
        }
    }

    void WinSeen()
    {
        if(pointRe == pointWin)
        {
            SceneManager.LoadScene("Winner'");
        }
    }


}
