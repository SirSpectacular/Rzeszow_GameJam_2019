using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBubble : MonoBehaviour
{
    // Start is called before the first frame update

    public GameState gameState;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        gameObject.transform.Rotate(0, 0, -10*Time.deltaTime);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlatformMovement>() != null)
            collision.gameObject.GetComponent<PlatformMovement>().timeScale = gameState.timeScale;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlatformMovement>() != null)
            collision.gameObject.GetComponent<PlatformMovement>().timeScale = 1;
    }
}
