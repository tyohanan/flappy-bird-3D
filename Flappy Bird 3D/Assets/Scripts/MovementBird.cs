using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBird : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    private float minSpeed;
    [SerializeField]
    private float maxSpeed;
    private float speedTranslate;

    public float forceRotate;
    private float Yvelocity;
    private float ZrotationPos;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        speedTranslate = minSpeed;
    }

    private void Update() {
        // Debug.Log(speedTranslate);
        transform.Translate(speedTranslate*Time.deltaTime,0,0);
        if (Input.GetKey(KeyCode.UpArrow) && speedTranslate < maxSpeed){
            transform.Translate(speedTranslate*Time.deltaTime,0,0);
            speedTranslate++;
            }
        else if(speedTranslate > minSpeed){
            speedTranslate--;
        }
        Yvelocity = rb.velocity.y;
        ZrotationPos = transform.rotation.z;

        if (Input.GetKey(KeyCode.LeftArrow)){
            rb.AddRelativeTorque(0,0,forceRotate*Time.deltaTime,ForceMode.Impulse);
        }
        else if (Input.GetKey(KeyCode.RightArrow)){
            rb.AddRelativeTorque(0,0, -forceRotate*Time.deltaTime, ForceMode.Impulse);

        }
    }
}
