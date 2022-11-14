using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCarMovement : MonoBehaviour
{
    public float speed = 50f, rotationSpeed = 50f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 rotation = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(transform.forward * speed * Time.fixedDeltaTime, ForceMode.Acceleration);
            
        } else if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(-transform.forward * speed * Time.fixedDeltaTime, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddTorque(Vector3.up * rotationSpeed, ForceMode.Acceleration);
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddTorque(Vector3.up * -rotationSpeed, ForceMode.Acceleration);
        }
        
    }

    private void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0);
    }

}
