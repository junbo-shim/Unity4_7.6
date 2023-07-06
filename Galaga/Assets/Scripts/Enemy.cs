using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public float speed = 1.0f;
    private Rigidbody enemyRigidBody;
    ///////////////////////////////////////////////////////////////
    public GameObject enemyBulletPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 2f;

    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;
    ///////////////////////////////////////////////////////////////
    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody>();

        enemyRigidBody.velocity = transform.forward * speed;

        Destroy(gameObject, 8.0f);
        ///////////////////////////////////////////////////////////////
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<PlayerController>().transform;
    }
    ///////////////////////////////////////////////////////////////
    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            GameObject bullet = Instantiate(enemyBulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target);
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }

    }
    ///////////////////////////////////////////////////////////////
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.Die();
            }
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }

}
