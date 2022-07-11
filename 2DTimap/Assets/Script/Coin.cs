using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public Text poin;

    public int poinPla;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnTriggerEnter2D(Collider2D coin)
    {
        if (coin.gameObject.tag == "player")
        {
            poinPla++;
            poin.text = poinPla.ToString();
            Destroy(gameObject);
        }
    }*/
}
