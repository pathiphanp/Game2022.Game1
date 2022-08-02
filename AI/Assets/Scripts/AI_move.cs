using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_move : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] bool str_rnd;

    int i;
    [SerializeField] float delay;
    [SerializeField] float speed_ro;
    [SerializeField] float speed_move;

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
           i = rnd.Next(0, 2);
            str_rnd = false;
            StartCoroutine(delay_rnd());         
        }


        if (i == 0)
        {
            rb.velocity = transform.forward * speed_move;
            transform.Rotate(0, speed_ro * Time.deltaTime, 0);
        }

        else if (i == 1)
        {
            rb.velocity = transform.forward * speed_move;
            transform.Rotate(0, -speed_ro * Time.deltaTime, 0);
        }
        else if (i == 2)
        {
            rb.velocity = transform.forward * speed_move;
        }
    }

    IEnumerator delay_rnd()
    {
        yield return new WaitForSeconds(delay);
        str_rnd = true;
    }
}
