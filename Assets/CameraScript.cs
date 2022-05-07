using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraScript : MonoBehaviour
{
    Vector3 relativePosition;
    Quaternion targetRotation;
    public Transform target;
    public float speed = 0.01f;

    bool rotating = false;

    float rotationTime; // when rotationTime = 1 then we have rotated fully to target
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.F)){
            relativePosition = target.position - transform.position;
            targetRotation = Quaternion.LookRotation(relativePosition);
            rotating = true;
            rotationTime = 0;
        }
        if (rotating)
        {
          rotationTime += Time.deltaTime * speed;
          transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationTime * speed);
        }
        if (rotationTime > 1)
        {
          rotating = false;
        }
    }
}
