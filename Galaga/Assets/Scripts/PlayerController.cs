using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public float playerSpeed = 10.0f;
    public float bulletSpeed = 5.0f;
    ///////////////////////////////////////////////////////////////
    public GameObject playerBulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");


        float xSpeed = xInput * playerSpeed;
        float zSpeed = zInput * playerSpeed;
        //float firespeed = fireInput * bulletSpeed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigidbody.velocity = newVelocity;

        if (Input.GetKeyDown(KeyCode.Space)==true)
        {
            GameObject bullet = Instantiate(playerBulletPrefab, transform.position, transform.rotation);
        }

    }

    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}