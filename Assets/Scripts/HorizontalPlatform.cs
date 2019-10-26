using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlatform : MonoBehaviour
{

    public int side;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1000 * side, 1000));
        
    }
}
