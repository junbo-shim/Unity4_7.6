using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody enemyBulletRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        enemyBulletRigidBody = GetComponent<Rigidbody>();

        enemyBulletRigidBody.velocity = transform.forward * speed;

        Destroy(gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

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
}
