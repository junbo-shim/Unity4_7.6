using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 6.0f;
    private Rigidbody enemyBulletRigidBody;
    public GameObject Effect;

    // Start is called before the first frame update
    void Start()
    {
        enemyBulletRigidBody = GetComponent<Rigidbody>();

        enemyBulletRigidBody.velocity = transform.forward * speed;

        Destroy(gameObject, 4.0f);
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
                Instantiate(Effect, transform.position, transform.rotation);
                playerController.Die();
            }
        }
    }
}
