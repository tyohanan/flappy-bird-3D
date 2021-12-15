using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBird : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 movementSpeed;
    public float jumpForce;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        // if (Input.GetKeyDown(KeyCode.LeftArrow)){
        //     rb.AddForce(vectorForce, ForceMode.Impulse);
        // }
        // else if (Input.GetKeyDown(KeyCode.RightArrow)){
        //     rb.AddForce(vectorForce*-1, ForceMode.Impulse);
        // }


        //for moving left, right, up
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            transform.Translate(movementSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)){
            transform.Translate(movementSpeed*-1);
        }
        else if (Input.GetKey(KeyCode.Space)){
            rb.velocity += Vector3.up*jumpForce;
        }

        //for adding rotation when up or down
        // print(rb.velocity.y);
        // if (rb.velocity.y >= 0){
        //     transform.Rotate(new Vector3(0,0, 45));
        // }
    }

    private void FixedUpdate() {

    }
}
