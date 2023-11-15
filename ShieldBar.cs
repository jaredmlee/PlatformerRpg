using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetDurability(int durability)
    {
        slider.value = durability;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    public void setMaxDurability(int maxDurability)
    {
        slider.maxValue = maxDurability;
        slider.value = maxDurability;

        fill.color = gradient.Evaluate(1f);
    }
}
