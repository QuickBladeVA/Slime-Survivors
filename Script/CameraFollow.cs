using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour
{
    public Transform target; 
    private Vector3 cameraPosition;

    void Update()
    {
        Movement();

    }
    void Movement () 
    {
        cameraPosition.z = -10;
        cameraPosition.x = target.position.x;
        cameraPosition.y = target.position.y;

        Vector3 Position = cameraPosition;
        transform.position = Position;
    }
}
