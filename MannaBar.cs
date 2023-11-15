using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MannaBar : MonoBehaviour
{
    public Slider slider;

    public void SetManna(int manna)
    {
        slider.value = manna;

    }
    public void setMaxManna(int maxManna)
    {
        slider.maxValue = maxManna;
        //decide if you want to do this or not
        slider.value = maxManna;
    }
}
