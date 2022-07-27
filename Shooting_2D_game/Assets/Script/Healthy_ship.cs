using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthy_ship : MonoBehaviour
{
    [SerializeField] protected float health, maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void enemy_destroy(float damageAmount)
    {
        health -= damageAmount; 

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
