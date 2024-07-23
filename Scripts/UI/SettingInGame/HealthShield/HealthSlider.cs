using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    public Slider Slider;
    public TMPro.TextMeshProUGUI HpText;

    
    public void SetMaxHealth(int CurrentHealth, int MaxHealth)
    {
        Slider.maxValue = MaxHealth;
        HpText.text = CurrentHealth.ToString() + "/" + MaxHealth.ToString();
    }

    public void SetCurrentHealth(int CurrentHealth,int MaxHealth)
    {
        Slider.value = CurrentHealth;
        HpText.text = CurrentHealth.ToString() + "/" + MaxHealth.ToString();
    }
}
