using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> packets;
    public List<GameObject> spawnedPackets;
    public Transform SpawnPoint;
    public Transform DeletePoint;
    public float speed;
    private float timer;
    private float speedSum;
    private float timeSum;
    void Start()
    {
        speed = 2;
        timer = 3;
        speedSum = 0;
        timeSum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 3 - timeSum)
        {
            GameObject newPacket = GameObject.Instantiate(packets[Random.Range(0, packets.Count-1)]);
            spawnedPackets.Add(newPacket);
            newPacket.transform.position = SpawnPoint.position;
            timer = 0;
        }
        for(int i = 0; i< spawnedPackets.Count; i++)
        {
            if(spawnedPackets[i] != null)
            {
                spawnedPackets[i].transform.position = new Vector2(spawnedPackets[i].transform.position.x, spawnedPackets[i].transform.position.y - (speed + speedSum) * Time.deltaTime);
            }
        }
      
        timer += Time.deltaTime;
        speedSum += 0.001f;
        timeSum += 0.0005f;
        
    }
}
