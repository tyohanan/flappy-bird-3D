using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreAdded : MonoBehaviour
{
    private UISystem uiScore;

    private void Start() {
        uiScore = GameObject.FindGameObjectWithTag("UI").GetComponent<UISystem>();
    }
    private void Update() {
        Debug.Log(uiScore.ScoreNumber);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")){
            Debug.Log("IYA SCORE TAMBAH");
            uiScore.ScoreNumber += 1;
        }
    }
}
