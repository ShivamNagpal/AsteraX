using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private readonly int error = 10;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ScreenBounds"))
        {
            Vector3 position = other.transform.InverseTransformVector(this.transform.position);
            
            if (Mathf.Abs(position.x) > 0.5)
            {
                position.x *= -1;
                position.x += -Mathf.Sign(position.x) * error / Screen.width;
            }

            if (Mathf.Abs(position.y) > 0.5)
            {
                position.y *= -1;
                position.y += -Mathf.Sign(position.y) * error / Screen.height;
            }

            position = other.transform.TransformVector(position);
            this.transform.position = position;
        }
    }
}
