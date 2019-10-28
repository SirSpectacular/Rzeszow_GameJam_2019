﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour{

    [SerializeField] Fade fade;
    [SerializeField] TextFader title;
    [SerializeField] TextFader controls;
    [SerializeField] TextFader credits;

    TextFader currentText;

    private void Start() {
        currentText = title;
        currentText.Fade();
    }

    public void BeginGame() {
        StartCoroutine("SceneTransition");
    }
    
    public void Exit() {
        Application.Quit();    
    }

    public void ShowCredits() {
        if (currentText == credits) {
            credits.Fade();
            title.Fade();
            currentText = title;

        } else {
            currentText.Fade();
            credits.Fade();
            currentText = credits;
        }
    }

    public void ShowControls() {
        if (currentText == controls) {
            controls.Fade();
            title.Fade();
            currentText = title;

        } else {
            currentText.Fade();
            controls.Fade();
            currentText = controls;
        }
    }


    IEnumerator SceneTransition() {

        yield return  fade.FadeOut(1f);

        yield return SceneManager.LoadSceneAsync(1);
    }


}
