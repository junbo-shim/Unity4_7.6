using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyRespawner : MonoBehaviour
{
    // Enemy 그룹을 생성해서 내려보낼 출발점 1, 2
    public GameObject enemyRespawnPoint1;
    public GameObject enemyRespawnPoint2;

    // 불러올 Enemy 개체
    public GameObject enemyPrefab;
    //public float speed = 5.0f;

    // 스폰할 시간 간격
    public float spawnRateMin = 6.0f;
    public float spawnRateMax = 8.0f;

    // 스폰 시간 변수
    private float spawnRate;
    private float timeAfterSpawn;

    // 첫 Enemy 스폰 포지션
    private Vector3 startSpawnLocation1;
    private Vector3 startSpawnLocation2;

    // Enemy의 행렬 설정
    private float row = 2.0f;
    private float column = 3.0f;
    // Enemy 몇칸 띄울지 변수 선언
    private float spaceX = 2.0f;
    private float spaceZ = 2.0f;






    // Start is called before the first frame update
    void Start()
    {
        // 스폰 시간 0으로 초기화
        timeAfterSpawn = 0f;
        // 스폰 시간 범위는 Min에서 Max이다
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);


        // 스폰 기준점 설정
        startSpawnLocation1 = new Vector3(-8.5f, 0.5f, 13.5f);
        startSpawnLocation2 = new Vector3(0.5f, 0.5f, 13.5f);



        // 중첩 for문 - 좌측 스폰
        for (int j = 0; j < row; j++)
        {
            for (int i = 0; i < column; i++)
            {
                startSpawnLocation1.x += spaceX;
                GameObject enemy = Instantiate(enemyPrefab, startSpawnLocation1, transform.rotation, enemyRespawnPoint1.transform);


            }
            startSpawnLocation1.x = -8.5f;
            startSpawnLocation1.z -= spaceZ;

        }
        startSpawnLocation1 = new Vector3(-8.5f, 0.5f, 13.5f);



        // 홍씨가 한것
        // 중첩 for문 - 우측 스폰
        for (int j = 0; j < row; j++)
        {
            for (int i = 0; i < column; i++)
            {
                startSpawnLocation2.x += spaceX;
                GameObject enemy = Instantiate(enemyPrefab, startSpawnLocation2, transform.rotation, enemyRespawnPoint2.transform);


            }
            startSpawnLocation2.x = 0.5f;
            startSpawnLocation2.z -= spaceZ;

        }
        startSpawnLocation2 = new Vector3(0.5f, 0.5f, 13.5f);
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;



            // 중첩 for문 - 좌측 스폰
            for (int j = 0; j < row; j++)
            {
                for (int i = 0; i < column; i++)
                {
                    startSpawnLocation1.x += spaceX;
                    GameObject enemy = Instantiate(enemyPrefab, startSpawnLocation1, transform.rotation, enemyRespawnPoint1.transform);


                }
                startSpawnLocation1.x = -8.5f;
                startSpawnLocation1.z -= spaceZ;

            }
            startSpawnLocation1 = new Vector3(-8.5f, 0.5f, 13.5f);



            // 홍씨가 한것
            // 중첩 for문 - 우측 스폰
            for (int j = 0; j < row; j++)
            {
                for (int i = 0; i < column; i++)
                {
                    startSpawnLocation2.x += spaceX;
                    GameObject enemy = Instantiate(enemyPrefab, startSpawnLocation2, transform.rotation, enemyRespawnPoint2.transform);


                }
                startSpawnLocation2.x = 0.5f;
                startSpawnLocation2.z -= spaceZ;

            }
            startSpawnLocation2 = new Vector3(0.5f, 0.5f, 13.5f);



            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
