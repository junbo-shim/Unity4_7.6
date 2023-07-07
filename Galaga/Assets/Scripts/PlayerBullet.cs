using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 15.0f;
    private Rigidbody playerBulletRigidBody;
    public GameObject Effect;

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
                Instantiate(Effect, transform.position, transform.rotation);
                enemy.Die();
                Destroy(gameObject, 0f);
            }
        }
    }

    //public void Die()
    //{
    //    gameObject.SetActive(false);
    //}
}
