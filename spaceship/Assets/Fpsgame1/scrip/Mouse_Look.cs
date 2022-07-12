using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Look : MonoBehaviour
{

    public float mouse_sensitivity;

    public GameObject player_boy;

    public float minClamp;
    public float maxClamp;

    float xRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouse_sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouse_sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minClamp, maxClamp);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        player_boy.transform.Rotate(Vector3.up * mouseX);
    }
}
