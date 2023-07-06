using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody playerBulletRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        playerBulletRigidBody = GetComponent<Rigidbody>();

        playerBulletRigidBody.velocity = transform.forward * speed;

        Destroy(gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.Die();
            }
        }
    }
}
