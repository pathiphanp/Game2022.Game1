using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject[] weapon_all;

    public GameObject piston_gun;

    public GameObject gun_in_hand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        piston_gun.transform.position = gun_in_hand.transform.position;
    }
}
