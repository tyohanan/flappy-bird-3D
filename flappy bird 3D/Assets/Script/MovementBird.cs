using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBird : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 vectorForce;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(vectorForce, ForceMode.Impulse);
        }
    }
}
