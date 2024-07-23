using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickSetup : MonoBehaviour
{
    public AudioSource AudioSource;

    public void PlayClickAudio()
    {
        AudioManager.Instance.PlayClickAudio(AudioSource);
    }
}
