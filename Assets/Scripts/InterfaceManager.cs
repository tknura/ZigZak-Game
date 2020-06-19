using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Events;
using UnityEngine.PostProcessing;

public class InterfaceManager : MonoBehaviour
{
    public PostProcessingProfile postprocessingProfile;
    public static GameObject currentOpenPanel;
    //public UnityEvent OnHideAnim;
    //public UnityEvent OnShowAnim;
    [HideInInspector] public static InterfaceManager instance;
    public GameObject gameOverPanel;

    private void Awake() {
        instance = this;
    }
    public void ChangePanel(GameObject panel) {
        currentOpenPanel = GetActivePanel();
        Hide(currentOpenPanel);
        currentOpenPanel.SetActive(false);
        currentOpenPanel = panel;
        currentOpenPanel.SetActive(true);
        Show(currentOpenPanel);
    }

    void Hide(GameObject panel) {
        //OnHideAnim.Invoke(panel);
        panel.GetComponentInChildren<CanvasGroup>().DOFade(0, 1f);
    }

    void Show(GameObject panel) {
        panel.GetComponentInChildren<CanvasGroup>().DOFade(1, 1f);
    }

    public void SetSaturation(float number) {
        ColorGradingModel.Settings cgSettings = postprocessingProfile.colorGrading.settings;
        cgSettings.basic.saturation = number;
        DOTween.To(() => cgSettings.basic.saturation, x => cgSettings.basic.saturation = x, number, 1f);
        postprocessingProfile.colorGrading.settings = cgSettings;
    }

    GameObject GetActivePanel() {
        return GameObject.FindWithTag("Panel");
    }

    public void ShowGameOverPanel() {
        ChangePanel(gameOverPanel);
        SetSaturation(0f);
    }
}
