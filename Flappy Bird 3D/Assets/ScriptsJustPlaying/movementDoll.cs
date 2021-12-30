using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementDoll : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    private float minSpeed;
    [SerializeField]
    private float maxSpeed;

    private float speedTranslate;

    public float speedRotate;
    private float Yvelocity;
    private float ZrotationPos;

    private void Start() {
        speedTranslate = minSpeed;
        rb = GetComponent<Rigidbody>();
    }
    private void Update() {
        transform.Translate(0,speedTranslate*Time.deltaTime,0);
        if (Input.GetKey(KeyCode.UpArrow) && speedTranslate < maxSpeed){
            transform.Translate(speedTranslate*Time.deltaTime,0,0);
            speedTranslate++;
            }
        else if (Input.GetKey(KeyCode.LeftArrow)){
            rb.AddRelativeTorque(0,0,speedRotate*Time.deltaTime,ForceMode.Impulse);
        }
        else if (Input.GetKey(KeyCode.RightArrow)){
            rb.AddRelativeTorque(0,0, -speedRotate*Time.deltaTime, ForceMode.Impulse);
        }
        else{
        }
}
}