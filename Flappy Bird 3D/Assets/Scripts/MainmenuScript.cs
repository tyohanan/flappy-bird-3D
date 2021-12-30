using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainmenuScript : MonoBehaviour
{

    public GameObject main;
    public GameObject howtoplay;

    private void Start() {
        main.SetActive(true);
        howtoplay.SetActive(false);
    }
    public void StartGame(){
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene("Final Scene", LoadSceneMode.Single);
    }

    public void HowtoPlayButton(){
        FindObjectOfType<AudioManager>().Play("Button");
        main.SetActive(false);
        howtoplay.SetActive(true);
    }

    public void BackButton(){
        FindObjectOfType<AudioManager>().Play("Button");
        main.SetActive(true);
        howtoplay.SetActive(false);
    }
}
