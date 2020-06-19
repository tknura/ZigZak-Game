using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;
    public static bool gameOver;

    void Awake() {
        if(instance == null) {
            instance = this;
        }
    }

    private void Start() {
        gameOver = false;

    }

    void Update() {
    }

    public void StartGame() {
        InterfaceManager.instance.SetSaturation(1f);
    }

    public void GameOver() {
        gameOver = true;
        InterfaceManager.instance.ShowGameOverPanel();
        ScoreManager.instance.SaveScore();
    }

    public void OpenMenu() {
        SceneChanger.instance.ChangeSceneByName("MainMenu");
        ScoreManager.instance.UpdateHighScore();
    }

    public void QuitGame() {
        Application.Quit();
    }
}
