using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game002 : MonoBehaviour
{
    Rigidbody rb;
    public game001 game0001;
    public Nomor nomor;
    int a;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        game0001.game();

        game0001.game(a);
    }
}
