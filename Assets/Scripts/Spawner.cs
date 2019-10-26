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
    private float speedSum;
    public GameObject Player;
    private float nextHeight;
    private float currHeight;
    void Start()
    {
        GameObject newPacket = Instantiate(packets[0]);
        spawnedPackets.Add(newPacket);
        nextHeight = 10;
        currHeight = 0;

        for(int i = 0; i< 4; i++)
        {
            int rnd = Random.Range(1, packets.Count - 1);
            newPacket = Instantiate(packets[rnd]);
            spawnedPackets.Add(newPacket);
            newPacket.transform.position = new Vector2(0, currHeight + nextHeight);
            currHeight += nextHeight;
            nextHeight = packets[rnd].GetComponent<PackageHeight>().height;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i< spawnedPackets.Count; i++)
        {
            if(spawnedPackets[i] != null)
            {
                if (spawnedPackets[i].transform.position.y < -25)
                {
                    Destroy(spawnedPackets[i]);
                    spawnedPackets.Remove(spawnedPackets[i]);
                    currHeight = spawnedPackets[spawnedPackets.Count - 1].transform.position.y;
                    nextHeight = spawnedPackets[spawnedPackets.Count - 1].GetComponent<PackageHeight>().height;
                    int rnd = Random.Range(1, packets.Count - 1);
                    GameObject newPacket = Instantiate(packets[rnd]);
                    newPacket.transform.position = new Vector2(0, currHeight + nextHeight);
                    spawnedPackets.Add(newPacket);
                    
                }
                else
                {
                    spawnedPackets[i].transform.position = new Vector2(0, spawnedPackets[i].transform.position.y - (speed + speedSum) * Time.deltaTime);
                }
            }
        }
      

        if(Player.transform.position.y > 0)
        {
            for (int i = 0; i < spawnedPackets.Count; i++)
            {
                spawnedPackets[i].transform.position = new Vector2(spawnedPackets[i].transform.position.x, spawnedPackets[i].transform.position.y -  Mathf.Max(5, Player.transform.position.y * 5) * Time.deltaTime);
            }
        }
        speedSum += 0.00005f;
        
    }
}
