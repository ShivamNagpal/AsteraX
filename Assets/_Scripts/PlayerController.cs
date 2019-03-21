using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    public float speed = 8f;
    public float tilt = 3f;
    public LayerMask backgroundLayerMask;

    private int backgroundLayerMaskIndex;
    private new Rigidbody rigidbody;
    private float horizontalMovement;
    private float verticalMovement;

    private void Start()
    {
        FlushMovement();
        backgroundLayerMaskIndex = backgroundLayerMask.value;
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
}
