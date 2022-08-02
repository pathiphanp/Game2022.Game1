using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    float length;
    float start_pos;
    
    GameObject cam;
    [SerializeField] float parallax_effect;
    [SerializeField] int time;
 
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        start_pos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    // Update is called once per frame
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallax_effect));
        float distance = (cam.transform.position.x * parallax_effect);
        float str_pus_dis = start_pos + distance;
        transform.position = new Vector3( Mathf.Lerp(transform.position.x,str_pus_dis,time * Time.deltaTime),transform.position.y,transform.position.z);

        if (temp > start_pos + length)
        {
            float gopoint = start_pos += length;
            Mathf.Lerp(start_pos,gopoint,1 * Time.deltaTime);

        }

        else if (temp < start_pos - length)
        {
            float backpoint = start_pos -= length;
            Mathf.Lerp(start_pos,backpoint,1 * Time.deltaTime);
        }
    }
}
