using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_move : MonoBehaviour
{
    public GameObject bullet;
    public GameObject spawn_bullet;

    Rigidbody rb;
    [SerializeField] bool str_rnd;

    int i;

    Vector3 relativePos;
    Vector3 relative;

    [SerializeField] LayerMask wall;

    [SerializeField] string direction_name_word;

    [SerializeField] bool can_fire;

    [SerializeField] int max_fire;

    [SerializeField] float direction_forllow;
    [SerializeField] float direction_word;
    [SerializeField] float delay;
    [SerializeField] float speed_ro;
    [SerializeField] float speed_ro_left;
    [SerializeField] float speed_ro_rigth;
    [SerializeField] float speed_move;
    [SerializeField] float speed_move_atk;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //time += Time.deltaTime;
        ai_move_set();
        Chack_collision();
    }

    void ai_move_set()
    {
        rb.velocity = transform.forward * speed_move;
        transform.Rotate(0,speed_ro * Time.deltaTime,0);
        System.Random rnd = new System.Random();
        if (str_rnd == true)
        {
            i = rnd.Next(0,3);
            str_rnd = false;
            StartCoroutine(delay_rnd());         
        }
        if (i == 0)
        {
            speed_ro = speed_ro_left;
        }
        else if (i == 1)
        {
            speed_ro = speed_ro_rigth;
        }
        else if (i == 2)
        {
            speed_ro = 0;
        }
    }
    IEnumerator delay_rnd()
    {
        yield return new WaitForSeconds(delay);
        str_rnd = true;
    }

    void Chack_collision()
    {
        relativePos = transform.forward.normalized;
        //Debug.Log(relativePos);
        var ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * direction_forllow, Color.yellow);
        Debug.DrawRay(ray.origin, ray.direction * direction_word,Color.red);
        RaycastHit hit;
        RaycastHit hit2;
        if (Physics.Raycast(ray.origin,ray.direction,out hit2,direction_word,wall))
        {
            if (hit2.collider.gameObject.tag == "walltop")
            {
                direction_name_word = "walltop";
            }
            if (hit2.collider.gameObject.tag == "walldown")
            {
                direction_name_word = "walldown";
            }
            if (hit2.collider.gameObject.tag == "wallleft")
            {
                direction_name_word = "wallleft";
            }
            if (hit2.collider.gameObject.tag == "wallrigth")
            {
                direction_name_word = "wallrigth";
            }
        }
        if (Physics.Raycast(ray.origin, ray.direction, out hit, direction_forllow))
        {
            if (hit.collider.gameObject != null)
            {
                Debug.Log("hit");
                if (direction_name_word == "wallleft")
                {
                    //go behind
                    if (relativePos.x == -1)
                    {
                        relative = new Vector3(1, 0, 0);
                    }
                    //go down
                    else if (relativePos.z < 0)
                    {
                        relative = new Vector3(1, 0, -1);
                    }
                    //go top
                    else if (relativePos.z > 0)
                    {
                        relative = new Vector3(1, 0, 1);
                    }
                }
                else if (direction_name_word == "wallrigth")
                {
                    //go behind
                    if (relativePos.x == 1)
                    {
                        relative = new Vector3(-1, 0, 0);
                    }
                    //go down
                    else if (relativePos.z < 0)
                    {
                        relative = new Vector3(-1, 0, -1);
                    }
                    //go top
                    else if (relativePos.z > 0)
                    {
                        relative = new Vector3(-1, 0, 1);
                    }
                }
                else if (direction_name_word == "walltop")
                {
                    //go behind
                    if (relativePos.z == 1)
                    {
                        relative = new Vector3(0, 0, -1);
                    }
                    //go Left
                    if (relativePos.x < 0)
                    {
                        relative = new Vector3(-1, 0, -1);
                    }
                    //go Rigth
                    else if (relativePos.x > 0)
                    {
                        relative = new Vector3(1, 0, -1);
                    }
                }
                else if (direction_name_word == "walldown")
                {
                    //go behind
                    if (relativePos.z == -1)
                    {
                        relative = new Vector3(0, 0, 1);
                    }
                    //go Left
                    else if (relativePos.x < 0)
                    {
                        relative = new Vector3(-1, 0, 1);
                    }
                    //go Rigth
                    else if (relativePos.x > 0)
                    {
                        relative = new Vector3(1, 0, 1);
                    }
                }

                transform.rotation = Quaternion.LookRotation(relative);
            }
        }

    }

    IEnumerator fire_bullet()
    {
        if (can_fire == true)
        {
            for (int i = 0; i < max_fire; i++)
            {
                Instantiate(bullet, spawn_bullet.transform.position, spawn_bullet.transform.localRotation);
            }
            can_fire = false;
        }
        yield return null;
    }
}
