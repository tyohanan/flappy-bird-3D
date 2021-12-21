using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISystem : MonoBehaviour
{
    public GameObject ObjectScore;
    public GameObject PausedScreen;
    public GameObject PlayedScreen;
    Text ScoreText;

    private void Awake() {
        Time.timeScale = 0;
    }
    private void Start() {
        ScoreText = ObjectScore.GetComponent<Text>();
        ScoreText.text = "HELLO WORLD!";
        StartGame();

    }

    private void Update() 
    {
    }

    public void PauseGame(){
        Time.timeScale = 0;
        showPausedScreen();
    }

    public void StartGame(){
        Time.timeScale = 1;
        showPlayedScreen();
    }

    private void showPausedScreen(){
        PausedScreen.SetActive(true);
        PlayedScreen.SetActive(false);
    }

    private void showPlayedScreen(){
        PlayedScreen.SetActive(true);
        PausedScreen.SetActive(false);
    }
}
