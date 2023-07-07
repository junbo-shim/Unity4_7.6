using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public float speed = 4.5f;
    private Rigidbody enemyRigidBody;
    public GameObject Effect;

    ///////////////////////////////////////////////////////////////
    public GameObject enemyBulletPrefab;
    public float spawnRateMin = 6.0f;
    public float spawnRateMax = 10.0f;

    [SerializeField] private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;
    ///////////////////////////////////////////////////////////////
    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody>();

        enemyRigidBody.velocity = transform.forward * speed;

        Destroy(gameObject, 30.0f);
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
                Instantiate(Effect, transform.position, transform.rotation);
                playerController.Die();
            }
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
        GameManager.killCount ++;
    }

}
