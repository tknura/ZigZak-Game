using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {
    [HideInInspector] public static SceneChanger instance;
    GameObject activeSceneChanger;

    void Awake() {
        instance = this;
        FadeInScene();
    }

    //public void ChangeSceneByName(string sceneName) {
    //    GetFadeInActiveScene().PlayBackwards();
    //    if(GetFadeInActiveScene().animationCompleted) {
    //        SceneManager.LoadScene(sceneName);
    //        GetActiveSceneChanger();
    //        activeSceneChanger.GetComponentInChildren<CanvasGroup>().alpha = 1;
    //        GetFadeInActiveScene().Play();
    //    }
    //}

    void GetActiveSceneChanger() {
        activeSceneChanger = GameObject.FindWithTag("SceneManagment");
    }

    public void FadeOutScene() {
        GetActiveSceneChanger();
        activeSceneChanger.GetComponentInChildren<DOFadeAnimation>().PlayBackwards();
    }

    public void FadeInScene() {
        GetActiveSceneChanger();
        activeSceneChanger.GetComponentInChildren<CanvasGroup>().alpha = 1;
        activeSceneChanger.GetComponentInChildren<DOFadeAnimation>().Play();
    }

    public void ChangeSceneByName(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
