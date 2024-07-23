using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TestRotation : MonoBehaviour
{
    public float RotateSpeed = 60f;
    public float TimeCount =0;

    private void Update() {
        //transform.eulerAngles = new Vector3(0f,0f,Mathf.PingPong(Time.time * RotateSpeed, 90));
        transform.eulerAngles = new Vector3(0,0,Mathf.Lerp(0,180,TimeCount * RotateSpeed));
        //transform.eulerAngles = new Vector3(0,0,Mathf.Lerp(0,180,TimeCount));
        TimeCount += Time.deltaTime;
    }
}
