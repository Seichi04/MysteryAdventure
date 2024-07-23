using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set;}
    [SerializeField] private AudioSO AudioSO;

    private void Awake() {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    #region Player
    public void PlayMoveAudio(AudioSource audioSource,bool IsLoop = false)
    {
        if(audioSource.enabled == false) return;
        audioSource.loop = IsLoop;
        audioSource.clip = AudioSO.Move_LadderAudio;
        audioSource.Play();
    }
    public void PlayJumpAudio(AudioSource audioSource,bool IsLoop = false)
    {
        if(audioSource.enabled == false) return;
        audioSource.loop = IsLoop;
        audioSource.clip = AudioSO.JumpAudio;
        audioSource.Play();
    }
    public void PlayLandAudio(AudioSource audioSource,bool IsLoop = false)
    {
        if(audioSource.enabled == false) return;
        audioSource.loop = IsLoop;
        audioSource.clip = AudioSO.LandAudio;
        audioSource.Play();
    }
    public void PlayDashAudio(AudioSource audioSource,bool IsLoop = false)
    {
        if(audioSource.enabled == false) return;
        audioSource.loop = IsLoop;
        audioSource.clip = AudioSO.DashAudio;
        audioSource.Play();
    }
    public void PlayHurtAudio(AudioSource audioSource,bool IsLoop = false)
    {
        if(audioSource.enabled == false) return;
        audioSource.loop = IsLoop;
        audioSource.clip = AudioSO.HurtAudio;
        audioSource.Play();
    }
    public void PlayDeathAudio(AudioSource audioSource,bool IsLoop = false)
    {
        if(audioSource.enabled == false) return;
        audioSource.loop = IsLoop;
        audioSource.clip = AudioSO.DeathAudio;
        audioSource.Play();
    }
    public void PlayNomalAttackAudio(AudioSource audioSource,bool IsLoop = false)
    {
        if(audioSource.enabled == false) return;
        audioSource.loop = IsLoop;
        audioSource.clip = AudioSO.NomalAttackAudio;
        audioSource.Play();
    }
    public void PlayDashAttackAudio(AudioSource audioSource,bool IsLoop = false)
    {
        if(audioSource.enabled == false) return;
        audioSource.loop = IsLoop;
        audioSource.clip = AudioSO.DashAttackAudio;
        audioSource.Play();
    }
    public void PlaySlideAudio(AudioSource audioSource,bool IsLoop = false)
    {
        if(audioSource.enabled == false) return;
        audioSource.loop = IsLoop;
        audioSource.clip = AudioSO.SlideAudio;
        audioSource.Play();
    }
    #endregion

    #region Skeleton
    public void PlaySkeletonWalkAudio(AudioSource audioSource,bool IsLoop = false)
    {
        if(audioSource.enabled == false) return;
        audioSource.loop = IsLoop;
        audioSource.clip = AudioSO.SkeletonWalk;
        audioSource.Play();
    }
    #endregion

    #region Orc
    public void PlayOrcVoiceNomalAudio(AudioSource audioSource,bool IsLoop = false)
    {
        if(audioSource.enabled == false) return;
        audioSource.loop = IsLoop;
        audioSource.clip = AudioSO.OrcVoiceNomal;
        audioSource.Play();
    }
    public void PlayOrcAttackAudio(AudioSource audioSource,bool IsLoop = false)
    {
        if(audioSource.enabled == false) return;
        audioSource.loop = IsLoop;
        audioSource.clip = AudioSO.OrcAttack;
        audioSource.Play();
    }
    #endregion

    #region Lizard
    public void PlayLizardShootAudio(AudioSource audioSource,bool IsLoop = false)
    {
        if(audioSource.enabled == false) return;
        audioSource.loop = IsLoop;
        audioSource.clip = AudioSO.LizardShoot;
        audioSource.Play();
    }
    #endregion

    #region Fly
    public void PlayRandomFlyAudio(AudioSource audioSource,bool IsLoop = false)
    {
        if(audioSource.enabled == false) return;
        audioSource.loop = IsLoop;
        int randomInt = Random.Range(1, 6);
        switch(randomInt)
        {
            case 1: 
                audioSource.clip = AudioSO.Fly1;
                break;
            case 2: 
                audioSource.clip = AudioSO.Fly2;
                break;
            case 3: 
                audioSource.clip = AudioSO.Fly3;
                break;
            case 4: 
                audioSource.clip = AudioSO.Fly4;
                break;
            case 5: 
                audioSource.clip = AudioSO.Fly5;
                break;
        }
        
        audioSource.Play();
    }
    public void PlayFlyDemonShootAudio(AudioSource audioSource,bool IsLoop = false)
    {
        if(audioSource.enabled == false) return;
        audioSource.loop = IsLoop;
        audioSource.clip = AudioSO.FlyDemonShoot;
        audioSource.Play();
    }
    #endregion

    #region FireSkull
    public void PlayFireSkullVoiceAudio(AudioSource audioSource,bool IsLoop = false)
    {
        if(audioSource.enabled == false) return;
        audioSource.loop = IsLoop;
        audioSource.clip = AudioSO.FireSkullVoice;
        audioSource.Play();
    }
    public void PlayFireSkullDashAudio(AudioSource audioSource,bool IsLoop = false)
    {
        if(audioSource.enabled == false) return;
        audioSource.loop = IsLoop;
        audioSource.clip = AudioSO.FireSkullDash;
        audioSource.Play();
    }

    #endregion 

    #region Golem
    public void PlayStoneGolemShootAudio(AudioSource audioSource,bool IsLoop = false)
    {
        if(audioSource.enabled == false) return;
        audioSource.loop = IsLoop;
        audioSource.clip = AudioSO.StoneGolemShoot;
        audioSource.Play();
    }
    public void PlayStoneGolemDashAudio(AudioSource audioSource,bool IsLoop = false)
    {
        if(audioSource.enabled == false) return;
        audioSource.loop = IsLoop;
        audioSource.clip = AudioSO.StoneGolemDash;
        audioSource.Play();
    }
    public void PlayStoneGolemLaserAudio(AudioSource audioSource,bool IsLoop = false)
    {
        if(audioSource.enabled == false) return;
        audioSource.loop = IsLoop;
        audioSource.clip = AudioSO.StoneGolemLaser;
        audioSource.Play();
    }
    #endregion
    #region Text
    public void PlayDialogueTextAudio(AudioSource audioSource,bool IsLoop = false)
    {
        if(audioSource.enabled == false) return;
        audioSource.loop = IsLoop;
        audioSource.clip = AudioSO.DialogText;
        audioSource.Play();
    }
    #endregion

    #region EarthQuake
    public void PlayEarthQuakeAudio(AudioSource audioSource,bool IsLoop = false)
    {
        if(audioSource.enabled == false) return;
        audioSource.loop = IsLoop;
        audioSource.clip = AudioSO.EarthQuakeSound;
        audioSource.Play();
    }
    #endregion

    public void PlayClickAudio(AudioSource audioSource,bool IsLoop = false)
    {
        if(audioSource.enabled == false) return;
        audioSource.loop = IsLoop;
        audioSource.clip = AudioSO.ClickButtonAudio;
        audioSource.Play();
    }
    public void PlayCollectBuffAudio(AudioSource audioSource,bool IsLoop = false)
    {
        if(audioSource.enabled == false) return;
        audioSource.loop = IsLoop;
        audioSource.clip = AudioSO.CollectBuffAudio;
        audioSource.Play();
    }

    public void StopAudio(AudioSource audioSource)
    {
        audioSource.Stop();
    }
    // public void PlayChooseAudio(AudioSource audioSource, string AudioString, bool IsLoop = false)
    // {
    //     audioSource.loop = IsLoop;
    //     if(AudioString == "Scene1Start")
    //     {
    //         audioSource.clip = AudioSO.Scene1Start;
    //     }
    //     else if(AudioString == "Scene1Cave")
    //     {
    //         audioSource.clip = AudioSO.Scene1Cave;
    //     }
    //     audioSource.Play();
    // }


    #region Change Volumn
    public void ChangeMasterVolumn(float value)
    {
        AudioSO.MasterVolumn.audioMixer.SetFloat("Master",value);
    }
    public void ChangeBGMVolumn(float value)
    {
        AudioSO.BGMVolumn.audioMixer.SetFloat("BGM",value);
    }
    public void ChangeSFXVolumn(float value)
    {
        AudioSO.SFXVolumn.audioMixer.SetFloat("SFX",value);
    }
    public void ChangeButtonVolumn(float value)
    {
        AudioSO.ButtonVolumn.audioMixer.SetFloat("Button",value);
    }
    public void ChangeEnemyVolumn(float value)
    {
        AudioSO.EnemyVolumn.audioMixer.SetFloat("Enemy",value);
    }
    public void ChangePlayerVolumn(float value)
    {
        AudioSO.SFXVolumn.audioMixer.SetFloat("Player",value);
    }

    public float GetMasterVolum()
    {
        float value;
        AudioSO.MasterVolumn.audioMixer.GetFloat("Master",out value);
        return value;
    }    
    public float GetSFXVolum()
    {
        float value;
        AudioSO.SFXVolumn.audioMixer.GetFloat("SFX",out value);
        return value;
    }   
    public float GetBGMVolum()
    {
        float value;
        AudioSO.BGMVolumn.audioMixer.GetFloat("BGM",out value);
        return value;
    }       
    #endregion





}
