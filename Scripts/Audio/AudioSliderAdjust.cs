using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSliderAdjust : MonoBehaviour
{
    public Slider MasterSlider;
    public Slider SFXSlider;
    public Slider BGMSlider;

    public void AdjustMasterAudioMixer()
    {
        AudioManager.Instance.ChangeMasterVolumn(MasterSlider.value);
    }
    public void AdjustBGMAudioMixer()
    {
        AudioManager.Instance.ChangeBGMVolumn(BGMSlider.value);
    }
    public void AdjustSFXAudioMixer()
    {
        AudioManager.Instance.ChangeSFXVolumn(SFXSlider.value);
    }

    


}
