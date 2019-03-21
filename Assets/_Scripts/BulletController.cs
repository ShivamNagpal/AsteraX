using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 15f;

    private new Rigidbody rigidbody;
    private float destroyAfter = 2.0f;

    private void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        rigidbody.velocity = transform.up * speed;
        Destroy(this.gameObject, destroyAfter);
    }

}
