using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour{

    [SerializeField] Fade fade;
    [SerializeField] Text credits;
    

    public void BeginGame() {
        StartCoroutine("SceneTransition");
    }
    

    public void Exit() {
        Application.Quit();
     
    }

    public void showCredits() {
        if (!credits.enabled) {
            credits.enabled = true;


        } else {
            credits.enabled = false;
            
        }
    }
 

    IEnumerator SceneTransition() {

        yield return  fade.FadeOut(1f);

        SceneManager.LoadScene(1);
    }


}
