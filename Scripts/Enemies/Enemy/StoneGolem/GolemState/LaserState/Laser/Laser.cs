using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Laser : MonoBehaviour,IAttackable
{
    [SerializeField] private GameObject LaserBeam;
    [SerializeField] private BoxCollider2D BoxCollider2D;
    [SerializeField] private int Attack;

    public float StartAngle;
    public float EndAngle;
    public float Speed;
    public float TimeRotate;
    public float TimeTemp;
    public float delay;
    public bool IsLaserRotate;

    private float timeStart;

    private void OnEnable() {
        AudioManager.Instance.PlayStoneGolemLaserAudio(GetComponent<AudioSource>(),true);
        CameraShake.instance.ShakeCamera(false);
        GolemReusableData.IsLaserEnd =false;
        timeStart = Time.time;
        TimeTemp = TimeRotate;
        if(IsLaserRotate)
        {
            //Debug.Log(StartAngle);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,StartAngle);
        }
    }

    private void Update() {
        if(IsLaserRotate)
        {
            if(transform.eulerAngles.z != EndAngle && transform.eulerAngles.z != EndAngle + 360)
            {
                //Debug.Log(transform.eulerAngles + " " + new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,EndAngle));
                transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,Mathf.Lerp(StartAngle,EndAngle,Speed * TimeTemp));
                TimeTemp += Time.deltaTime;
            }
            else
            {
                IsLaserRotate = false;
                timeStart = Time.time;
            }
            
        }
        else
            if( Time.time > timeStart + delay)
            {
                gameObject.SetActive(false);
            }
    }

    private void OnDisable() {
        AudioManager.Instance.StopAudio(GetComponent<AudioSource>());
        CameraShake.instance.StopShake();
        GolemReusableData.IsLaserEnd = true;
        LaserBeam.SetActive(false);
        BoxCollider2D.enabled = false;
        IsLaserRotate = false;
    }




    public int GetAttack()
    {
        return Attack;
    }

    public void SetUpRotateLaser(float start,float end)
    {
        //Debug.LogError("Set up");
        IsLaserRotate = true;
        StartAngle = start;
        EndAngle = end;
    }


}
