using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour{

    [SerializeField] Fade fade;

    private void Start() {
        StartCoroutine("StartScene");
    }

    IEnumerator StartScene() {
        yield return fade.FadeIn(1f);
    }

}
