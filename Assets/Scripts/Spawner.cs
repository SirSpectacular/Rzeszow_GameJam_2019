using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> packets;
    public List<GameObject> spawnedPackets;
    public Transform SpawnPoint;
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
        for(int i = 0; i< 3; i++)
        {
            GameObject newPacket = GameObject.Instantiate(packets[Random.Range(0, packets.Count - 1)]);
            newPacket.transform.parent = gameObject.transform;
            spawnedPackets.Add(newPacket);
            newPacket.transform.position = new Vector2(SpawnPoint.transform.position.x, SpawnPoint.transform.position.y - 7 * i+1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i< spawnedPackets.Count; i++)
        {
            if(spawnedPackets[i] != null)
            {
                if (spawnedPackets[i].transform.position.y < -10)
                {
                    Destroy(spawnedPackets[i]);
                    spawnedPackets.Remove(spawnedPackets[i]); 
                    GameObject newPacket = GameObject.Instantiate(packets[Random.Range(0, packets.Count - 1)]);
                    newPacket.transform.parent = gameObject.transform;
                    spawnedPackets.Add(newPacket);
                    newPacket.transform.position = SpawnPoint.position;
                }
                else
                {
                    spawnedPackets[i].transform.position = new Vector2(spawnedPackets[i].transform.position.x, spawnedPackets[i].transform.position.y - (speed + speedSum) * Time.deltaTime);
                }
            }
        }
      
        timer += Time.deltaTime;
        speedSum += 0.001f;
        timeSum += 0.0005f;
        
    }
}
