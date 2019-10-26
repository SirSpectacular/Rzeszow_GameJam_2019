using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour{

    [SerializeField] Fade fade;
    [SerializeField] GameObject gameOverScreen;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            StartCoroutine("EndGame");
        }
    }

    IEnumerator EndGame() {
        yield return fade.FadeOut(1f);
        
        Instantiate<GameObject>(gameOverScreen,new Vector2(0,0), Quaternion.identity);
    }
}
