using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdjust : MonoBehaviour
{
    public float camVelocity = 5f;

    void Update()
    {
        transform.position = new Vector3(transform.position.x + camVelocity * Time.deltaTime, transform.position.y,transform.position.z);
    }
}
