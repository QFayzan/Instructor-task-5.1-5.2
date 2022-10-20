using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject spawnpoint1;    // Start is called before the first frame update
    public GameObject spawnpoint2;   
    public GameObject spawnpoint3;   
    public GameObject barrel;
    public float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 10)
        {
            SpawnEnemy1();
            SpawnEnemy2();
            SpawnEnemy3();
            timer = 0;
        }
    }
    void SpawnEnemy1()
    {
        Vector3 spawnpos1 = spawnpoint1.transform.position;
        Instantiate(barrel , spawnpos1 , barrel.transform.rotation);
    }
    void SpawnEnemy2()
    {
        Vector3 spawnpos2 = spawnpoint2.transform.position;
        Instantiate(barrel, spawnpos2, barrel.transform.rotation);

    }
        void SpawnEnemy3() 
    {
        Vector3 spawnpos3 = spawnpoint3.transform.position;
        Instantiate(barrel, spawnpos3, barrel.transform.rotation);
    }
}
