using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public LayerMask player;
    public int roX;
    public int roZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CoinRotation();
    }
    //หมุนX กับ Z
    void CoinRotation()
    {
        transform.Rotate(roX * Time.deltaTime,0,roZ * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider coin)
    {
        if(coin != null)
        {
            Destroy(gameObject);
        }

    }
}
