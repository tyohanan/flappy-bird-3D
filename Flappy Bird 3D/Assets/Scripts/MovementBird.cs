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

    public GameObject fire;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        speedTranslate = minSpeed;
        fire.GetComponent<ParticleSystem>().Stop(true);
    }
    private float startGas = 1f;
    private void Update() {
        transform.Translate(speedTranslate*Time.deltaTime,0,0);
        if (Input.GetKey(KeyCode.UpArrow) && speedTranslate < maxSpeed){
            transform.Translate(speedTranslate*Time.deltaTime,0,0);
            speedTranslate++;
            fire.GetComponent<ParticleSystem>().Play(true);
            }
        else if(speedTranslate > minSpeed){
            speedTranslate--;
        }
        else if (Input.GetKey(KeyCode.LeftArrow)){
            rb.AddRelativeTorque(0,0,forceRotate*Time.deltaTime,ForceMode.Impulse);
            fire.GetComponent<ParticleSystem>().Play(true);
        }
        else if (Input.GetKey(KeyCode.RightArrow)){
            rb.AddRelativeTorque(0,0, -forceRotate*Time.deltaTime, ForceMode.Impulse);
            fire.GetComponent<ParticleSystem>().Play(true);
        }
        else{
            fire.GetComponent<ParticleSystem>().Stop(true);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Environment"){
            Destroy(gameObject);
        }
    }
}
