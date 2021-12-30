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
    public GameObject BirdDestroyed;
    public GameObject Explosion;
    public UISystem uiControl;
    public FloatingJoystick joystick;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        speedTranslate = minSpeed;
        fire.GetComponent<ParticleSystem>().Stop(true);
    }
    private void Update() {
        // Debug.Log(joystick.Horizontal);
        transform.Translate(speedTranslate*Time.deltaTime,0,0);
        // if (Input.GetKey(KeyCode.UpArrow) && speedTranslate < maxSpeed){
        //     transform.Translate(speedTranslate*Time.deltaTime,0,0);
        //     speedTranslate++;
        //     fire.GetComponent<ParticleSystem>().Play(true);
        //     }

        if (joystick.Vertical > 0){
            fire.GetComponent<ParticleSystem>().Play(true);
            FindObjectOfType<AudioManager>().Play("Booster");
            if (speedTranslate < maxSpeed){
                transform.Translate(speedTranslate*Time.deltaTime,0,0);
                speedTranslate++;
                
            }
        }
        else if(joystick.Vertical < 0 && speedTranslate > minSpeed){
            speedTranslate--;
        }
        // else if (Input.GetKey(KeyCode.LeftArrow)){
        //     rb.AddRelativeTorque(0,0,forceRotate*Time.deltaTime,ForceMode.Impulse);
        //     fire.GetComponent<ParticleSystem>().Play(true);
        // }
        // else if (Input.GetKey(KeyCode.RightArrow)){
        //     rb.AddRelativeTorque(0,0, -forceRotate*Time.deltaTime, ForceMode.Impulse);
        //     fire.GetComponent<ParticleSystem>().Play(true);
        // }
        else if (joystick.Horizontal > 0){
            rb.AddRelativeTorque(0,0,forceRotate*Time.deltaTime,ForceMode.Impulse);
            fire.GetComponent<ParticleSystem>().Play(true);
            FindObjectOfType<AudioManager>().Play("Booster");
        }
        else if (joystick.Horizontal < 0){
            rb.AddRelativeTorque(0,0, -forceRotate*Time.deltaTime, ForceMode.Impulse);
            fire.GetComponent<ParticleSystem>().Play(true);
            FindObjectOfType<AudioManager>().Play("Booster");
        }

        else{
            fire.GetComponent<ParticleSystem>().Stop(true);
            // turboIsPressed = false;
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Environment"){
            Instantiate(Explosion, transform.position, transform.rotation);
            Instantiate(BirdDestroyed, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            gameObject.SetActive(false);
            Invoke("GameOver", 1f);
        }
    }

    // private bool turboIsPressed = false;
    // public void TurboButton(){
    //     turboIsPressed = true;
    // }

    void GameOver(){
        uiControl.GameOverScreen.SetActive(true);
    }
}