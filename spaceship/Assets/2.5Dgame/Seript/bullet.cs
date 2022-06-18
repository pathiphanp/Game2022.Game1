using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public LayerMask player;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision bulletX)
    {
        if (bulletX != null)
        {
            Destroy(gameObject);
        }
    }


}
