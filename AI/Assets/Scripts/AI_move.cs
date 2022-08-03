using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_move : MonoBehaviour
{
    public GameObject target;

    Rigidbody rb;
    [SerializeField] bool str_rnd;

    int i = 0   ;
    [SerializeField] float delay;
    [SerializeField] float delay_normal;
    [SerializeField] float delay_atk;
    [SerializeField] float speed_ro;
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
        ai_move_set();
    }

    void ai_move_set()
    {      
        System.Random rnd = new System.Random();
        if (str_rnd == true)
        {
            speed_ro_reverse = 0;
            i = rnd.Next(0, 4);
            str_rnd = false;
            StartCoroutine(delay_rnd());         
        }
        if (i == 0)
        {
            rb.velocity = transform.forward * speed_move;
            transform.Rotate(0, (speed_ro * Time.deltaTime), 0);
        }
        else if (i == 1)
        {
            rb.velocity = transform.forward * speed_move;
            transform.Rotate(0, (-speed_ro * Time.deltaTime), 0);
        }
        else if (i == 2)
        {
            rb.velocity = transform.forward * speed_move;
        }
        else if (i == 3)
        {
            transform.LookAt(target.transform.position);
            transform.Translate(rb.velocity = transform.forward * speed_move * Time.deltaTime);

        }
    }

    IEnumerator delay_rnd()
    {
        yield return new WaitForSeconds(delay);
        str_rnd = true;
    }

    private void OnCollisionEnter(Collision ai)
    {
        if (ai.gameObject.tag == "wallleft" )
        {
           speed_ro_reverse = -320;
           transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y + speed_ro_reverse, transform.rotation.z);
        }
        else if (ai.gameObject.tag == "wallrigth")
        {
            speed_ro_reverse = -120;
            transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y + speed_ro_reverse, transform.rotation.z);
        }
        else if (ai.gameObject.tag == "walldown")
        {
            speed_ro_reverse = 320;
            transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y + speed_ro_reverse, transform.rotation.z);
        }
        if (ai.gameObject.tag == "walltop")
        {
            speed_ro_reverse = 120;
            transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y + speed_ro_reverse, transform.rotation.z);
        }
    }

}
