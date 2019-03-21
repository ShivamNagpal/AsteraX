using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 15f;

    private new Rigidbody rigidbody;
    private float initialTime;
    private readonly float destroyAfter = 2.0f;

    private void OnEnable()
    {
        initialTime = Time.time;
        rigidbody = this.GetComponent<Rigidbody>();
        rigidbody.velocity = transform.up * speed;
    }

    private void Update()
    {
        if (Time.time - initialTime >= destroyAfter)
        {
            GameManager.PutBullet(this.gameObject);
        }
    }
}
