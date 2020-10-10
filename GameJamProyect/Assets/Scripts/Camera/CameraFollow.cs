using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    [SerializeField] float smoothSpeed=0.125f;
    [SerializeField] Vector3 offset;

    void FixedUpdate()
    {
        Vector3 newPosition = target.position + offset;
        Vector3 smoothMovement = Vector3.Lerp(transform.position, newPosition, smoothSpeed);
        transform.position = smoothMovement;
        transform.LookAt(target);
    }
}
