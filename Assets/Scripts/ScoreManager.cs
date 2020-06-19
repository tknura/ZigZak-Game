using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score;
    public int highscore;
    public Text[] scoreTexts;
    public Text[] highscoreTexts;

    void Awake()
    {
        if(instance == null) {
            instance = this;
            highscore = 0;
        } 
    }

   void Start() {
        score = 0;
        PlayerPrefs.SetInt("score", score);
        UpdateScoreText();
    }

    public void IncScore() {
        score++;
        UpdateScoreText();
    }

    public void IncScoreByInt(int number) {
        score += number;
        UpdateScoreText();
    }

    public void SaveScore() {
        PlayerPrefs.SetInt("score", score);
        if(PlayerPrefs.HasKey("highScore")) {
            if(score > highscore) {
                highscore = score;
                PlayerPrefs.SetInt("highscore", highscore);
                UpdateHighScore();
            }
        } 
        else {
            PlayerPrefs.SetInt("highscore", score);
            UpdateHighScore();
        }
        
    }

    void UpdateScoreText() {
        foreach(Text scoreText in scoreTexts) {
            scoreText.text = score.ToString();
        }
    }

    public void UpdateHighScore() {
        PlayerPrefs.GetInt("highscore", highscore);
        foreach(Text scoreText in highscoreTexts) {
            scoreText.text = highscore.ToString();
        }
    }
}
