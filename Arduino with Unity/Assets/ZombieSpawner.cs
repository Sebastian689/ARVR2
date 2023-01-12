using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombie;

    public AudioSource zombiespawnerAudioSource;
    public float repeatTimer = 32.0f;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        SpawnZombie();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > repeatTimer){
            zombiespawnerAudioSource.PlayOneShot(zombiespawnerAudioSource.clip);
            timer = 0;
        }
    }

    void SpawnZombie()
    {
        int xcount = Random.Range(5, 10);
        int zcount = Random.Range(5, 10);
        

        Vector3 position = new Vector3(xcount, 0, zcount);

        Instantiate(zombie, position, Quaternion.identity);
        Invoke("SpawnZombie", 3);
    }
}
