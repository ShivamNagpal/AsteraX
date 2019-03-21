using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    public float screenWidth = 17.0f;
    public float screenHeight = 10.0f;

    private void Update()
    {
        Vector3 position = gameObject.transform.position;
        if (Mathf.Abs(position.x) > screenWidth)
        {
            position.x = -1 * Mathf.Sign(position.x) * screenWidth;
        }

        if (Mathf.Abs(position.y) > screenHeight)
        {
            position.y = -1 * Mathf.Sign(position.y) * screenHeight;
        }

        this.gameObject.transform.position = position;
    }
}
