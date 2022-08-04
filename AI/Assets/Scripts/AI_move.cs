using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_move : MonoBehaviour
{
    public GameObject target;

    Rigidbody rb;
    [SerializeField] bool str_rnd;

    int i;

    [SerializeField] float direction;
    [SerializeField] float time;
    [SerializeField] float ro;
    [SerializeField] float ro_max;
    [SerializeField] float ro_min;
    [SerializeField] float delay;
    [SerializeField] float delay_ro;
    [SerializeField] float delay_normal;
    [SerializeField] float delay_atk;
    [SerializeField] float speed_ro;
    [SerializeField] float speed_ro_left;
    [SerializeField] float speed_ro_rigth;
    [SerializeField] float speed_ro_reverse;
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
        chackwall();
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

    void chackwall()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * direction);

        if (Physics.Raycast(transform.position,transform.forward,out hit,direction))
        {
            if (hit.collider.gameObject.tag == "wall")
            {
                speed_ro += speed_ro_reverse;
            }
            Debug.Log(hit.collider.gameObject.name);
        }
    }
}
