using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float speedFollow; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }
    void FollowPlayer()
    {
        transform.position = Vector3.Lerp(transform.position,new Vector3(player.transform.position.x,player.transform.position.y,transform.position.z),speedFollow * Time.deltaTime);   
    }
}
