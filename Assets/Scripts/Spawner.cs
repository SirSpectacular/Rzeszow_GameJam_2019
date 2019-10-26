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
    void Start()
    {
        GameObject newPacket = Instantiate(packets[0]);
        spawnedPackets.Add(newPacket);

        for(int i = 0; i< 4; i++)
        {
            newPacket = Instantiate(packets[Random.Range(1, packets.Count - 1)]);
            spawnedPackets.Add(newPacket);
            if(i != 0)
                newPacket.transform.position = new Vector2(0, spawnedPackets[spawnedPackets.Count - 1].transform.position.y + spawnedPackets[spawnedPackets.Count - 1].GetComponent<PackageHeight>().height * (1+i));
            else
                newPacket.transform.position = new Vector2(0, spawnedPackets[spawnedPackets.Count - 1].transform.position.y + spawnedPackets[spawnedPackets.Count - 1].GetComponent<PackageHeight>().height * (1 + i) -14);

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
                    GameObject newPacket = GameObject.Instantiate(packets[Random.Range(1, packets.Count - 1)]);
                    newPacket.transform.position = new Vector2(0, spawnedPackets[spawnedPackets.Count - 1].transform.position.y + spawnedPackets[spawnedPackets.Count - 1].GetComponent<PackageHeight>().height);
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
        speedSum += 0.00001f;
        
    }
}
