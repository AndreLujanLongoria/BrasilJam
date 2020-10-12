using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visual2DOrientation : MonoBehaviour
{
   
    void FixedUpdate()
    {
        transform.LookAt(Camera.main.transform);
    }
}
