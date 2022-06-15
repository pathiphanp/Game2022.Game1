using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class control : MonoBehaviour
{

    public TextMesh speed;
    public float addforward;
    public float gearSpeed;
    public float gear;
    public float addrigth;
    public float dragContor;
    public bool changeMode;
    public float respeed;

    public int addUp;
    //public int addrigth;

    public bool onOff;
    //public float pown;
    //public float timeToUP;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("r"))
        {
            changeMode = true;
        }
        if (Input.GetKey("t"))
        {
            changeMode = false;
        }

        if (changeMode == false)
        {
            rb.AddForce(transform.forward * gear * addforward * Time.deltaTime);
            if (Input.GetKey("q"))
            {
                OnOff(gearSpeed);
                gearSpeed = 1;
            }
            if (Input.GetKey("e"))
            {
                OnOff(gearSpeed);
                gearSpeed = -1;
            }
            if (Input.GetKey("w"))
            {
                rb.AddTorque(transform.right  * addforward * Time.deltaTime);
            }
            if (Input.GetKey("s"))
            {
                rb.AddTorque(-transform.right  * addforward * Time.deltaTime);
            }
            if (Input.GetKey("a"))
            {
                rb.AddTorque(transform.forward  * addrigth * Time.deltaTime);
            }
            if (Input.GetKey("d"))
            {
                rb.AddTorque(-transform.forward  * addrigth  * Time.deltaTime);
            }
            if (Input.GetKey("up"))
            {
                rb.AddForce(transform.up * addUp * Time.deltaTime);
            }
            if (Input.GetKey("down"))
            {
                rb.AddForce(-transform.up * addUp * Time.deltaTime);
            }
            if (Input.GetKey("left"))
            {
                rb.AddTorque(-transform.up * addUp * Time.deltaTime);
            }
            if (Input.GetKey("right"))
            {
                rb.AddTorque(transform.up * addUp * Time.deltaTime);
            }
        }
        if (changeMode == true)
        {            
            Vector3 trueForward = new Vector3(transform.forward.x, 0, transform.forward.z).normalized;
            Vector3 trueRight = new Vector3(transform.right.x, 0, transform.right.z).normalized;
            if (Input.GetKey("q"))
            {
                OnOff(gearSpeed);
                gearSpeed = 1;
            }
            if (Input.GetKey("e"))
            {
                OnOff(gearSpeed);
                gearSpeed = -1;
            }
            if (Input.GetKey("w"))
            {
                rb.AddForce(transform.up * addUp * Time.deltaTime);
            }
            if (Input.GetKey("s"))
            {
                rb.AddForce(-transform.up * addUp * Time.deltaTime);
            }

            if (Input.GetKey("up"))
            {
                rb.AddTorque(transform.right * addforward * Time.deltaTime);
                rb.AddForce(trueForward * addforward * Time.deltaTime);
                rb.AddTorque(Vector3.Cross(transform.up, Vector3.up) * respeed);
            }
            if (Input.GetKey("down"))
            {
                rb.AddTorque(-transform.right * addforward * Time.deltaTime);
                rb.AddForce(-trueForward * addforward * Time.deltaTime);
                rb.AddTorque(Vector3.Cross(transform.up, Vector3.up) * respeed);
            }
            if (Input.GetKey("left"))
            {
                rb.AddTorque(transform.forward * addrigth * Time.deltaTime);
                rb.AddForce(-trueRight * addUp * Time.deltaTime);
                rb.AddTorque(Vector3.Cross(transform.up, Vector3.up) * respeed);
            }
            if (Input.GetKey("right"))
            {
                rb.AddTorque(-transform.forward * addrigth * Time.deltaTime);
                rb.AddForce(trueRight * addUp * Time.deltaTime);
                rb.AddTorque(Vector3.Cross(transform.up, Vector3.up) * respeed);
            }
            rb.AddTorque(Vector3.Cross(transform.up, Vector3.up) * respeed);

        }
        /*Vector3 trueForward = new Vector3(transform.forward.x, 0, transform.forward.z).normalized;
        Vector3 trueRight = new Vector3(transform.right.x, 0, transform.right.z).normalized;
        rb.AddTorque(Vector3.Cross( transform.up, Vector3.up ) * selfRightForce);*/


    }
    void OnOff(float valu)
    {
        speed.text = gear.ToString();
        gear = Mathf.Clamp01(gear + (valu * Time.deltaTime));                     
    }
}
