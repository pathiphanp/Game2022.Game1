using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform[] background;
    private float[] paralaxScales;
    public float smoothing = 1f;
    private Transform cam;
    private Vector3 previousCamPos;

     void Awake()
    {
        cam = Camera.main.transform; 
    }



     void Start()
    {
        previousCamPos = cam.position;

        paralaxScales = new float[background.Length];

        for(int i = 0; i<background.Length; i++ )
        {
            paralaxScales[i] = background[i].position.z * -1;
        }


        
    }

    void Update()
    {
      for(int i =0; i < background.Length; i++)
        {
            float parallax = (previousCamPos.x - cam.position.x) * paralaxScales[i];
            float backgroundTargetPosX = background[i].position.x + parallax;

            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, background[i].position.y, background[i].position.z);
            background[i].position = Vector3.Lerp(background[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }
        previousCamPos = cam.position;

        
    }
}
