using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public LayerMask player;
    public int speed;
    public float delete;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DeleteBullet();
        transform.position += transform.up * speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider bulletX)
    {
        if (bulletX.gameObject.tag == "target")
        {
            Destroy(gameObject);
        }
    }
    void DeleteBullet()
    {
        delete -= Time.deltaTime;
        if(delete <= 0)
        {
            Destroy(gameObject);
        }
    }


}
