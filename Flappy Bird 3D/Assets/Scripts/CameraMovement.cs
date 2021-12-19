using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Bird;
    private Transform birdTransform;
    private void Start() {
        birdTransform = Bird.GetComponent<Transform>();
    }

    private void Update() {
        transform.position = new Vector3 (birdTransform.position.x, transform.position.y, transform.position.z);
    }
}
