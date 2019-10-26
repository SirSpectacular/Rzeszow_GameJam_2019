using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> packets;
    public List<GameObject> spawnedPackets;
    public Transform SpawnPoint;
    public Transform Player;
    public float speed;
    private float speedSum;
    private float timeSum;
    void Start()
    {
        speed = 0.01f;
        speedSum = 0;
        timeSum = 0;
        GameObject newPacket = GameObject.Instantiate(packets[0]);
        newPacket.transform.parent = gameObject.transform;
        spawnedPackets.Add(newPacket);
        for(int i = 0; i < 2; i++)
        {
            newPacket = GameObject.Instantiate(packets[Random.Range(1, packets.Count-1)]);
            newPacket.transform.parent = gameObject.transform;
            newPacket.transform.position = new Vector2(spawnedPackets[spawnedPackets.Count - 1].transform.position.x, spawnedPackets[spawnedPackets.Count-1].transform.position.y + spawnedPackets[spawnedPackets.Count - 1].GetComponent<PackageHeight>().height);
            spawnedPackets.Add(newPacket);
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
                    GameObject newPacket = GameObject.Instantiate(packets[Random.Range(1, packets.Count - 1)]);
                    newPacket.transform.parent = gameObject.transform;
                    newPacket.transform.position = new Vector2(spawnedPackets[spawnedPackets.Count - 1].transform.position.x, spawnedPackets[spawnedPackets.Count - 1].transform.position.y + spawnedPackets[spawnedPackets.Count - 1].GetComponent<PackageHeight>().height);
                    spawnedPackets.Add(newPacket);
                }
                else
                {
                    spawnedPackets[i].transform.position = new Vector2(spawnedPackets[i].transform.position.x, spawnedPackets[i].transform.position.y - (speed + speedSum) * Time.deltaTime);
                }
            }
        }
        speedSum += 0.00001f;     
        if(Player.position.y > 0)
        {
            for (int i = 0; i < spawnedPackets.Count; i++)
            {
                if (spawnedPackets[i] != null)
                {
                        spawnedPackets[i].transform.position = new Vector2(spawnedPackets[i].transform.position.x, spawnedPackets[i].transform.position.y - (1 + speedSum) * Mathf.Max(2, Player.position.y*2) * Time.deltaTime);
                }
            }
        }
    }
}
