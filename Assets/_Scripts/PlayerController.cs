using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public LayerMask backgroundLayerMask;

    private int backgroundLayerMaskIndex;
    private new Rigidbody rigidbody;
    private float horizontalMovement;
    private float verticalMovement;

    private void Start()
    {
        FlushMovement();
        backgroundLayerMaskIndex = backgroundLayerMask.value;
        Debug.Log(backgroundLayerMaskIndex);
        rigidbody = this.GetComponent<Rigidbody>();
    }

    private void FlushMovement()
    {
        horizontalMovement = 0.0f;
        verticalMovement = 0.0f;
    }

    private void Update()
    {
        horizontalMovement += Input.GetAxis("Horizontal");
        verticalMovement += Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 movement = new Vector3(horizontalMovement, verticalMovement);
        movement = movement.normalized * speed * Time.fixedDeltaTime;

        rigidbody.MovePosition(this.transform.position + movement);

        FlushMovement();
    }

}
