using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UISystem : MonoBehaviour
{
    public GameObject ObjectScore;
    public GameObject HighestScore;
    public GameObject PausedScreen;
    public GameObject PlayedScreen;
    public GameObject GameOverScreen;
    public int ScoreNumber;
    private int highestScoreNumber = 0;
    Text ScoreText;
    Text highestScoreText;

    private void Awake() {
        Time.timeScale = 0;
    }
    private void Start() {
        ScoreText = ObjectScore.GetComponent<Text>();
        highestScoreText = HighestScore.GetComponent<Text>();
        StartGame();
    }

    private void Update() {
        ScoreText.text = ScoreNumber.ToString();
        highestScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
        if (ScoreNumber > PlayerPrefs.GetInt("HighScore")){
            highestScoreNumber = ScoreNumber;
            PlayerPrefs.SetInt("HighScore", highestScoreNumber);
        }
    }



    public void PauseGame(){
        Time.timeScale = 0;
        showPausedScreen();
        FindObjectOfType<AudioManager>().Play("Button");
    }

    public void StartGame(){
        Time.timeScale = 1;
        showPlayedScreen();
        FindObjectOfType<AudioManager>().Play("Button");
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        FindObjectOfType<AudioManager>().Play("Button");
    }

    public void MainMenuGame(){
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
        FindObjectOfType<AudioManager>().Play("Button");      
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
