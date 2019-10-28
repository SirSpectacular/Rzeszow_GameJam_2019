using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour{


    CanvasGroup canvasGroup = null;

    private void Awake() {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start() {
        StartCoroutine("StartScene");
    }

    IEnumerator StartScene() {
        yield return FadeIn(1f);
    }


    public IEnumerator FadeOut(float timeToFade) {
        canvasGroup.alpha = 0;
        while (!Mathf.Approximately(canvasGroup.alpha, 1)) {
            canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, 1, Time.deltaTime / timeToFade);
            yield return null;
        }
    }

    public IEnumerator FadeIn(float timeToFade) {
        canvasGroup.alpha = 1;
        while (!Mathf.Approximately(canvasGroup.alpha, 0)) {
            canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, 0, Time.deltaTime / timeToFade);
            yield return null;
        }
    }

}
