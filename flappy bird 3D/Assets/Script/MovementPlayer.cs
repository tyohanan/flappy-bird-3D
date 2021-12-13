using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 Force;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Force, ForceMode.Impulse);
            //transform.Translate(Force);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Force * -1, ForceMode.Impulse);

            //transform.Translate(Force*-1);
        }
    }
}
