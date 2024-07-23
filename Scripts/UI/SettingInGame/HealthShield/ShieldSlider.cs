using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldSlider : MonoBehaviour
{
    public Slider Slider;
    public TMPro.TextMeshProUGUI ShieldText;

    
    public void SetMaxShield(int CurrentShield,int MaxShield)
    {
        Slider.maxValue = MaxShield;
        ShieldText.text = CurrentShield.ToString() + "/" + MaxShield.ToString();
    }

    public void SetCurrentShield(int CurrentShield,int MaxShield)
    {
        Slider.value = CurrentShield;
        ShieldText.text = CurrentShield.ToString() + "/" + MaxShield.ToString();
    }
}
