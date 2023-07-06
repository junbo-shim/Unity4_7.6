using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyRespawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float speed = 5.0f;

    public float spawnRateMin = 1.5f;
    public float spawnRateMax = 4.0f;

    private float spawnRate;
    private float timeAfterSpawn;

    //private GameObject[] enemyArrays;
    //private int arraysize = 3;

    private Vector3 spawnposition1;
    private Vector3 spawnposition2;
    private Vector3 spawnposition3;




    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        //enemyArrays = new GameObject[arraysize];
        spawnposition1 = new Vector3((float)-8.5, (float)0.5, (float)13.5);
        spawnposition2 = new Vector3((float)-5.5, (float)0.5, (float)13.5);
        spawnposition3 = new Vector3((float)-2.5, (float)0.5, (float)13.5);
        //for(int i = 0; i < (enemyArrays.Length) / 2; i++) 
        //{
        //    spawnposition1 = new Vector3((float)-8.5 + (i*3), (float)0.5, (float)13.5);
        //    spawnposition2 = new Vector3((float)0.5 + (i*3), (float)0.5, (float)13.5);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            //GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
            GameObject enemy1 = Instantiate(enemyPrefab, spawnposition1, transform.rotation);
            GameObject enemy2 = Instantiate(enemyPrefab, spawnposition2, transform.rotation);
            GameObject enemy3 = Instantiate(enemyPrefab, spawnposition3, transform.rotation);


            //for (int i = 0; i < arraysize; i++)
            //{
            //    enemyArrays[i] = Instantiate(enemyPrefab, spawnposition1, transform.rotation);
            //    enemyArrays[i] = Instantiate(enemyPrefab, spawnposition2, transform.rotation);
            //    enemyArrays[i] = Instantiate(enemyPrefab, spawnposition3, transform.rotation);
            //}


            //enemy.transform.LookAt(target);
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
