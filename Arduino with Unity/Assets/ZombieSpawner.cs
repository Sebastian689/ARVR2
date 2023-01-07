using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombie;
    // Start is called before the first frame update
    void Start()
    {
        SpawnZombie();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnZombie()
    {
        int xcount = Random.Range(10, 20);
        int zcount = Random.Range(10, 20);
        

        Vector3 position = new Vector3(xcount, 0, zcount);

        Instantiate(zombie, position, Quaternion.identity);
        Invoke("SpawnZombie", 3);
    }
}
