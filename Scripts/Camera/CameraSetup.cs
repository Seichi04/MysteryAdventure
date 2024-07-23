using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraSetup : MonoBehaviour
{
    public Collider2D Collider2DStart;
    void Awake()
    {
        GetComponent<CinemachineConfiner2D>().m_BoundingShape2D = Collider2DStart;
    }
}
