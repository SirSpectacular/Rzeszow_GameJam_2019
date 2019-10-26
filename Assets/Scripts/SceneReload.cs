using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReload : MonoBehaviour { 
    public void Reload() {
        print("reload");
    SceneManager.LoadScene(1);
}

    public void BackToMenu() {
        print("menu");
        SceneManager.LoadScene(0);
    }


    private void Update() {
        if (Input.GetButtonDown("Cancel")) {
            BackToMenu();
        }
        if (Input.GetButtonDown("Jump")) {
            Reload();
        }
    }
}
