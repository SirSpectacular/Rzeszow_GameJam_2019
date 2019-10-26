using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour{

    [SerializeField] Fade fade;

    public void BeginGame() {
        StartCoroutine("SceneTransition");
    }
    

    public void Exit() {
        Application.Quit();
     
    }
 

    IEnumerator SceneTransition() {

        yield return  fade.FadeOut(1f);

        SceneManager.LoadScene(1);
    }


}
