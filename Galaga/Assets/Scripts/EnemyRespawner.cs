using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyRespawner : MonoBehaviour
{
    // Enemy �׷��� �����ؼ� �������� ����� 1, 2
    public GameObject enemyRespawnPoint1;
    public GameObject enemyRespawnPoint2;

    // �ҷ��� Enemy ��ü
    public GameObject enemyPrefab;
    //public float speed = 5.0f;

    // ������ �ð� ����
    public float spawnRateMin = 6.0f;
    public float spawnRateMax = 8.0f;

    // ���� �ð� ����
    private float spawnRate;
    private float timeAfterSpawn;

    // ù Enemy ���� ������
    private Vector3 startSpawnLocation1;
    private Vector3 startSpawnLocation2;

    // Enemy�� ��� ����
    private float row = 2.0f;
    private float column = 3.0f;
    // Enemy ��ĭ ����� ���� ����
    private float spaceX = 2.0f;
    private float spaceZ = 2.0f;






    // Start is called before the first frame update
    void Start()
    {
        // ���� �ð� 0���� �ʱ�ȭ
        timeAfterSpawn = 0f;
        // ���� �ð� ������ Min���� Max�̴�
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);


        // ���� ������ ����
        startSpawnLocation1 = new Vector3(-8.5f, 0.5f, 13.5f);
        startSpawnLocation2 = new Vector3(0.5f, 0.5f, 13.5f);



        // ��ø for�� - ���� ����
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



        // ȫ���� �Ѱ�
        // ��ø for�� - ���� ����
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



            // ��ø for�� - ���� ����
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



            // ȫ���� �Ѱ�
            // ��ø for�� - ���� ����
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
