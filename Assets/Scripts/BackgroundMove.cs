using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{

    public float speed;
    public float min;
    public float max;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (gameObject.transform.position.y < min)
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, max);
        if(Player.transform.position.y > 0)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - speed * Time.deltaTime * Mathf.Max(2, Player.transform.position.y * 2));
        }
    }
}
