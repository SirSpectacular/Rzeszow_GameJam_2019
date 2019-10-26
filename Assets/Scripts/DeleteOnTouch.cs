using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnTouch : MonoBehaviour
{
    public Spawner spawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spawner.spawnedPackets.Remove(collision.gameObject);
        Destroy(collision.gameObject.transform.parent.gameObject);
    }
}
