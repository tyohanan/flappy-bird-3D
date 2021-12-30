using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudLife : MonoBehaviour
{
    [SerializeField]
    private float countdown;
    private float lifeTime;

    private void Awake() {
        lifeTime = countdown;
    }
    void Update()
    {
        float speed = Random.Range(5, 8)*Time.deltaTime*-1;
        transform.Translate(speed, 0, 0);
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0 ){
            Destroy(gameObject);
            lifeTime = countdown;
        }
    }
}
