using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    public float speed = 8f;
    public float tilt = 3f;
    public float fireInterval = 0.1f;
    public LayerMask backgroundLayerMask;
    public Transform bulletSpawnPoint;

    private new Rigidbody rigidbody;
    private float horizontalMovement;
    private float verticalMovement;
    private float nextFire;

    private void Start()
    {
        FlushMovement();
        nextFire = 0f;
        rigidbody = this.GetComponent<Rigidbody>();
    }

    private void FlushMovement()
    {
        horizontalMovement = 0.0f;
        verticalMovement = 0.0f;
    }

    private void Update()
    {
        horizontalMovement += CrossPlatformInputManager.GetAxis("Horizontal");
        verticalMovement += CrossPlatformInputManager.GetAxis("Vertical");

        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            if (Time.time >= nextFire)
            {
                nextFire = Time.time + fireInterval;
                Fire();
            }
        }
    }

    private void FixedUpdate()
    {
        Move();

        Tilt();
    }

    private void Move()
    {
        Vector3 movement = new Vector3(horizontalMovement, verticalMovement);
        rigidbody.velocity = movement.normalized * speed;

        FlushMovement();
    }

    private void Tilt()
    {
        rigidbody.rotation = Quaternion.Euler(tilt * rigidbody.velocity.y, -1 * tilt * rigidbody.velocity.x, 0f);
    }

    private void Fire()
    {
        Vector3 spawnPosition = bulletSpawnPoint.transform.position;
        spawnPosition.z = 0f;
        Vector3 spawnRotation = bulletSpawnPoint.transform.rotation.eulerAngles;
        spawnRotation.x = 0f;
        spawnRotation.y = 0f;

        GameObject bullet = GameManager.GetBullet();

        bullet.transform.position = spawnPosition;
        bullet.transform.rotation = Quaternion.Euler(spawnRotation);

        bullet.SetActive(true);
    }
}
