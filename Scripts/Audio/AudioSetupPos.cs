using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSetupPos : MonoBehaviour
{
    private Transform AudioListener;
    private AudioSource audioSource;

    private void Start() {
        AudioListener = Camera.main.transform;
        transform.position = new Vector3(transform.position.x,transform.position.y, AudioListener.position.z);
        audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        float distance = Vector2.Distance(AudioListener.position, transform.position);
        if(distance <= audioSource.maxDistance)
        {
            audioSource.enabled = true;
        }
        else
        {
            audioSource.enabled = false;
        }
    }

}
