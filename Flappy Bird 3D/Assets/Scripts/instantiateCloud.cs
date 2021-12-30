using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateCloud : MonoBehaviour
{
    public GameObject[] cloud = new GameObject[2];
    
    [SerializeField]
    private float instantiateTime;
    private float speedCloud;
    private void Start() {
        
    }

    private void Update() {
        int cloudNo = Random.Range(0,1);
        speedCloud = Random.Range(5,10);  
        instantiateTime -= Time.deltaTime;
        if (instantiateTime < 0){
            Instantiate(cloud[cloudNo], transform.position, Quaternion.identity);
            instantiateTime = Random.Range(2, 8);
        }      
    }
}
