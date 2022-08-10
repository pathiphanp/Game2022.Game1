using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_enemy : MonoBehaviour
{
    public GameObject[] enemy;

    [SerializeField] bool can_spawn;
    [SerializeField] bool count_spawn;

    [SerializeField] int i = 0;
    [SerializeField] int enemy_element;
    [SerializeField] int enemy_max;

    [SerializeField] float spawn_delay;

    // Start is called before the first frame update
    void Start()
    {
    }
        // Update is called once per frame
    void Update()
    {
       StartCoroutine(Spawn_and_Dely());
    }

    IEnumerator Spawn_and_Dely()
    {
        if (can_spawn == true)
        {
            count_spawn = false;
            can_spawn = false;
            for (i = i; i < enemy_max; i++)
            {
                Instantiate(enemy[enemy_element], new Vector3(transform.position.x, enemy[enemy_element].transform.position.y, transform.position.z), enemy[enemy_element].transform.rotation);
                yield return new WaitForSeconds(spawn_delay);
            }
            count_spawn = true;
        }
        if (count_spawn == true)
        {
            if (i < enemy_max)
            {
                can_spawn = true;
            }
        }
    }
}
