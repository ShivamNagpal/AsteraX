using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTurretRotator : MonoBehaviour
{
    public LayerMask backgroundLayerMask;

    private int backgroundLayerMaskIndex;

    private void Start()
    {
        backgroundLayerMaskIndex = backgroundLayerMask.value;
    }

    private void FixedUpdate()
    {
        Turn();
    }

    private void Turn()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit backgroundRayHit;
        if (Physics.Raycast(ray, out backgroundRayHit, Mathf.Infinity, backgroundLayerMaskIndex))
        {
            Vector3 playerToMouse = backgroundRayHit.point - this.transform.position;
            playerToMouse.z = 0;
            Quaternion rotation = Quaternion.LookRotation(playerToMouse, Vector3.back);
            this.transform.rotation = rotation;
            //turrentGameObject.transform.LookAt(playerToMouse, Vector3.back);

        }
    }
}
