using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    public float shakeIntensity = 5f;
    private float shakeTime = 0.2f;
    private CinemachineBasicMultiChannelPerlin _cinemachineBasicMutilChannelPerlin;

    private void Awake() {
        if(instance == null)
        {
            instance = this;
        }

        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        _cinemachineBasicMutilChannelPerlin =  cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void Update() {
        if(Input.GetKey(KeyCode.H))
        {
            ShakeCamera(2);
        }
    }

    public void ShakeCamera(bool AutoStop = true)
    {
        if(AutoStop)
        {
            _cinemachineBasicMutilChannelPerlin.m_AmplitudeGain = shakeIntensity;
            StartCoroutine(StopShakeCoroutine(shakeTime));
        }
        else
        {
            _cinemachineBasicMutilChannelPerlin.m_AmplitudeGain = shakeIntensity;
        }
        AudioManager.Instance.PlayEarthQuakeAudio(GetComponent<AudioSource>(),true);
    }

    public void ShakeCamera(float TimeShake)
    {
        _cinemachineBasicMutilChannelPerlin.m_AmplitudeGain = shakeIntensity;
        StartCoroutine(StopShakeCoroutine(TimeShake));
        AudioManager.Instance.PlayEarthQuakeAudio(GetComponent<AudioSource>(),true);
    }

    public void StopShake()
    {
        _cinemachineBasicMutilChannelPerlin.m_AmplitudeGain = 0f;
        AudioManager.Instance.StopAudio(GetComponent<AudioSource>());
    }

    private IEnumerator StopShakeCoroutine(float timeShake)
    {
        yield return new WaitForSeconds(timeShake);
        StopShake();
        StopAllCoroutines();
    }


}
