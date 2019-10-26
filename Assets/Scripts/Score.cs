using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour{


    [SerializeField] float score = 0f;
    [SerializeField] Text scoreText = null;

    Vector2 prevPosition;

    private void Awake() {
        prevPosition = transform.position;
    }

    private void Update() {
        score += Time.deltaTime * Random.RandomRange(0f, 10f) * Mathf.Max(transform.position.y - prevPosition.y, 0f);

        scoreText.text = string.Format("{0:0}", score);
    }

}
