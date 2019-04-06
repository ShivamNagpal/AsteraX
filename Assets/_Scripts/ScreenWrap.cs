using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private readonly float error = 0.01f;
    private Collider collider;

    private void Start()
    {
        collider = this.GetComponent<Collider>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ScreenBounds"))
        {
            Vector3 position = this.transform.position;
            Vector3 inverseTransformPosition = other.transform.InverseTransformVector(position);

            if (Mathf.Abs(inverseTransformPosition.x) > 0.5)
            {
                Vector3 point = other.transform.InverseTransformVector(collider.ClosestPoint(new Vector3(0, position.y, 0)));
                float offset = Mathf.Abs(point.x) - 0.5f;
                inverseTransformPosition.x *= -1;
                inverseTransformPosition.x += -Mathf.Sign(inverseTransformPosition.x) * (offset + error);
            }

            if (Mathf.Abs(inverseTransformPosition.y) > 0.5)
            {
                Vector3 point = other.transform.InverseTransformVector(collider.ClosestPoint(new Vector3(position.x, 0, 0)));
                float offset = Mathf.Abs(point.y) - 0.5f;
                inverseTransformPosition.y *= -1;
                inverseTransformPosition.y += -Mathf.Sign(inverseTransformPosition.y) * (offset + error);
            }

            inverseTransformPosition = other.transform.TransformVector(inverseTransformPosition);
            this.transform.position = inverseTransformPosition;
        }
    }
}
