using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour 
{
    public float RUN_SPEED = 3f;
    public float ROATION_ANGLE = 100f;
    Rigidbody _rb;
    
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float v, h;
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
        if(Mathf.Abs(v)>0.2 || Mathf.Abs(h)>0.2)
        {
            _rb.MovePosition(transform.position + transform.forward * Time.deltaTime * v * RUN_SPEED);

            Quaternion deltaRotation = Quaternion.Euler(Vector3.up * h *ROATION_ANGLE*Time.deltaTime);
            _rb.MoveRotation(_rb.rotation * deltaRotation);
        }
        if(Input.GetKey("space"))
        {
            _rb.AddForce(this.transform.up * 100f);
        }
    }
    
}
