using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// para obtener los valores del slider

public class SliderController : MonoBehaviour
{
    public Text valueText;
    public void OnSliderChanged(float value) {
        valueText.text = value.ToString();
    }
}
