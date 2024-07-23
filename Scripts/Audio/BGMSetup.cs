using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMSetup : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip Scene1Start;
    public AudioClip Scene1Forest;
    public AudioClip Scene1Cave;
    public AudioClip Scene2;
    public AudioClip Scene3;
    public AudioClip Scene4Start;
    public AudioClip Scene4FightBoss;
    public AudioClip Scene5Start;
    public AudioClip Scene5FightBoss;
    private void Awake() {
        Scene1Start.LoadAudioData();
        Scene1Forest.LoadAudioData();
        Scene1Cave.LoadAudioData();
        Scene2.LoadAudioData();
        Scene3.LoadAudioData();
        Scene4Start.LoadAudioData();
        Scene4FightBoss.LoadAudioData();
        Scene5Start.LoadAudioData();
        Scene5FightBoss.LoadAudioData();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("BGM"))
        {
            if(other.gameObject.GetComponent<BackgroundMusicAdjust>().AudioString == "Scene1Start")
            {
                audioSource.clip = Scene1Start;
            }
            else if(other.gameObject.GetComponent<BackgroundMusicAdjust>().AudioString == "Scene1Forest")
            {
                audioSource.clip = Scene1Forest;
            }
            else if(other.gameObject.GetComponent<BackgroundMusicAdjust>().AudioString == "Scene1Cave")
            {
                audioSource.clip = Scene1Cave;
            }
            else if(other.gameObject.GetComponent<BackgroundMusicAdjust>().AudioString == "Scene2")
            {
                audioSource.clip = Scene2;
            }
            else if(other.gameObject.GetComponent<BackgroundMusicAdjust>().AudioString == "Scene3")
            {
                audioSource.clip = Scene3;
            }
            else if(other.gameObject.GetComponent<BackgroundMusicAdjust>().AudioString == "Scene4Start")
            {
                audioSource.clip = Scene4Start;
            }
            else if(other.gameObject.GetComponent<BackgroundMusicAdjust>().AudioString == "Scene4FightBoss")
            {
                audioSource.clip = Scene4FightBoss;
            }
            else if(other.gameObject.GetComponent<BackgroundMusicAdjust>().AudioString == "Scene5Start")
            {
                audioSource.clip = Scene5Start;
            }
            else if(other.gameObject.GetComponent<BackgroundMusicAdjust>().AudioString == "Scene5FightBoss")
            {
                audioSource.clip = Scene5FightBoss;
            }
            audioSource.Play();
            
        }
    }
}
