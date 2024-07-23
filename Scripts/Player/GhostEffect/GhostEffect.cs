using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEffect : MonoBehaviour
{
    public float GhostDelayTime;
    public float GhostDelayTimeRemain;
    public string GhostPooledName;

    private void OnEnable() {
        GhostDelayTimeRemain = GhostDelayTime;
    }

    private void Update()
    {
        if(GhostDelayTimeRemain >0)
        {
            GhostDelayTimeRemain -= Time.deltaTime;
        }
        else
        {
            GhostDelayTimeRemain = GhostDelayTime;
            GameObject obj = ObjectPool.instance.GetPooledObject(GhostPooledName);
            obj.transform.SetLocalPositionAndRotation(transform.position, transform.rotation);
            obj.SetActive(true);
        }
    }




}
