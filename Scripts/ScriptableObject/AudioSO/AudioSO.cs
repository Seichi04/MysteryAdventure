using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


[CreateAssetMenu(fileName = "Audio", menuName = "Custom/Audio")]
public class AudioSO : ScriptableObject
{
    [Header("Player")]
    public AudioClip Move_LadderAudio; //
    public AudioClip JumpAudio;//
    public AudioClip LandAudio;//
    public AudioClip NomalAttackAudio;//
    public AudioClip DashAttackAudio;//
    public AudioClip HurtAudio;//
    public AudioClip DeathAudio;//
    public AudioClip SlideAudio;//
    public AudioClip DashAudio;//

    [Header("UI")]
    public AudioClip ClickButtonAudio;
    public AudioClip DialogText;//

    [Header("Buff")]
    public AudioClip CollectBuffAudio;

    [Header("Enemy")]
    public AudioClip FireSkullVoice;//
    public AudioClip FireSkullDash;//

    public AudioClip FlyDemonShoot;//
    public AudioClip Fly1;//
    public AudioClip Fly2;//
    public AudioClip Fly3;//
    public AudioClip Fly4;//
    public AudioClip Fly5;//

    public AudioClip LizardShoot;//

    public AudioClip OrcVoiceNomal;//
    public AudioClip OrcAttack;//

    public AudioClip SkeletonWalk;//

    public AudioClip StoneGolemShoot;//
    public AudioClip StoneGolemLaser;//
    public AudioClip StoneGolemDash;//

    [Header("BGM")]
    public AudioClip Scene1Start;
    public AudioClip Scene1Cave;

    [Header("Other")]
    public AudioClip EarthQuakeSound;//

    [Header("Audio Mixer")]
    public AudioMixerGroup MasterVolumn;//
    public AudioMixerGroup BGMVolumn;//
    public AudioMixerGroup SFXVolumn;//
    public AudioMixerGroup ButtonVolumn;//
    public AudioMixerGroup EnemyVolumn;//
    public AudioMixerGroup PlayerVolumn;//

    
}
